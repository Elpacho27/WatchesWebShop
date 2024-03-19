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
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context):base(context)
        { 
            _context = context;
        }
      

        public void Update(Product product)
        {
           _context.Update(product);
        }
    }
}
