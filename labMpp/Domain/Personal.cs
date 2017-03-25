using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labMpp.Domain
{
    class Personal : IHasID<int>
    {
        public int Id { get; set; }
        public String Nume;
        public String Username;
        public String Parola;

        public Personal(int id, String nume, String username, String parola)
        {
            Id = id;
            Nume = nume;
            Username = username;
            Parola = parola;
        }
        public Personal(String nume, String username, String parola)
        {
            Id = -1;
            Nume = nume;
            Username = username;
            Parola = parola;
        }
    }
}
