using MVCAngular.Interfaces;
using MVCAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MVCAngular.DI
{
  public class ContactService : ContactInterface
  {

    DataInterface database;

    public ContactService(DataInterface database)
    {
      this.database = database;
    }


    public IEnumerable<Contacts> Get()
    {
      return database.Get();
    }
    
    public IEnumerable<Contacts> GetQuery(string query)
    {
      return database.GetQuery(query);
    }

    public Contacts GetContact(int id)
    {
      return database.GetContact(id);
    }

    public bool Put(Contacts contact)
    {
      return database.PutContact(contact);
    }

    public bool Post([FromBody] Contacts contact)
    {
      return database.PostContact(contact);
    }

    public bool Delete(int id)
    {
      return database.DeleteContact(id);
    }


   
  }


}

