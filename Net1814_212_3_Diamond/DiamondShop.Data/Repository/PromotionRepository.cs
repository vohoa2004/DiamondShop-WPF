using DiamondShop.Data.Base;
using DiamondShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiamondShop.Data.Repository
{
    public class PromotionRepository : GenericRepository<Promotion>
    {
        public PromotionRepository() { }
        public PromotionRepository(Net1814_212_3_DiamondContext context) => _context = context;
       

    }
}
