namespace CatalogoDeDiscos.Models
{
    public class MusicGenre
    {
        public int Id { get; set; }
        public string Genre { get; set; }

        public MusicGenre()
        {
        }

        public MusicGenre(int id, string genre)
        {
            Id = id;
            Genre = genre;
        }
    }
}
