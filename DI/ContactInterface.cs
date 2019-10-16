using MVCAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAngular.Interfaces
{

  public interface ContactInterface

  {

    IEnumerable<Contacts> Get();

    IEnumerable<Contacts> GetQuery(string query);

    Contacts GetContact(int id);

    bool Put(Contacts contact);

    bool Post(Contacts contact);

    bool Delete(int id);

    
  }

}
