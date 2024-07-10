using DiamondShop.Data.Base;
using DiamondShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.Data.Repository
{
    public class OrderRepository : GenericRepository<Order>
    {
        public OrderRepository() 
        {

        }
        public OrderRepository(Net1814_212_3_DiamondContext context) => _context = context;
    }
}
