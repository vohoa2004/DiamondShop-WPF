using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiamondShop.Data.Base;
using DiamondShop.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DiamondShop.Data.Repository
{
	public class ShellRepository : GenericRepository<Shell>
	{
		public ShellRepository() { }

		public ShellRepository(Net1814_212_3_DiamondContext context) => _context = context;

		///////TO-DO CODE HERE//////
		///
		public async Task<List<Shell>> GetAllAsync()
		{
			return await _context.Set<Shell>().Include(s => s.Category).ToListAsync();
		}

		public async Task<Shell> GetByIdAsync(string id)
		{
			return await _context.Set<Shell>().Include(s => s.Category).FirstOrDefaultAsync(s => s.ShellId == id);
		}

		public async Task<List<Shell>> SearchByFieldsAsync(
		Shell item)
		{
			var query = _context.Set<Shell>().Include(s => s.Category).AsQueryable();
			if (!string.IsNullOrEmpty(item.ShellId))
				query = query.Where(c => c.ShellId.Contains(item.ShellId));

			if (!string.IsNullOrEmpty(item.Name))
				query = query.Where(c => c.Name.Contains(item.Name));

			if (!string.IsNullOrEmpty(item.Description))
				query = query.Where(c => c.Description.Contains(item.Description));

			if (!string.IsNullOrEmpty(item.CategoryId))
				query = query.Where(c => c.CategoryId.Contains(item.CategoryId));

			if (!string.IsNullOrEmpty(item.DiamondShape))
				query = query.Where(c => c.DiamondShape.Contains(item.DiamondShape));

			if (!string.IsNullOrEmpty(item.Metal))
				query = query.Where(c => c.Metal.Contains(item.Metal));

			if (!string.IsNullOrEmpty(item.ImageUrl))
				query = query.Where(c => c.ImageUrl.Contains(item.ImageUrl));

			if (item.Price >= 0)
				query = query.Where(c => c.Price == item.Price);

			if (item.Weight >= 0)
				query = query.Where(c => c.Weight == item.Weight);

			if (item.TotalDiamonds >= 0)
				query = query.Where(c => c.TotalDiamonds == item.TotalDiamonds);

			if (item.AmountAvailable >= 0)
				query = query.Where(c => c.AmountAvailable == item.AmountAvailable);

			return await query.ToListAsync();
		}
	}
}
