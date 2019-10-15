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
        .ForMember(h => h.address, hm => hm.MapFrom(m => m.house +", "+ m.street +", "+ m.locality +", "+m.city+", "+ m.state +", "+ m.country))
        .ForMember(h => h.name, hm => hm.MapFrom(m => m.firstName + " " + m.lastName));


        cfg.CreateMap<Contacts, ContactsMapper>()
          .ForMember(hm => hm.firstName, h => h.MapFrom(m => m.name.Split(' ')[0]))
          .ForMember(hm => hm.lastName, h => h.MapFrom(m => m.name.Split(' ')[1]))
          .ForMember(hm => hm.house, h => h.MapFrom(m => m.address.Split(',')[0]))
          .ForMember(hm => hm.street, h => h.MapFrom(m => m.address.Split(',')[1]))
          .ForMember(hm => hm.locality, h => h.MapFrom(m => m.address.Split(',')[2]))
          .ForMember(hm => hm.city, h => h.MapFrom(m => m.address.Split(',')[3]))
          .ForMember(hm => hm.state, h => h.MapFrom(m => m.address.Split(',')[4]))
          .ForMember(hm => hm.country, h => h.MapFrom(m => m.address.Split(',')[5]));
      });

      mapper = config.CreateMapper();
    }
  }
}
