using Microsoft.EntityFrameworkCore;
using WebApiDemo.Entities;

namespace WebApiDemo.Services
{
    public class OrderService
    {
        //Fields
        private MyContext _dbContext;


        //Constructor
        public OrderService(MyContext dbContext)
        {
            _dbContext = dbContext;
        }


        //Methods
        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _dbContext.Customers.Where(_ => _.CustomerId == id).FirstAsync();
        }

        public async Task<Customer> InsertCustomerAsync(Customer customer)
        {
            _dbContext.Add(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            _dbContext.Update(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> DeleteCustomerAsync(int id)
        {
            var customer = await _dbContext.Customers.Where(_ => _.CustomerId == id).FirstAsync();
            _dbContext.Remove(customer);
            await _dbContext.SaveChangesAsync();
            return customer;
        }

    }
}
