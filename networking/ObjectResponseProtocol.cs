using networking.dto;
using System;
namespace networking.protocol
{

	public interface Response 
	{
	}

	[Serializable]
	public class OkResponse : Response
	{
		
	}

    [Serializable]
	public class ErrorResponse : Response
	{
		private string message;

		public ErrorResponse(string message)
		{
			this.message = message;
		}

		public virtual string Message
		{
			get
			{
				return message;
			}
		}
	}

    [Serializable]
    public class GetSpectacolsRespone : Response
    {
        private SpectacolDTO[] specs;

        public GetSpectacolsRespone(SpectacolDTO[] specs)
        {
            this.specs = specs;
        }

        public virtual SpectacolDTO[] Specs
        {
            get
            {
                return specs;
            }
        }
    }


    public interface UpdateResponse : Response
    {
    }


    [Serializable]
    public class SoldTicketResponse : UpdateResponse
    {
        private SpectacolDTO specs;

        public SoldTicketResponse(SpectacolDTO specs)
        {
            this.specs = specs;
        }

        public virtual SpectacolDTO Spec
        {
            get
            {
                return specs;
            }
        }
    }

}