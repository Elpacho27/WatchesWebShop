using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchesWebShop.DataAccess.Data;
using WatchesWebShop.DataAccess.Repository.IRepository;

namespace WatchesWebShop.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private ApplicationDbContext _context;

    public ICategoryRepository Category { get; private set; }
    public IProductRepository Product { get; private set; }

    public ICompanyRepository Company { get; private set; }

    public IApplicationUserRepository ApplicationUser { get; private set; }

    public IShoppingCartRepository ShoppingCart { get; private set; }

    public IOrderHeaderRepository OrderHeader { get; private set; }

    public IOrderDetailRepository OrderDetail { get; private set; }
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        Category = new CategoryRepository(context);
        Product = new ProductRepository(context);
        Company=new CompanyRepository(context);
        ApplicationUser = new ApplicationUserRepository(_context);
        ShoppingCart = new ShoppingCartRepository(_context);
        OrderHeader = new OrderHeaderRepository(_context);
        OrderDetail=new OrderDetailRepository(_context);
    }

    public void Save()
    {
       _context.SaveChanges();
    }
}
