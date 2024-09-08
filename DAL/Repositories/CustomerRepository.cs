using DAL.Interfaces;
using DAL.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Newtonsoft.Json.Linq;

namespace DAL.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LaboratoryContext _context;
        private HttpClient _client;

        public CustomerRepository(LaboratoryContext context)
        {
            _context = context;
            _client = new HttpClient();
            var byteArray = Encoding.ASCII.GetBytes("gvia:gvia"); // החלף בפרטי ההזדהות המתאימים
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int customerId)
        {
            return _context.Customers.Find(customerId);
        }

        public async Task InsertOrUpdateCustomer(Customer customer)
        {
            var existingCustomer = _context.Customers
                .FirstOrDefault(c => c.Email.Equals(customer.Email, StringComparison.OrdinalIgnoreCase));

            if (existingCustomer != null)
            {
                Console.WriteLine("Customer already exists in the system.");
                return;
            }

            var url = $"https://api.icount.co.il/api/v3.php/client/get_list?cid=kenionLTD&user=gvia&pass=gvia&email={customer.Email}";
            HttpResponseMessage response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(content);
                if (data.ContainsKey("clients") && data["clients"] is JObject clientsObj && clientsObj.Count > 0)
                {
                    var clientsDict = clientsObj.ToObject<Dictionary<string, dynamic>>();
                    dynamic clientData = clientsDict.Values.FirstOrDefault();

                    if (clientData != null && clientData.email != null && clientData.email.ToString().Trim().Equals(customer.Email.Trim(), StringComparison.OrdinalIgnoreCase))
                    {
                        var updatedCustomer = new Customer
                        {
                            FullName = clientData.client_name != null ? clientData.client_name.ToString().Trim() : "",
                            Email = clientData.email.ToString().Trim(),
                            Phone = "לא זמין"
                        };

                        await AddCustomerAsync(updatedCustomer);
                    }
                    else
                    {
                        await AddCustomerAsync(customer);
                    }
                }
                else
                {
                    await AddCustomerAsync(customer);
                }
            }
            else
            {
                await AddCustomerAsync(customer);
            }
        }

        private async Task AddCustomerAsync(Customer customer)
        {
            using (var context = new LaboratoryContext())
            {
                try
                {
                    context.Customers.Add(customer);
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }


        public void DeleteCustomer(int customerId)
        {
            var customer = _context.Customers.Find(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            var existingCustomer = _context.Customers.Find(customer.Id);
            if (existingCustomer != null)
            {
                _context.Entry(existingCustomer).CurrentValues.SetValues(customer);
            }
            _context.SaveChanges();
        }

    }
}
