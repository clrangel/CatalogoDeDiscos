using System.Linq;
namespace CatalogoDeDiscos.Models
{
    public class ArtistBand
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public int FoundingDate { get; set; }
        public string Country { get; set; }
        public MusicGenre MusicGenre { get; set; }
        public ICollection<Album> Albuns { get; set; } = new List<Album>();

        public ArtistBand()
        {
        }

        public ArtistBand(int id, string artistName, int foundingDate, string country, MusicGenre musicGenre)
        {
            Id = id;
            ArtistName = artistName;
            FoundingDate = foundingDate;
            Country = country;
            MusicGenre = musicGenre;
        }

        public void AddAlbum(Album al)
        {
            Albuns.Add(al);
        }

        public void RemoveAlbum(Album al)
        {
            Albuns.Remove(al);
        }
        
        //Criar um método para mostrar todos os discos por artista
        /*
        public string TotalAlbuns(int disc)
        {
            return Albuns.Where(d => d.AlbumName);

        }
        */
    }

}
