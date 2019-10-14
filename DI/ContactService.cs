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

    //READ ALL
    [HttpGet]
    public IEnumerable<Contacts> getAllContacts()
    {
      return database.list();
    }

    //READ
    [HttpGet]
    public Contacts getContact(int id)
    {
      return database.read(id);
    }

    //CREATE
    [HttpPost]
    public bool create([FromBody] Contacts contact)
    {
      return database.create(contact);
    }

    //UPDATE
    [HttpPut]
    public bool update(Contacts contact)
    {
      return database.update(contact);
    }

    //DELETE
    [HttpDelete]
    public bool delete(int id)
    {
      return database.delete(id);
    }

    public IEnumerable<Contacts> getQueryContacts(string query)
    {
      return database.suggestionList(query);
    }

   
  }


}

