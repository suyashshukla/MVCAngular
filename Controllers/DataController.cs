using MVCAngular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVCAngular.Controllers
{
  public class DataController : ApiController
  {

    Home[] contacts = new Home[]

    {
        new Home{id = 1, name = "Ronny",
          email = "ronnyjacobs@tuffle.com",
          address ="Paulo Alto,California",
          landline ="+1 5265845",
          phone ="+1 7485692130",
          website = "ronny.jacobs.com" },

        new Home{id = 2,
          name = "Jamie",
          email = "j_taylor@ringer.com",
          address ="Manchester, England",
          landline ="+5 8745962",
          phone ="+5 6958236541",
          website = "www.jamiealter.co.us" },

        new Home{id = 3,
          name = "Hamish",
          email = "rodriguez@gbin.co.uk",
          address ="Downtown Suburbs, Columbia",
          landline ="+45 6985324",
          phone ="+45 1452369874",
          website = "hamish.wordpress.com" },

        new Home{id = 4,
          name = "Stewart",
          email = "alex123@gatsby.us",
          address ="Somersetville,Belfast,UK",
          landline ="+11 2547896",
          phone ="+11 4523658965",
          website = "alex.wixsite.com" },

        new Home{id = 5,
          name = "Alan",
          email = "donald_alan@protea.com",
          address ="East London Cottage, Port Elizabeth, South Africa",
          landline ="+33 7898456",
          phone ="+33 7896541250",
          website = "www.donalan.pr"}

      };


    //READ ALL
    [HttpGet]
    public IEnumerable<Home> getAllContacts()
    {
      var dataContext = new PetaPoco.Database("sqladdress");
      var contacts = dataContext.Query<Home>("SELECT * FROM contacts;");

      return contacts;
    }

    //READ
    [HttpGet]
    public IHttpActionResult getContact(int id)
    {
      var dataContext = new PetaPoco.Database("sqladdress");
      try
      {
        var contact = dataContext.Single<Home>("SELECT * FROM contacts WHERE id=@0", id);
        return Ok(contact);
      }
      catch
      {
        return NotFound();
      }
    }

    //CREATE
    [HttpPost]
    public IHttpActionResult create([FromBody] Home contact)
    {
      var dataContext = new PetaPoco.Database("sqladdress");
      return Ok(dataContext.Insert(contact));
    }

    //UPDATE
    [HttpPut]
    public IHttpActionResult update(Home contact)
    {
      var dataContext = new PetaPoco.Database("sqladdress");
      return Ok(dataContext.Update(contact));
    }

    //DELETE
    [HttpDelete]
    public IHttpActionResult delete(int id)

    {
      var dataContext = new PetaPoco.Database("sqladdress");
      var contact = dataContext.Single<Home>("SELECT * FROM contacts WHERE id=@0", id);
      return Ok(dataContext.Delete(contact));
    }

    }
}
