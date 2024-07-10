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
    public class CategoryRepository : GenericRepository<Productcategory>
    {

        public CategoryRepository() { }
        public CategoryRepository(Net1814_212_3_DiamondContext context) => _context = context;

        public Task DetachCategory(Productcategory productcategory)
        {
            if (productcategory != null)
            {
                _context.Entry(productcategory).State = EntityState.Detached;
            }

            return Task.CompletedTask;
        }
    }
}
