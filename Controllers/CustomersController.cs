using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarriageHall.BOL;
using MarriageHall.DAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarriageHall.Controllers
{
  [Route("api/[controller]")]
  public class CustomersController : Controller
  {
    private readonly HallBookingContext _context;

    // HallbookingContext object will be injected by dotnet core engine
    // Configuration for this is written in startup.cs file
    // This is called dependency injection
    public CustomersController(HallBookingContext context)
    {
      _context = context;
    }

    // GET: api/<controller>
    [HttpGet]
    public IActionResult Get()
    {
      var result = _context.Customer.ToList();
      return Ok(result);
    }

    // GET api/<controller>/5
    [HttpGet("{id}")]
    public Customer Get(int id)
    {
      // here id is customerId (primary key from table)
      return _context.Customer.Find(id);
    }

    // POST api/<controller>
    //[HttpPost]
    //public void Post([FromBody]Customer value)
    //{

    //}

    [HttpPost("login")]
    public IActionResult Login([FromBody] Customer customer)
    {
      var result = _context.Customer.FirstOrDefault(c => c.UserName == customer.UserName && c.Password == customer.Password);
      if (result == null)
        return NotFound();
      return Ok(result);
    }

    [HttpPost]
    public IActionResult CreateCustomer([FromBody] Customer customer)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      _context.Customer.Add(customer);
      _context.SaveChanges();

      var result = _context.Customer.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
      result.Password = null;
      return Ok(result);
    }

    // PUT api/<controller>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]string value)
    {
    }

    // DELETE api/<controller>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
