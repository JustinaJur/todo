using DotnetWebApiWithEFCodeFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetWebApiWithEFCodeFirst.Controllers
{
    [Route("api/[controller]")]
    // arba  [Route("api/[customer]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly SampleDBContext _context;

        // konstruktorius
        // atnesam db
        public CustomerController(SampleDBContext context)
        {
            _context = context;

            var stocks = _context.Customer.ToList();
        }


        // GET: api/Customer
        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            return _context.Customer.ToList();
        }

        // GET: api/Customer/1
        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id)
        /// public ActionResult GetCustomer([FromRoute]int id)
        {

            var customer = _context.Customer.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
            // return Ok(customer);
        }

        // POST: api/Customer
        [HttpPost]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            _context.Customer.Add(customer);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.CustomerId }, customer);
        }
    }
}