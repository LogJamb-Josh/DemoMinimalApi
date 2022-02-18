using Microsoft.EntityFrameworkCore;
using WebApiDemo.Entities;

namespace WebApiDemo.Services
{
    public class ServiceOrder
    {
        //Fields
        private DbContextOrder _db;


        //Constructor
        public ServiceOrder(DbContextOrder dbContext)
        {
            _db = dbContext;
        }


        //Methods
        /// <summary>
        /// Gets all Customers
        /// </summary>        
        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _db.Customers.ToListAsync();
        }

        /// <summary>
        /// Gets the customer specified by Id.
        /// </summary>
        /// <param name="id"></param>        
        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _db.Customers.Where(_ => _.CustomerId == id).FirstAsync();
        }

        /// <summary>
        /// Adds a single customer
        /// </summary>
        /// <param name="customer"></param>        
        /// <returns>The inserted customer</returns>
        public async Task<Customer> InsertCustomerAsync(Customer customer)
        {
            _db.Add(customer);
            await _db.SaveChangesAsync();
            return customer;
        }

        /// <summary>
        /// Updates the customer
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>The updated customer</returns>
        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            _db.Update(customer);
            await _db.SaveChangesAsync();
            return customer;
        }

        /// <summary>
        /// Deletes the customer specified by Id and returns it.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The deleted customer</returns>
        public async Task<Customer> DeleteCustomerAsync(int id)
        {
            var customer = await _db.Customers.Where(_ => _.CustomerId == id).FirstAsync();
            _db.Remove(customer);
            await _db.SaveChangesAsync();
            return customer;
        }

    }
}
