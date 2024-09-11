namespace CatalogoDeDiscos.Models
{
    public class MusicGenre
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public ICollection<ArtistBand> ArtistBands { get; set; } = new List<ArtistBand>();

        public MusicGenre()
        {
        }

        public MusicGenre(int id, string genre)
        {
            Id = id;
            Genre = genre;
        }

        public void AddArtistBand(ArtistBand artistBand)
        {
            ArtistBands.Add(artistBand);
        }

        //Criar um método para mostrar todos os artistas por gênero
        //Mostrar o artista e os discos desse artista

        //public string GenreArtist() { }
    }
}
