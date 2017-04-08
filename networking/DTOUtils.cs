using System;
using model;

namespace networking.dto
{

    //using User = chat.model.User;
    //using Message = chat.model.Message;

    ///
    /// <summary> * Created by IntelliJ IDEA.
    /// * User: grigo
    /// * Date: Mar 20, 2009
    /// * Time: 8:07:36 AM </summary>
    /// 
    public class DTOUtils
    {
        public static Personal getFromDTO(PersDTO usdto)
        {
            string user = usdto.User;
            string pass = usdto.Passwd;
            return new Personal(user, pass);

        }
        public static PersDTO getDTO(Personal user)
        {
            string username = user.Username;
            string pass = user.Parola;
            return new PersDTO(username, pass);
        }

        public static Cumparator getFromDTO(CumparatorDTO usdto)
        {
            return new Cumparator(usdto.Id, usdto.Nume, usdto.Bilete, usdto.IdSpectacol);

        }
        public static CumparatorDTO getDTO(Cumparator cmp)
        {
            return new CumparatorDTO(cmp.Id,cmp.Nume,cmp.Bilete,cmp.IdSpectacol);
        }

        public static SpectacolDTO getDTO(Spectacol mdto)
        {
            return new SpectacolDTO(mdto.Id, mdto.Locatie, mdto.Disponibile, mdto.Vandute, mdto.Artist, mdto.Data, mdto.Ora);

        }

        public static Spectacol getFromDTO(SpectacolDTO mdto)
        {
            return new Spectacol(mdto.id, mdto.locatie, mdto.disponibile, mdto.vandute, mdto.artist, mdto.data, mdto.ora);

        }

        //	public static MessageDTO getDTO(Message message)
        //	{
        //		string senderId =message.Sender.Id;
        //		string receiverId =message.Receiver.Id;
        //		string txt =message.Text;
        //		return new MessageDTO(senderId, txt, receiverId);
        //	}

        //	public static UserDTO[] getDTO(User[] users)
        //	{
        //		UserDTO[] frDTO =new UserDTO[users.Length];
        //		for(int i=0;i<users.Length;i++)
        //		{
        //			frDTO[i]=getDTO(users[i]);
        //		}
        //		return frDTO;
        //	}

        public static SpectacolDTO[] getDTO(Spectacol[] specs)
        {
            SpectacolDTO[] frDTO = new SpectacolDTO[specs.Length];
            for (int i = 0; i < specs.Length; i++)
            {
                frDTO[i] = getDTO(specs[i]);
            }
            return frDTO;
        }


        public static Spectacol[] getFromDTO(SpectacolDTO[] specs)
        {
            Spectacol[] spectacols = new Spectacol[specs.Length];
            for (int i = 0; i < specs.Length; i++)
            {
                spectacols[i] = getFromDTO(specs[i]);
            }
            return spectacols;
        }
    }

}
