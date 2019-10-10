using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCAngular.Models;

namespace MVCAngular.DI
{
  public class IDB_Access : IDB_Interface
  {

    PetaPoco.Database dataContext = new PetaPoco.Database("sqladdress");

    public bool create(Home contact)
    {
      return dataContext.Insert(contact) != null ? true : false;
    }

    public bool delete(int id)
    {
      return dataContext.Delete(read(id)) == 1;
    }

    public IEnumerable<Home> list()
    {
      return dataContext.Query<Home>("SELECT * FROM contacts");
    }

    public Home read(int id)
    {
      return dataContext.Single<Home>("SELECT * FROM contacts WHERE id=@0", id);
    }

    public IEnumerable<Home> suggestionList(string query)
    {
      return dataContext.Query<Home>("SELECT * FROM contacts WHERE name LIKE '%"+query+"%'");
    }

    public bool update(Home contact)
    {
      return dataContext.Update(contact)==1;
    }



  }
}
