using Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labMpp.Domain
{
    public class Spectacol : IHasID<int>
    {
        public int Id { get; set; }
        public String Locatie { get; set; }
        public int Disponibile { get; set; }
        public int Vandute { get; set; }
        public String Artist { get; set; }
        public String Data { get; set; }
        public String Ora { get; set; }


        public Spectacol(int id, String locatie, int disponibile, int vandute, String artist, String data, String ora)
        {
            Id = id;
            Locatie = locatie;
            Disponibile = disponibile;
            Vandute = vandute;
            Artist = artist;
            Data = data;
            Ora = ora;
        }
        public Spectacol(String locatie, int disponibile, int vandute, String artist, String data, String ora)
        {
            Id = -1;
            Locatie = locatie;
            Disponibile = disponibile;
            Vandute = vandute;
            Artist = artist;
            Data = data;
            Ora = ora;
        }
    }
}
