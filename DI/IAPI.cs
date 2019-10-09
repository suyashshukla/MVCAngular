using MVCAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAngular.Interfaces
{
  public interface IAPI
  {

    IEnumerable<Home> getAllContacts();

    Home getContact(int id);

    bool create(Home contact);

    bool delete(int id);

    bool update(Home contact);


  }
}
