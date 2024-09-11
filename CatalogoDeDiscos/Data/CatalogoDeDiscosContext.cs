using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CatalogoDeDiscos.Models;

namespace CatalogoDeDiscos.Data
{
    public class CatalogoDeDiscosContext : DbContext
    {
        public CatalogoDeDiscosContext (DbContextOptions<CatalogoDeDiscosContext> options)
            : base(options)
        {
        }

        public DbSet<MusicGenre> MusicGenre { get; set; } = default!;
        public DbSet<ArtistBand> ArtistBand { get; set; } = default!;
        public DbSet<Album> Album { get; set; } = default!;
    }
}
