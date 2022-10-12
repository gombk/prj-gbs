using Microsoft.EntityFrameworkCore;
using PRJGBS.Models;

namespace PRJGBS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Player> Player { get; set; }
        public DbSet<SaveState> SaveState { get; set; }
        public DbSet<NPC> Npc { get; set; }
        public DbSet<NPCDialogue> NpcDialogue { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
    }
}