using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labMpp.Domain
{
    class Spectacol : IHasID<int>
    {
        public int Id { get; set; }
        public String Locatie;
        public int Disponibile;
        public int Vandute;
        public int IdArtist;

        public Spectacol(int id, String locatie, int disponibile, int vandute, int idArtist)
        {
            Id = id;
            Locatie = locatie;
            Disponibile = disponibile;
            Vandute = vandute;
            IdArtist = idArtist;
        }
        public Spectacol(String locatie, int disponibile, int vandute, int idArtist)
        {
            Id = -1;
            Locatie = locatie;
            Disponibile = disponibile;
            Vandute = vandute;
            IdArtist = idArtist;
        }
    }
}
