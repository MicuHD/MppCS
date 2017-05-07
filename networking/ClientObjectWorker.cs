using System;
using System.Threading;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using services;
using networking.protocol;
using model;
using networking.dto;
using System.Text;

namespace networking
{

	
	
	///
	/// <summary> * Created by IntelliJ IDEA.
	/// * User: grigo
	/// * Date: Mar 18, 2009
	/// * Time: 4:04:43 PM </summary>
	/// 
	public class ClientWorker :  ISClient //, Runnable
	{
		private ISServer server;
		private TcpClient connection;

		private NetworkStream stream;
		private IFormatter formatter;
		private volatile bool connected;
		public ClientWorker(ISServer server, TcpClient connection)
		{
			this.server = server;
			this.connection = connection;
			try
			{
				
				stream=connection.GetStream();
                formatter = new BinaryFormatter();
				connected=true;
			}
			catch (Exception e)
			{
                Console.WriteLine(e.StackTrace);
			}
		}

		public virtual void run()
		{
			while(connected)
			{
				try
				{
                    //stream.Read()
                    byte[] byteArray = new byte[2048];
                    stream.Read(byteArray, 0, 2048);
                    string req = System.Text.Encoding.Default.GetString(byteArray);
                    Console.WriteLine("Mesaj: ");
                    Console.WriteLine(req);
                    Console.WriteLine("Mesaj: ");

                    if(req != "")
                    {
                        string request = "";
                        //stream.Read()
                        object response = handleRequest((string)req);
                        if (response != null)
                        {
                            sendResponse((Response)response);
                        }
                    }
                   
				}
				catch (Exception e)
				{
                    Console.WriteLine(e.StackTrace);
				}
				
				try
				{
					Thread.Sleep(1000);
				}
				catch (Exception e)
				{
                    Console.WriteLine(e.StackTrace);
				}
			}
			try
			{
				stream.Close();
				connection.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Error "+e);
			}
		}
		

