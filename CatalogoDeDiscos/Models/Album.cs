using CatalogoDeDiscos.Models.Enums;

namespace CatalogoDeDiscos.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string AlbumName { get; set; }
        public DateTime ReleaseYear { get; set; }
        public AlbumStatus Status { get; set; }
        public ArtistBand ArtistBand { get; set; }

        public Album()
        {
        }

        public Album(int id, string albumName, DateTime releaseYear, AlbumStatus status, ArtistBand artistBand)
        {
            Id = id;
            AlbumName = albumName;
            ReleaseYear = releaseYear;
            Status = status;
            ArtistBand = artistBand;
        }

        //Criar um método que mostre uma lista de disco por ano de lançamento
    }
}
