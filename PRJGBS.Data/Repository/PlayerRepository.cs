using PRJGBS.Data.Repository.IRepository;
using PRJGBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJGBS.Data.Repository
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        private readonly ApplicationDbContext _db;

        public PlayerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<Player> UpdateAsync(Player entity)
        {
            entity.UpdatedDate = DateTime.Now;

            _db.Player.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}
