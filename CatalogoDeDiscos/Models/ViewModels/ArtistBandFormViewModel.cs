namespace CatalogoDeDiscos.Models.ViewModels
{
    public class ArtistBandFormViewModel
    {
        public ArtistBand ArtistBand { get; set; }
        public ICollection<MusicGenre> MusicGenres { get; set; }
    }
}
