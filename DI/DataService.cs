using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCAngular.Models;

namespace MVCAngular.DI
{
  public class DataService : DataInterface
  {

    PetaPoco.Database dataContext = new PetaPoco.Database("sqladdress");

    public bool create(Contacts contact)
    {
      return dataContext.Insert(contact) != null ? true : false;
    }

    public bool delete(int id)
    {
      return dataContext.Delete(read(id)) == 1;
    }

    public IEnumerable<Contacts> list()
    {
      return dataContext.Query<Contacts>("SELECT * FROM contacts");
    }

    public Contacts read(int id)
    {
      return dataContext.Single<Contacts>("SELECT * FROM contacts WHERE id=@0", id);
    }

    public IEnumerable<Contacts> suggestionList(string query)
    {
      return dataContext.Query<Contacts>("SELECT * FROM contacts WHERE name LIKE '%"+query+"%'");
    }

    public bool update(Contacts contact)
    {
      return dataContext.Update(contact)==1;
    }



  }
}
