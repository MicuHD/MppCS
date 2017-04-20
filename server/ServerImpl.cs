using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using services;
using persistance;
using model;

namespace server
{
    public class ServerImpl: MarshalByRefObject, ISServer
    {
        private PersonalDBRepository persRepo;
        private SpectacolDBRepository specRepo;
        private CumparatorDBRepository cumpRepo;
        private readonly IDictionary <String, ISClient> loggedClients;



    public ServerImpl(PersonalDBRepository repo, SpectacolDBRepository srepo, CumparatorDBRepository crepo) {
        persRepo = repo;
        specRepo = srepo;
        cumpRepo = crepo;
        loggedClients=new Dictionary<String, ISClient>();
    }

    public void login(Personal user, ISClient client)  {
        int userOk = persRepo.login(user.Username,user.Parola);
        if (userOk != -1){
            if(loggedClients.ContainsKey(user.Username))
                throw new SpectacolException("User already logged in.");
            loggedClients[user.Username]= client;
        }else
            throw new SpectacolException("Authentication failed.");
    }


    public void logout(Personal user, ISClient client)
    {
        ISClient localClient = loggedClients[user.Username];
        if (localClient == null)
            throw new SpectacolException("User " + user.Id + " is not logged in.");
        loggedClients.Remove(user.Username);
    }

    public Spectacol[] getSpectacols()
    {
        IEnumerable<Spectacol> spectacols = specRepo.findAll();
        IList<Spectacol> result = new List<Spectacol>();
        Console.WriteLine("get spectacols ");
        foreach (Spectacol spec in spectacols)
        {
                result.Add(spec);
        }
        return result.ToArray();
    }

        public void cumparare(Cumparator cump)
        {
            Spectacol nspec = specRepo.findOne(cump.IdSpectacol);
            if(cump.Bilete <= nspec.Disponibile)
            {
                nspec.Disponibile = nspec.Disponibile - cump.Bilete;
                nspec.Vandute = nspec.Vandute + cump.Bilete;
                specRepo.update(nspec.Id, nspec);
                cumpRepo.save(cump);
                notifyClients(nspec);
            }
            else
            {
                throw new SpectacolException("Numar bilete indisponibil"); 
            }
        }

        private void notifyClients(Spectacol spec)
        {
            Console.WriteLine("notify clients " );
            foreach (String cl in loggedClients.Keys)
            {
                    ISClient chatClient = loggedClients[cl];
                    Task.Run(() => chatClient.TicketSold(spec));
            }
        }
        //private void notifyFriendsLoggedIn(User user){
        //    IEnumerable<User> friends=userRepository.getFriendsOf(user);
        //    Console.WriteLine("notify logged friends "+friends.Count());
        //    foreach(User us in friends){
        //        if (loggedClients.ContainsKey(us.Id))
        //        {
        //            IChatObserver chatClient = loggedClients[us.Id];
        //	Task.Run(() => chatClient.friendLoggedIn(user));
        //        }
        //    }
        //}

        //private void notifyFriendsLoggedOut(User user) {
        //    IEnumerable<User> friends=userRepository.getFriendsOf(user);
        //    foreach(User us in friends){
        //        if (loggedClients.ContainsKey(us.Id))
        //        {
        //            IChatObserver chatClient = loggedClients[us.Id];
        //	Task.Run(() =>chatClient.friendLoggedOut(user));
        //        }
        //    }
        //}

        //public  void sendMessage(Message message)  {
        //    String id_receiver=message.Receiver.Id;

        //    if (loggedClients.ContainsKey(id_receiver))  {     //the receiver is logged in
        //        IChatObserver receiverClient=loggedClients[id_receiver];
        //Task.Run(() => receiverClient.messageReceived(message));
        //        messageRepository.save(message);
        //    }
        //    else
        //        throw new ChatException("User "+id_receiver+" not logged in.");
        //}



        //public  User[] getLoggedFriends(User user)  {
        //    IEnumerable<User> friends=userRepository.getFriendsOf(user);
        //    IList<User> result=new List<User>();
        //    Console.WriteLine("Logged friends for: "+user.Id);
        //    foreach (User friend in friends){
        //        if (loggedClients.ContainsKey(friend.Id)){    //the friend is logged in
        //            result.Add(new User(friend.Id));
        //            Console.WriteLine("+"+friend.Id);
        //        }
        //    }
        //    Console.WriteLine("Size "+result.Count);
        //    return result.ToArray();
        //}


    }
}
