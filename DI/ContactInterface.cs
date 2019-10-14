using MVCAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAngular.Interfaces
{
  public interface ContactInterface
  {

    IEnumerable<Contacts> getAllContacts();

    IEnumerable<Contacts> getQueryContacts(string query);

    Contacts getContact(int id);

    bool create(Contacts contact);

    bool delete(int id);

    bool update(Contacts contact);
    
  }
}
