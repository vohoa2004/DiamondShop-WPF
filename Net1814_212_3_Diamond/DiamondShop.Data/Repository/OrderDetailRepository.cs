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
    public class OrderDetailRepository : GenericRepository<Orderdetail>
    {
        public OrderDetailRepository()
        {
        }
        public OrderDetailRepository(Net1814_212_3_DiamondContext context) => _context = context;

        public async Task<List<Orderdetail>> SearchByOrderIdAsync(string orderId)
        {
            using (var context = new Net1814_212_3_DiamondContext())
            {
                List<Orderdetail> result = await context.Orderdetails
                    .Where(od => od.OrderId == orderId)
                    .ToListAsync();

                return result;
            }
        }

        public async Task<List<Orderdetail>> SearchByFieldsAsync(Orderdetail orderdetail)
        {
            var query = _context.Set<Orderdetail>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(orderdetail.OrderDetailId))
                query = query.Where(od => od.OrderDetailId.Contains(orderdetail.OrderDetailId));

            if (!string.IsNullOrWhiteSpace(orderdetail.OrderId))
                query = query.Where(od => od.OrderId.Contains(orderdetail.OrderId));

            if (!string.IsNullOrWhiteSpace(orderdetail.MainDiamondId))
                query = query.Where(od => od.MainDiamondId.Contains(orderdetail.MainDiamondId));

            if (!string.IsNullOrWhiteSpace(orderdetail.ShellId))
                query = query.Where(od => od.ShellId.Contains(orderdetail.ShellId));

            if (!string.IsNullOrWhiteSpace(orderdetail.SubDiamondId))
                query = query.Where(od => od.SubDiamondId.Contains(orderdetail.SubDiamondId));

            if (orderdetail.LineTotal != 0)
                query = query.Where(od => od.LineTotal == orderdetail.LineTotal);

            if (orderdetail.Quantity != 0)
                query = query.Where(od => od.Quantity == orderdetail.Quantity);

            if (orderdetail.UnitWeight != 0)
                query = query.Where(od => od.UnitWeight == orderdetail.UnitWeight);

            if (orderdetail.UnitPrice != 0)
                query = query.Where(od => od.UnitPrice == orderdetail.UnitPrice);

            if (orderdetail.DiscountPercentage != 0)
                query = query.Where(od => od.DiscountPercentage == orderdetail.DiscountPercentage);

            if (!string.IsNullOrWhiteSpace(orderdetail.Note))
                query = query.Where(od => od.Note.Contains(orderdetail.Note));

            return await query.ToListAsync();
        }
    }
}
