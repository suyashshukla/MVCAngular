using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCAngular.Models;
using PetaPoco;

namespace MVCAngular.DI
{
  public class DataService : DataInterface
  {

    Database dataContext;
  

    public DataService(string connString)
    {
      dataContext = new Database(connString);
    }


    public IEnumerable<Contacts> Get()
    {
      return dataContext.Query<Contacts>("SELECT * FROM contacts");
    }

    public IEnumerable<Contacts> GetQuery(string query)
    {
      return dataContext.Query<Contacts>("SELECT * FROM contacts WHERE name LIKE '%" + query + "%'");
    }

    public Contacts GetContact(int id)
    {
      return dataContext.Single<Contacts>("SELECT * FROM contacts WHERE id=@0", id);
    }

    public bool PostContact(Contacts contact)
    {
      return dataContext.Insert(contact) != null ? true : false;
    }

    public bool PutContact(Contacts contact)
    {
      return dataContext.Update(contact) == 1;
    }

    public bool DeleteContact(int id)
    {
      return dataContext.Delete(GetContact(id)) == 1;
    }







  }
}
