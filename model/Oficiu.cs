using System;


namespace model
{
    [Serializable]
    public class Oficiu : IHasID<int>
    {
        public int Id { get; set; }
        public String Nume { get; set; }
        public String Descriere { get; set; }

        public Oficiu(String nume, String descriere)
        {
            Id = -1;
            Nume = nume;
            Descriere = descriere;
        }

        public Oficiu(int id, String nume, String descriere)
        {
            Id = id;
            Nume = nume;
            Descriere = descriere;
        }
    }
}
