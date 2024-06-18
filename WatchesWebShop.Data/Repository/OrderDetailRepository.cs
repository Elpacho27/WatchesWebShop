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
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {

        private ApplicationDbContext _context;
        public OrderDetailRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(OrderDetail orderDetail)
        {
            _context.Update(orderDetail);
        }
    }
}
