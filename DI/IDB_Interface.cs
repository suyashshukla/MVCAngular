using MVCAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAngular.DI
{
  public interface IDB_Interface
  {

    bool create(Home contact);

    Home read(int id);

    bool update(Home contact);

    bool delete(int id);

    IEnumerable<Home> list();

    IEnumerable<Home> suggestionList(string query);
  }
}
