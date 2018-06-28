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
      CreateMap<Admin, OwnerResource>();
      CreateMap<HallOwner, OwnerResource>();



      // Api Resource to Domain Models
      CreateMap<CustomerResource, Customer>();
      CreateMap<UserResource, User>();
      CreateMap<OwnerResource, Admin>();
      CreateMap<OwnerResource, HallOwner>();

      CreateMap<CustomerResource, HallOwner>().ForSourceMember(c => c.Address, opt => opt.Ignore()).ForSourceMember(c => c.AadharNo, opt => opt.Ignore());
      CreateMap<CustomerResource, Admin>().ForSourceMember(c => c.Address, opt => opt.Ignore()).ForSourceMember(c => c.AadharNo, opt => opt.Ignore());



    }
  }
}
