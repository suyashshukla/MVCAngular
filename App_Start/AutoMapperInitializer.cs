using AutoMapper;
using MVCAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAngular.App_Start
{
  public class AutoMapperInitializer
  {

    static IMapper mapper;

    public static IMapper getMapper()
    {
      return mapper;
    }

    public static void InitializeMapper()
    {

      var config = new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<ContactsMapper, Contacts>()
        .ForMember(h => h.address, hm => hm.MapFrom(m => m.house + m.street + m.locality + m.state + m.country))
        .ForMember(h => h.name, hm => hm.MapFrom(m => m.firstName + " " + m.lastName)).ReverseMap();
      });

      mapper = config.CreateMapper();
    }
  }
}
