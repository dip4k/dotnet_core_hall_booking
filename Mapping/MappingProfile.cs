using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MarriageHall.BOL;
using MarriageHall.Controllers.Resources;

namespace MarriageHall.Mapping
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      // Domain Models to Api Resource
      CreateMap<Customer, CustomerResource>();
      CreateMap<User, UserResource>();



      // Api Resource to Domain Models
      CreateMap<CustomerResource, Customer>();
      CreateMap<UserResource, User>();


    }
  }
}
