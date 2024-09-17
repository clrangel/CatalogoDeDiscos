using System.ComponentModel.DataAnnotations;
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
        public int MusicGenreId { get; set; }
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

        //Criar um método para mostrar todos os discos por artista - Nome do artista + nome disco
        /*
        public string TotalAlbuns(string disc)
        {
            return Albuns.Where(d => d.AlbumName == ArtistBand);

        }
        */

        /*
        public string AlbunsBand(string disc)
        {
            foreach(Album al in Albuns)
            {
                return al.AlbumName;
            }
        }
        */

        //Método para mostrar os discos por ano de lançamento
        
        public double TotalAlbuns(DateTime initial, DateTime final)
        {
            return Albuns.Where(al => al.ReleaseYear >= initial && al.ReleaseYear <= final).Sum(al => al.Id);
        }
      
    }

}
