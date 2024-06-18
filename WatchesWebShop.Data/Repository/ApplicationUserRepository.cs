using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchesWebShop.DataAccess.Data;
using WatchesWebShop.DataAccess.Repository.IRepository;
using WatchesWebShop.Models.Models;

namespace WatchesWebShop.DataAccess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _context;
        public ApplicationUserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(ApplicationUser applicationUser)
        {
            _context.Update(applicationUser);
        }


    }
}
