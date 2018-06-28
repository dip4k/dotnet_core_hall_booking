//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using AutoMapper;
//using MarriageHall.BOL;
//using MarriageHall.Controllers.Resources;
//using MarriageHall.DAL;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace MarriageHall.Controllers
//{
//  [Route("api/[controller]")]
//  public class CustomersController : Controller
//  {
//    private readonly HallBookingContext _context;
//    private readonly IMapper _mapper;

//    // HallbookingContext object will be injected by dotnet core engine
//    // Configuration for this is written in startup.cs file
//    // This is called dependency injection
//    public CustomersController(HallBookingContext context, IMapper mapper)
//    {
//      _context = context;
//      _mapper = mapper;
//    }

//    // GET: api/<controller>


//    // GET api/<controller>/5
//    [HttpGet("{id}")]
//    public Customer Get(int id)
//    {
//      // here id is customerId (primary key from table)
//      return _context.Customers.Find(id);
//    }



//    [HttpPost]
//    public IActionResult CreateCustomer([FromBody] CustomerResource customerResource)
//    {
//      if (!ModelState.IsValid)
//        return BadRequest(ModelState);
//      var customer = _mapper.Map<CustomerResource, Customer>(customerResource);
//      _context.Customers.Add(customer);
//      _context.SaveChanges();

//      var result = _context.Customers.Include(c => c.User).FirstOrDefault(c => c.Id == customer.Id);
//      var cr = _mapper.Map<Customer, CustomerResource>(result);
//      return Ok(cr);
//    }

//    // PUT api/<controller>/5
//    [HttpPut("{id}")]
//    public void Put(int id, [FromBody]string value)
//    {
//    }

//    // DELETE api/<controller>/5
//    [HttpDelete("{id}")]
//    public void Delete(int id)
//    {
//    }
//  }
//}