		private Response handleRequest(string request)
		{
			Response response =null;

            StringRequestType rtype = StringRequestMethod.RequestType(request);

			if (rtype == StringRequestType.LOGIN)
			{
				Console.WriteLine("Login request ...");
                //LoginRequest logReq =(LoginRequest)request;
                //PersDTO udto =logReq.User;
                string[] reqItems = request.Split('.');
                string[] persItems = reqItems[1].Split(',');
                Personal user = new Personal(persItems[0], persItems[1]);
				try
                {
                    lock (server)
                    {
                        server.login(user, this);
                    }
					return new OkResponse();
				}
				catch (SpectacolException e)
				{
					connected=false;
					return new ErrorResponse(e.Message);
				}
			}
            if (rtype == StringRequestType.LOGOUT)
            {
                Console.WriteLine("Logout request ...");
                //LoginRequest logReq =(LoginRequest)request;
                //PersDTO udto =logReq.User;
                string[] reqItems = request.Split('.');
                string[] persItems = reqItems[1].Split(',');
                Personal user = new Personal(persItems[0], persItems[1]);
                try
                {
                    lock (server)
                    {
                        //server.login(user, this);
                        server.logout(user, this);

                    }
                    connected = false;
                    return new OkResponse();
                }
                catch (SpectacolException e)
                {
                    connected = false;
                    return new ErrorResponse(e.Message);
                }
            }

            if (rtype == StringRequestType.GETSHOWS)
            {
                Console.WriteLine("GetSpectacols ...");
                //GetSpectacolsRequest getReq = (GetSpectacolsRequest)request;
                try
                {
                    Spectacol[] friends;
                    lock (server)
                    {

                        friends = server.getSpectacols();
                    }
                    SpectacolDTO[] frDTO = DTOUtils.getDTO(friends);
                    return new GetSpectacolsRespone(frDTO);
                }
                catch (SpectacolException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if(rtype == StringRequestType.SELLTICHET)
            {
                Console.WriteLine("Cumparare request");
                //CumparareRequest logReq = (CumparareRequest)request;
                //CumparatorDTO udto = logReq.Cmp;
                //Cumparator cmp = DTOUtils.getFromDTO(udto);
                string[] reqItems = request.Split('.');
                string[] persItems = reqItems[1].Split(',');
                Cumparator cmp = new Cumparator(persItems[0], int.Parse(persItems[1]), int.Parse(persItems[2]));
                try
                {
                    lock (server)
                    {

                        server.cumparare(cmp);
                    }
                    return new OkResponse();
                }
                catch (SpectacolException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            //if (request is LogoutRequest)
            //{
            //    Console.WriteLine("Logout request");
            //    LogoutRequest logReq = (LogoutRequest)request;
            //    PersDTO udto = logReq.User;
            //    Personal user = DTOUtils.getFromDTO(udto);
            //    try
            //    {
            //        lock (server)
            //        {

            //            server.logout(user, this);
            //        }
            //        connected = false;
            //        return new OkResponse();

            //    }
            //    catch (SpectacolException e)
            //    {
            //        return new ErrorResponse(e.Message);
            //    }
            //}

            //if (request is CumparareRequest)
            //{
            //    Console.WriteLine("Cumparare request");
            //    CumparareRequest logReq = (CumparareRequest)request;
            //    CumparatorDTO udto = logReq.Cmp;
            //    Cumparator cmp = DTOUtils.getFromDTO(udto);
            //    try
            //    {
            //        lock (server)
            //        {

            //            server.cumparare(cmp);
            //        }
            //        return new OkResponse();

            //    }
            //    catch (SpectacolException e)
            //    {
            //        return new ErrorResponse(e.Message);
            //    }
            //}



            //if (request is GetSpectacolsRequest)
            //{
            //    Console.WriteLine("GetSpectacols ...");
            //    GetSpectacolsRequest getReq = (GetSpectacolsRequest)request;
            //    try
            //    {
            //        Spectacol[] friends;
            //        lock (server)
            //        {

            //            friends = server.getSpectacols();
            //        }
            //        SpectacolDTO[] frDTO = DTOUtils.getDTO(friends);
            //        return new GetSpectacolsRespone(frDTO);
            //    }
            //    catch (SpectacolException e)
            //    {
            //        return new ErrorResponse(e.Message);
            //    }
            //}


            return response;
		}

	    private void sendResponse(Response response)
	    {
		    Console.WriteLine("sending response "+response);
            //byte[] toBytes = Encoding.ASCII.GetBytes("1,admin,admin,");
            if(response is OkResponse)
            {
                string resp = "1.";
                byte[] toBytes = Encoding.ASCII.GetBytes(resp);
                stream.Write(toBytes, 0, resp.Length);
            }
            if(response is ErrorResponse)
            {
                string resp = "2.";
                resp += ((ErrorResponse)response).Message;
                Console.WriteLine("err:" + resp);
                byte[] toBytes = Encoding.ASCII.GetBytes(resp);
                stream.Write(toBytes, 0, resp.Length);
            }
            if(response is GetSpectacolsRespone)
            {
                string resp = "1.";
                SpectacolDTO[] specs = ((GetSpectacolsRespone)response).Specs;
                //Integer id, String locatie, Integer disponibile, Integer vandute, String artist,String data,String ora
                foreach (SpectacolDTO sp in specs)
                {
                    resp += sp.id + ",";
                    resp += sp.locatie + ",";
                    resp += sp.disponibile + ",";
                    resp += sp.vandute + ",";
                    resp += sp.artist + ",";
                    resp += sp.data + ",";
                    resp += sp.ora + ",";
                    resp += ";";
                }
                Console.WriteLine("err:" + resp);
                byte[] toBytes = Encoding.ASCII.GetBytes(resp);
                stream.Write(toBytes, 0, resp.Length);
            }
            if(response is SoldTicketResponse)
            {
                SpectacolDTO sp = ((SoldTicketResponse)response).Spec;
                string resp = "9.";
                resp += sp.id + ",";
                resp += sp.locatie + ",";
                resp += sp.disponibile + ",";
                resp += sp.vandute + ",";
                resp += sp.artist + ",";
                resp += sp.data + ",";
                resp += sp.ora + ",";
                resp += ";";
                byte[] toBytes = Encoding.ASCII.GetBytes(resp);
                stream.Write(toBytes, 0, resp.Length);
            }
            stream.Flush();
	    }

        public void TicketSold(Spectacol spec)
        {
            SpectacolDTO udto = DTOUtils.getDTO(spec);
            Console.WriteLine("SOld ticket");
            try
            {
            
                sendResponse(new SoldTicketResponse(udto));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        


    }

}