using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAngular.DI
{
  public class AutoMapperService
  {

    private IMapper mapper;

    public AutoMapperService(IMapper iMapper)
    {
      this.mapper = iMapper;
    }

  }
}
