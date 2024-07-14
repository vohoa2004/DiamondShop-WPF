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

        public async Task<List<Productcategory>> SearchByFieldsAsync(
        Productcategory product)
        {
            var query = _context.Set<Productcategory>().AsQueryable();
            if (!string.IsNullOrEmpty(product.CategoryId))
                query = query.Where(c => c.CategoryId.Contains(product.CategoryId));

            if (!string.IsNullOrEmpty(product.Name))
                query = query.Where(c => c.Name.Contains(product.Name));

            if (!string.IsNullOrEmpty(product.Description))
                query = query.Where(c => c.Description.Contains(product.Description));

            if (!string.IsNullOrEmpty(product.IconUrl))
                query = query.Where(c => c.IconUrl.Contains(product.IconUrl));

            if (!string.IsNullOrEmpty(product.PromotionImageUrl))
                query = query.Where(c => c.PromotionImageUrl.Contains(product.PromotionImageUrl));

            if (product.IsFeatured.HasValue)
                query = query.Where(c => c.IsFeatured == product.IsFeatured);

            if (!string.IsNullOrEmpty(product.PromotionalTagline))
                query = query.Where(c => c.PromotionalTagline.Contains(product.PromotionalTagline));

            if (product.ProductAmount != -1)
                query = query.Where(c => c.ProductAmount == product.ProductAmount);

            if (!string.IsNullOrEmpty(product.CareInstructions))
                query = query.Where(c => c.CareInstructions.Contains(product.CareInstructions));

            if (product.MinimumPrice != 0)
                query = query.Where(c => c.MinimumPrice >= product.MinimumPrice);

            if (product.MaximumPrice != 0)
                query = query.Where(c => c.MaximumPrice <= product.MaximumPrice);

            return await query.ToListAsync();
        }
    }
}
