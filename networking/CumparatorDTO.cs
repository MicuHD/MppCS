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
    public class CumparatorDTO
    {
        public int Id { get; set; }
        public String Nume { get; set; }
        public int Bilete { get; set; }
        public int IdSpectacol { get; set; }

        public CumparatorDTO(int id, String nume, int bilete, int spectacol)
        {
            Id = id;
            Nume = nume;
            Bilete = bilete;
            IdSpectacol = spectacol;
        }
    }
}