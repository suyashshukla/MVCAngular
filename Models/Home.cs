using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAngular.Models
{
  [PetaPoco.TableName("contacts")]
  public class Home
  {
    public int id
    {
      get;set;
    }
    public string name
    {
      get; set;
    }
    public string email
    {
      get;set;
    }
    public string phone
    {
      get;set;
    }
    public string address
    {
      get;set;
    }
    public string website
    {
      get;set;
    }
    public string landline
    {
      get;set;
    }


  }
}
