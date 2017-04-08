using System;
namespace networking.protocol
{
    using dto;
    using PersDTO = networking.dto.PersDTO;


    public interface Request 
	{
	}


    [Serializable]
    public class LoginRequest : Request
    {
        private PersDTO user;

        public LoginRequest(PersDTO user)
        {
            this.user = user;
        }

        public virtual PersDTO User
        {
            get
            {
                return user;
            }
        }
    }

    [Serializable]
    public class LogoutRequest : Request
    {
        private PersDTO user;

        public LogoutRequest(PersDTO user)
        {
            this.user = user;
        }

        public virtual PersDTO User
        {
            get
            {
                return user;
            }
        }
    }


    [Serializable]
    public class CumparareRequest : Request
    {
        private CumparatorDTO cmp;

        public CumparareRequest(CumparatorDTO cmp)
        {
            this.cmp = cmp;
        }

        public virtual CumparatorDTO Cmp
        {
            get
            {
                return cmp;
            }
        }
    }


    [Serializable]
    public class GetSpectacolsRequest : Request
    {

        public GetSpectacolsRequest()
        {
        }
    }

    //[Serializable]
    //public class SendMessageRequest : Request
    //{
    //	private MessageDTO message;

    //	public SendMessageRequest(MessageDTO message)
    //	{
    //		this.message = message;
    //	}

    //	public virtual MessageDTO Message
    //	{
    //		get
    //		{
    //			return message;
    //		}
    //	}
    //}

    //[Serializable]
    //public class GetLoggedFriendsRequest : Request
    //{
    //	private UserDTO user;

    //	public GetLoggedFriendsRequest(UserDTO user)
    //	{
    //		this.user = user;
    //	}

    //	public virtual UserDTO User
    //	{
    //		get
    //		{
    //			return user;
    //		}
    //	}
    //}


}