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
    public class DiamondRepository : GenericRepository<Diamond>
    {
        public DiamondRepository() { }
        public DiamondRepository(Net1814_212_3_DiamondContext context) => _context = context;


        ///TO-DO CODE HERE//////////////////////////////
        public new async Task<IEnumerable<Diamond>> GetAllAsync()
        {
            return await _context.Diamonds
                                 .Include(d => d.Category)
                                 .AsNoTracking()
                                 .ToListAsync();
        }


        public new async Task<Diamond> GetByIdAsync(string code)
        {
            return await _context.Diamonds
                                 .Include(d => d.Category)
                                    .FirstOrDefaultAsync(d => d.DiamondId == code);
        }

        public async Task<IEnumerable<Diamond>> SearchAsync(Diamond criteria)
        {
            IQueryable<Diamond> query = _context.Set<Diamond>().Include(d => d.Category);

            if (!string.IsNullOrEmpty(criteria.DiamondId))
            {
                query = query.Where(d => d.DiamondId.Contains(criteria.DiamondId));
            }

            if (!string.IsNullOrEmpty(criteria.Name))
            {
                query = query.Where(d => d.Name.Contains(criteria.Name));
            }

            if (!string.IsNullOrEmpty(criteria.Color))
            {
                query = query.Where(d => d.Color.Contains(criteria.Color));
            }

            if (criteria.DateAcquired.HasValue)
            {
                query = query.Where(d => d.DateAcquired == criteria.DateAcquired.Value);
            }

            if (criteria.Cost.HasValue)
            {
                query = query.Where(d => d.Cost == criteria.Cost.Value);
            }

            if (!string.IsNullOrEmpty(criteria.Clarity))
            {
                query = query.Where(d => d.Clarity.Contains(criteria.Clarity));
            }

            if (criteria.Carat.HasValue)
            {
                query = query.Where(d => d.Carat == criteria.Carat.Value);
            }

            if (!string.IsNullOrEmpty(criteria.Cut))
            {
                query = query.Where(d => d.Cut.Contains(criteria.Cut));
            }

            if (!string.IsNullOrEmpty(criteria.CertificateScan))
            {
                query = query.Where(d => d.CertificateScan.Contains(criteria.CertificateScan));
            }

            if (!string.IsNullOrEmpty(criteria.CertifyingAuthority))
            {
                query = query.Where(d => d.CertifyingAuthority.Contains(criteria.CertifyingAuthority));
            }

            if (criteria.AmountAvailable.HasValue)
            {
                query = query.Where(d => d.AmountAvailable == criteria.AmountAvailable.Value);
            }

            if (!string.IsNullOrEmpty(criteria.Symmetry))
            {
                query = query.Where(d => d.Symmetry.Contains(criteria.Symmetry));
            }

            if (!string.IsNullOrEmpty(criteria.Polish))
            {
                query = query.Where(d => d.Polish.Contains(criteria.Polish));
            }

            if (!string.IsNullOrEmpty(criteria.Fluorescence))
            {
                query = query.Where(d => d.Fluorescence.Contains(criteria.Fluorescence));
            }

            if (!string.IsNullOrEmpty(criteria.CategoryId))
            {
                query = query.Where(d => d.CategoryId == criteria.CategoryId);
            }

            return await query.ToListAsync();
        }

    }
}
