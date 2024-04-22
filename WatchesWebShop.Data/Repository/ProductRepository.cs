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
            var productInDb = _context.Products.FirstOrDefault(p => p.Id == product.Id);
            if (productInDb != null)
            {
                productInDb.Brand = product.Brand;
                productInDb.Series = product.Series;
                productInDb.ModelNumber = product.ModelNumber;
                productInDb.Price = product.Price;
                productInDb.CategoryID = product.CategoryID;
                if (productInDb.ImageURL != null)
                {
                    productInDb.ImageURL = product.ImageURL;
                }
            }
        }

        public IEnumerable<Product> GetProductsByType(string type)
        {
            if (type == "All")
            {
                return _context.Products.ToList();
            }
            else
            {
                return _context.Products.Where(p => p.Brand == type).ToList();
            }
        }
    }
}
