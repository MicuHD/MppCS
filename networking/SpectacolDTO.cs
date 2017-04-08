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
    public class SpectacolDTO
    {
        public int id { get; set; }
        public String locatie { get; set; }
        public int disponibile { get; set; }
        public int vandute { get; set; }
        public String artist { get; set; }
        public String data { get; set; }
        public String ora { get; set; }

        public SpectacolDTO(int id, String locatie, int disponibile, int vandute, String artist, String data, String ora)
        {
            this.id = id;
            this.locatie = locatie;
            this.disponibile = disponibile;
            this.vandute = vandute;
            this.artist = artist;
            this.data = data;
            this.ora = ora;
        }

    }
}