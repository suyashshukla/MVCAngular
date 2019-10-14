using MVCAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAngular.DI
{
  public interface DataInterface
  {

    bool create(Contacts contact);

    Contacts read(int id);

    bool update(Contacts contact);

    bool delete(int id);

    IEnumerable<Contacts> list();

    IEnumerable<Contacts> suggestionList(string query);
  }
}
