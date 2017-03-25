using labMpp.Domain;
using labMpp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labMpp.Service
{
    class LoginService : ILoginService<Personal>
    {
        private PersonalDBRepository Repo { get; set; }


        public LoginService(PersonalDBRepository repo)
        {
            Repo = repo;
        }
        public Personal Login(string user, string pass)
        {
            int id = Repo.login(user, pass);
            if (id.Equals(-1))
            {
                return null;
            }
            return Repo.findOne(id);
        }
    }
}
