using System;

namespace networking.dto
{


	///
	/// <summary> * Created by IntelliJ IDEA.
	/// * User: grigo
	/// * Date: Mar 18, 2009
	/// * Time: 4:20:27 PM </summary>
	/// 
	[Serializable]
	public class PersDTO
	{
		private string user;
		private string passwd;

		public PersDTO(string user) : this(user, "")
		{
		}

		public PersDTO(string user, string passwd)
		{
			this.user = user;
			this.passwd = passwd;
		}

		public virtual string User
		{
			get
			{
                return user;
			}
			set
			{
				this.user = value;
			}
		}


		public virtual string Passwd
		{
			get
			{
				return passwd;
			}
		}
	}
}