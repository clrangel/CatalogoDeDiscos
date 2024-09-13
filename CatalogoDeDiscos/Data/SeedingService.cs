using CatalogoDeDiscos.Models;
using CatalogoDeDiscos.Models.Enums;
using NuGet.Protocol.Plugins;
using Pomelo.EntityFrameworkCore.MySql.Query.ExpressionVisitors.Internal;

namespace CatalogoDeDiscos.Data
{
    public class SeedingService
    {
        private CatalogoDeDiscosContext _context;

        public SeedingService(CatalogoDeDiscosContext context) 
        { 
            _context = context;
        }

        public void Seed()
        {
            //Testa se existe algum registro na tabela
            if (_context.MusicGenre.Any() ||
                _context.ArtistBand.Any() ||
                _context.Album.Any())
            {
                return; // DB has been seeded
            }


            MusicGenre m1 = new MusicGenre(1, "Heavy Metal");
            MusicGenre m2 = new MusicGenre(2, "Thrash Metal");
            MusicGenre m3 = new MusicGenre(3, "Death Metal");
            MusicGenre m4 = new MusicGenre(4, "Doom Metal");
            MusicGenre m5 = new MusicGenre(5, "Gothic Metal");
            MusicGenre m6 = new MusicGenre(6, "Alternative");
            MusicGenre m7 = new MusicGenre(7, "Alternative");

            ArtistBand ab1 = new ArtistBand(1, "Metallica", 1981, "EUA", m2);
            ArtistBand ab2 = new ArtistBand(2, "Slayer", 1981, "EUA", m2);
            ArtistBand ab3 = new ArtistBand(3, "My Dying Bride", 1981, "EUA", m4);
            ArtistBand ab4 = new ArtistBand(4, "Judas Priest", 1981, "EUA", m1);
            ArtistBand ab5 = new ArtistBand(5, "Clutch", 1981, "EUA", m7);
            ArtistBand ab6 = new ArtistBand(6, "Danzig", 1981, "EUA", m1);
            ArtistBand ab7 = new ArtistBand(7, "The 69 Eyes", 1981, "EUA", m5);
            ArtistBand ab8 = new ArtistBand(8, "Alice in Chains", 1981, "EUA", m6);
            ArtistBand ab9 = new ArtistBand(9, "Cannibal Corpse", 1981, "EUA", m3);
            ArtistBand ab10 = new ArtistBand(10, "Katatonia", 1981, "EUA", m4);

            Album r1 = new Album(1, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);
            Album r2 = new Album(2, "...And Justice for All", new DateTime(1988, 09, 7), AlbumStatus.Studio, ab1);
            Album r3 = new Album(3, "Kill 'Em All", new DateTime(1983, 07, 25), AlbumStatus.Studio, ab1);
            Album r4 = new Album(4, "Ride the Lightning", new DateTime(1984, 07, 27), AlbumStatus.Studio, ab1);
            Album r5 = new Album(5, "Black Album", new DateTime(1991, 08, 12), AlbumStatus.Studio, ab1);
            Album r6 = new Album(6, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab2);
            Album r7 = new Album(7, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab2);
            Album r8 = new Album(8, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab2);
            Album r9 = new Album(9, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab2);
            Album r10 = new Album(10, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);
            Album r11 = new Album(11, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);
            Album r12 = new Album(12, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);
            Album r13 = new Album(13, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);
            Album r14 = new Album(14, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);
            Album r15 = new Album(15, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);
            Album r16 = new Album(16, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);
            Album r17 = new Album(17, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);
            Album r18 = new Album(18, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);
            Album r19 = new Album(19, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);
            Album r20 = new Album(20, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);
            Album r21 = new Album(21, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);
            Album r22 = new Album(22, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);
            Album r23 = new Album(23, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);
            Album r24 = new Album(24, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);
            Album r25 = new Album(25, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);
            Album r26 = new Album(26, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);
            Album r27 = new Album(27, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);
            Album r28 = new Album(28, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);
            Album r29 = new Album(29, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);
            Album r30 = new Album(30, "Master Of Puppets", new DateTime(1986, 03, 3), AlbumStatus.Studio, ab1);

            _context.MusicGenre.AddRange(m1, m2, m3, m4, m5, m6, m7);

            _context.ArtistBand.AddRange(ab1, ab2, ab3, ab4, ab5, ab6, ab7, ab8, ab9, ab10);

            _context.Album.AddRange(
                r1, r2, r3, r4, r5, r6, r7, r8, r9, r10,
                r11, r12, r13, r14, r15, r16, r17, r18, r19, r20,
                r21, r22, r23, r24, r25, r26, r27, r28, r29, r30
            );

            _context.SaveChanges();
        }

    }
}
