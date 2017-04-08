using System;
using System.Collections.Generic;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using services;
using networking.protocol;
using model;
using networking.dto;

namespace networking.server
{
	///
	/// <summary> * Created by IntelliJ IDEA.
	/// * User: grigo
	/// * Date: Mar 18, 2009
	/// * Time: 4:36:34 PM </summary>
	/// 
	public class ServerProxy : ISServer
	{
		private string host;
		private int port;

		private ISClient client;

		private NetworkStream stream;
		
        private IFormatter formatter;
		private TcpClient connection;

		private Queue<Response> responses;
		private volatile bool finished;
        private EventWaitHandle _waitHandle;
		public ServerProxy(string host, int port)
		{
			this.host = host;
			this.port = port;
			responses=new Queue<Response>();
		}

        public virtual void login(Personal user, ISClient client)
		{
			initializeConnection();
			PersDTO udto = DTOUtils.getDTO(user);
			sendRequest(new LoginRequest(udto));
			Response response =readResponse();
			if (response is OkResponse)
			{
				this.client=client;
				return;
			}
			if (response is ErrorResponse)
			{
				ErrorResponse err =(ErrorResponse)response;
				closeConnection();
				throw new SpectacolException(err.Message);
			}
		}


        public virtual void logout(Personal user, ISClient client)
        {
            PersDTO udto = DTOUtils.getDTO(user);
            sendRequest(new LogoutRequest(udto));
            Response response = readResponse();
            closeConnection();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new SpectacolException(err.Message);
            }
        }

        public void cumparare(Cumparator cump)
        {
            CumparatorDTO cdto = DTOUtils.getDTO(cump);
            sendRequest(new CumparareRequest(cdto));
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new SpectacolException(err.Message);
            }
        }

        public virtual Spectacol[] getSpectacols()
        {
            sendRequest(new GetSpectacolsRequest());
            Response response = readResponse();
            if (response is ErrorResponse)
            {
                ErrorResponse err = (ErrorResponse)response;
                throw new SpectacolException(err.Message);
            }
            GetSpectacolsRespone resp = (GetSpectacolsRespone)response;
            SpectacolDTO[] frDTO = resp.Specs;
            Spectacol[] specs = DTOUtils.getFromDTO(frDTO);
            return specs;
        }

        private void closeConnection()
		{
			finished=true;
			try
			{
				stream.Close();
				//output.close();
				connection.Close();
                _waitHandle.Close();
				client=null;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}

		}

		private void sendRequest(Request request)
		{
			try
			{
                formatter.Serialize(stream, request);
                stream.Flush();
			}
			catch (Exception e)
			{
				throw new SpectacolException("Error sending object "+e);
			}

		}

		private Response readResponse()
		{
			Response response =null;
			try
			{
                _waitHandle.WaitOne();
				lock (responses)
				{
                    //Monitor.Wait(responses); 
                    response = responses.Dequeue();
                
				}
				

			}
			catch (Exception e)
			{
				Console.WriteLine(e.StackTrace);
			}
			return response;
		}
		private void initializeConnection()
		{
			 try
			 {
				connection=new TcpClient(host,port);
				stream=connection.GetStream();
                formatter = new BinaryFormatter();
				finished=false;
                _waitHandle = new AutoResetEvent(false);
				startReader();
			}
			catch (Exception e)
			{
                Console.WriteLine(e.StackTrace);
			}
		}
		private void startReader()
		{
			Thread tw =new Thread(run);
			tw.Start();
		}


        private void handleUpdate(UpdateResponse update)
        {
            if (update is SoldTicketResponse)
            {

                SoldTicketResponse frUpd = (SoldTicketResponse)update;
                Spectacol friend = DTOUtils.getFromDTO(frUpd.Spec);
                Console.WriteLine("ticket sold");
                try
                {
                    client.TicketSold(friend);
                }
                catch (SpectacolException e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }


        public virtual void run()
			{
				while(!finished)
				{
					try
					{
                        object response = formatter.Deserialize(stream);
						Console.WriteLine("response received "+response);
						if (response is UpdateResponse)
						{
							 handleUpdate((UpdateResponse)response);
						}
						else
						{
							
							lock (responses)
							{
                                					
								 
                                responses.Enqueue((Response)response);
                               
							}
                            _waitHandle.Set();
						}
					}
					catch (Exception e)
					{
						Console.WriteLine("Reading error "+e);
					}
					
				}
			}
    }

}