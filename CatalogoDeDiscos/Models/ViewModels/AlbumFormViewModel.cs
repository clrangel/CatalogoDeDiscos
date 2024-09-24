namespace CatalogoDeDiscos.Models.ViewModels
{
    public class AlbumFormViewModel
    {
        public Album Album { get; set; }

        public ICollection<ArtistBand> ArtistBands { get; set; }

        public Enum Enum { get; set; }
    }
}
