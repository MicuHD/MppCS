using System;
using System.Threading;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using services;
using networking.protocol;
using model;
using networking.dto;

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
                    object request = formatter.Deserialize(stream);
					object response =handleRequest((Request)request);
					if (response!=null)
					{
					   sendResponse((Response) response);
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
		

		private Response handleRequest(Request request)
		{
			Response response =null;
			if (request is LoginRequest)
			{
				Console.WriteLine("Login request ...");
				LoginRequest logReq =(LoginRequest)request;
				PersDTO udto =logReq.User;
				Personal user =DTOUtils.getFromDTO(udto);
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

            if (request is LogoutRequest)
            {
                Console.WriteLine("Logout request");
                LogoutRequest logReq = (LogoutRequest)request;
                PersDTO udto = logReq.User;
                Personal user = DTOUtils.getFromDTO(udto);
                try
                {
                    lock (server)
                    {

                        server.logout(user, this);
                    }
                    connected = false;
                    return new OkResponse();

                }
                catch (SpectacolException e)
                {
                    return new ErrorResponse(e.Message);
                }
            }

            if (request is CumparareRequest)
            {
                Console.WriteLine("Cumparare request");
                CumparareRequest logReq = (CumparareRequest)request;
                CumparatorDTO udto = logReq.Cmp;
                Cumparator cmp = DTOUtils.getFromDTO(udto);
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



            if (request is GetSpectacolsRequest)
            {
                Console.WriteLine("GetSpectacols ...");
                GetSpectacolsRequest getReq = (GetSpectacolsRequest)request;
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


            return response;
		}

	    private void sendResponse(Response response)
	    {
		    Console.WriteLine("sending response "+response);
            formatter.Serialize(stream, response);
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