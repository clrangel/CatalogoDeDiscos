using CatalogoDeDiscos.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CatalogoDeDiscos.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Display(Name = "Album Name")]
        [Required(ErrorMessage = "{0} required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} an {1}")]
        public string AlbumName { get; set; }

        [Display(Name = "Release Year")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ReleaseYear { get; set; }
        public AlbumStatus Status { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Artist Band")]
        public ArtistBand ArtistBand { get; set; }
        public int ArtistBandId { get; set; }

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
