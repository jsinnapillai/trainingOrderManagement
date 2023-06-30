using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API.GraphQL
{
    public class Query
    {
        [UseFiltering]
        public IQueryable<Customer> GetCustomers([Service] OMAContext context)
        {
            context.Database.EnsureCreated();
            return context.Customers
                    .Include(order => order.Orders)
                    .Include(add => add.Address)
                    ;
        }
        [UseFiltering]
        public IQueryable<Order> GetOrders([Service] OMAContext context)
        {
            context.Database.EnsureCreated();
            return context.Orders
            .Include(cs => cs.Customer)
            .ThenInclude(ad => ad.Address);
        }
    }
}
