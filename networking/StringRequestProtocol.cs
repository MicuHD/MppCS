using System;
namespace networking.protocol
{
    using dto;
    using PersDTO = networking.dto.PersDTO;


    public enum StringRequestType{LOGIN,LOGOUT,ERROR, GETSHOWS, SELLTICHET }

    [Serializable]
    public class StringRequest 
	{
        public string Request { get; set; }

        public StringRequest(string req)
        {
            Request = req;
        }
	}

    public class StringRequestMethod
    {
        static public StringRequestType RequestType(string req)
        {
            string[] items = req.Split('.');
            if (items[0].Equals("1"))
            {
                return StringRequestType.LOGIN;

            }
            if (items[0].Equals("2"))
            {
                return StringRequestType.LOGOUT;
            }
            if (items[0].Equals("3"))
            {
                return StringRequestType.GETSHOWS;
            }
            if (items[0].Equals("4"))
            {
                return StringRequestType.SELLTICHET;
            }
            return StringRequestType.ERROR;
        }
            
    }


    //[Serializable]
    //public class StringLoginRequest : StringRequest
    //{
    //    private string user;

    //    public StringLoginRequest(PersDTO user)
    //    {
    //        this.user = user;
    //    }

    //    public virtual PersDTO User
    //    {
    //        get
    //        {
    //            return user;
    //        }
    //    }
    //}

    //[Serializable]
    //public class LogoutRequest : Request
    //{
    //    private PersDTO user;

    //    public LogoutRequest(PersDTO user)
    //    {
    //        this.user = user;
    //    }

    //    public virtual PersDTO User
    //    {
    //        get
    //        {
    //            return user;
    //        }
    //    }
    //}


    //[Serializable]
    //public class CumparareRequest : Request
    //{
    //    private CumparatorDTO cmp;

    //    public CumparareRequest(CumparatorDTO cmp)
    //    {
    //        this.cmp = cmp;
    //    }

    //    public virtual CumparatorDTO Cmp
    //    {
    //        get
    //        {
    //            return cmp;
    //        }
    //    }
    //}


    //[Serializable]
    //public class GetSpectacolsRequest : Request
    //{

    //    public GetSpectacolsRequest()
    //    {
    //    }
    //}

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