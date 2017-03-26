using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labMpp.Domain
{
    public class Cumparator : IHasID<int>
    {
        public int Id { get; set; }

        public String Nume { get; set; }

        public Cumparator(int id, String nume, int bilete, int idSpectacol)
        {
            Id = id;
            Nume = nume;
            Bilete = bilete;
            IdSpectacol = idSpectacol;
        }

        public Cumparator(String nume, int bilete, int idSpectacol)
        {
            Id = -1;
            Nume = nume;
            Bilete = bilete;
            IdSpectacol = idSpectacol;
        }

        public int Bilete { get; set; }
        public int IdSpectacol { get; set; }


    }
}
