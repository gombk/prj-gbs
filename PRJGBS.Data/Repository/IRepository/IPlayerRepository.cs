using PRJGBS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRJGBS.Data.Repository.IRepository
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Task<Player> UpdateAsync(Player entity);
    }
}
