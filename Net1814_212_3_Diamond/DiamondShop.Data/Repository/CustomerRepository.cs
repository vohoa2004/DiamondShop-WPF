using DiamondShop.Data.Base;
using DiamondShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Net;
using System.Reflection;



namespace DiamondShop.Data.Repository
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public CustomerRepository()
        {
        }
           public CustomerRepository(Net1814_212_3_DiamondContext context) => _context = context;
        //     public IEnumerable<Customer> SearchCustomers(
        //    string customerId = null,
        //    string email = null,
        //    string lastName = null,
        //    string firstName = null,
        //    string address = null,
        //    string phoneNumber = null,
        //    DateOnly? dateOfBirth = null,
        //    string gender = null,
        //    bool? isActive = null,
        //    string country = null)
        //     {
        //         var query = _context.Customers.AsQueryable();

        //         if (!string.IsNullOrWhiteSpace(customerId))
        //             query = query.Where(c => c.CustomerId.Contains(customerId));

        //         if (!string.IsNullOrWhiteSpace(email))
        //             query = query.Where(c => c.Email.Contains(email));

        //         if (!string.IsNullOrWhiteSpace(lastName))
        //             query = query.Where(c => c.LastName.Contains(lastName));

        //         if (!string.IsNullOrWhiteSpace(firstName))
        //             query = query.Where(c => c.FirstName.Contains(firstName));

        //         if (!string.IsNullOrWhiteSpace(address))
        //             query = query.Where(c => c.Address.Contains(address));

        //         if (!string.IsNullOrWhiteSpace(phoneNumber))
        //             query = query.Where(c => c.PhoneNumber.Contains(phoneNumber));

        //         if (dateOfBirth.HasValue)
        //             query = query.Where(c => c.DateOfBirth == (DateOnly?)dateOfBirth.Value);

        //         if (!string.IsNullOrWhiteSpace(gender))
        //             query = query.Where(c => c.Gender == gender);

        //         if (isActive.HasValue)
        //             query = query.Where(c => c.IsActive == isActive);

        //         if (!string.IsNullOrWhiteSpace(country))
        //             query = query.Where(c => c.Country.Contains(country));

        //         return query.ToList();
        //     }
        //     public async Task<List<Customer>> SearchByFieldsAsync(
        //        string? customerId = null,
        //        string email = null,
        //        string lastName = null,
        //        string firstName = null,
        //        string address = null,
        //        string phoneNumber = null,
        //        DateOnly? dateOfBirth = null,
        //        bool? isActive = null,
        //        string gender = null,
        //        string country = null
        //         )
        //     {
        //         return await SearchByFieldsAsync(new Customer()
        //         {
        //             CustomerId = customerId,
        //             Email = email,
        //             LastName = lastName,
        //             FirstName = firstName,
        //             Address = address,
        //             PhoneNumber = phoneNumber,
        //             DateOfBirth = dateOfBirth,
        //             IsActive = isActive,
        //             Country = country,
        //             Gender = gender
        //         });
        //     }

        public async Task<List<Customer>> SearchByFieldsAsync(Customer customer)
        {
            var query = _context.Set<Customer>().AsQueryable();

            if (!string.IsNullOrWhiteSpace(customer.CustomerId))
                query = query.Where(c => c.CustomerId.Contains(customer.CustomerId));

            if (!string.IsNullOrWhiteSpace(customer.Email))
                query = query.Where(c => c.Email.Contains(customer.Email));

            if (!string.IsNullOrWhiteSpace(customer.LastName))
                query = query.Where(c => c.LastName.Contains(customer.LastName));

            if (!string.IsNullOrWhiteSpace(customer.FirstName))
                query = query.Where(c => c.FirstName.Contains(customer.FirstName));

            if (!string.IsNullOrWhiteSpace(customer.Address))
                query = query.Where(c => c.Address.Contains(customer.Address));

            if (!string.IsNullOrWhiteSpace(customer.PhoneNumber))
                query = query.Where(c => c.PhoneNumber.Contains(customer.PhoneNumber));

            if (customer.DateOfBirth.HasValue)
                query = query.Where(c => c.DateOfBirth == customer.DateOfBirth);

            if (!string.IsNullOrWhiteSpace(customer.Gender))
                query = query.Where(c => c.Gender.Contains(customer.Gender));

            if (customer.IsActive.HasValue)
                query = query.Where(c => c.IsActive == customer.IsActive);

            if (!string.IsNullOrWhiteSpace(customer.Country))
                query = query.Where(c => c.Country == customer.Country);

            return await query.ToListAsync();
        }

    }
}

