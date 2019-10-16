using MVCAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAngular.DI
{
  public interface DataInterface
  {

    IEnumerable<Contacts> Get();

    IEnumerable<Contacts> GetQuery(string query);

    Contacts GetContact(int id);

    bool PostContact(Contacts contact);
    
    bool PutContact(Contacts contact);

    bool DeleteContact(int id);

  }
}
