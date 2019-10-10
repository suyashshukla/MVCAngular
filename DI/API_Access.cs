using MVCAngular.Interfaces;
using MVCAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MVCAngular.DI
{
  public class API_Access : IAPIService
  {

    IDB_Interface database;

    public API_Access(IDB_Interface database)
    {
      this.database = database;
    }

    //READ ALL
    [HttpGet]
    public IEnumerable<Home> getAllContacts()
    {
      return database.list();
    }

    //READ
    [HttpGet]
    public Home getContact(int id)
    {
      return database.read(id);
    }

    //CREATE
    [HttpPost]
    public bool create([FromBody] Home contact)
    {
      return database.create(contact);
    }

    //UPDATE
    [HttpPut]
    public bool update(Home contact)
    {
      return database.update(contact);
    }

    //DELETE
    [HttpDelete]
    public bool delete(int id)
    {
      return database.delete(id);
    }

    public IEnumerable<Home> getQueryContacts(string query)
    {
      return database.suggestionList(query);
    }

   
  }


}

