using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MarriageHall.BOL;
using MarriageHall.Controllers.Resources;
using MarriageHall.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarriageHall.Controllers
{
  [Route("api/users")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly HallBookingContext _context;
    private readonly IMapper _mapper;

    public UsersController(HallBookingContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    [HttpGet]
    public IActionResult Get()
    {
      var result = _context.Customers.Include(c => c.User).ToList();
      var crList = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(result);

      return Ok(crList);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserResource user)
    {
      var result = _context.Users.FirstOrDefault(c => c.UserName == user.UserName && c.Password == user.Password);
      if (result == null)
        return NotFound();
      var ur = _mapper.Map<User, UserResource>(result);

      return Ok(ur);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] CustomerResource customerResource)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);
      User result = new User();
      if (customerResource.User.Role == "customer" || customerResource.User.Role == "")
      {
        var customer = _mapper.Map<CustomerResource, Customer>(customerResource);
        _context.Customers.Add(customer);
        _context.SaveChanges();
        result = _context.Users.Find(customer.User.Id);

      }

      else if (customerResource.User.Role == "admin")
      {
        var admin = _mapper.Map<CustomerResource, Admin>(customerResource);
        _context.Admins.Add(admin);
        _context.SaveChanges();
        result = _context.Users.Find(admin.User.Id);
      }

      var cr = _mapper.Map<User, UserResource>(result);
      return Ok(cr);
    }
  }
}