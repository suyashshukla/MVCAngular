using MVCAngular.Interfaces;
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
    ContactInterface contactService;

    public DataController(ContactInterface contactService)
    {
      this.contactService = contactService;
    }

    //READ ALL
    [HttpGet]
    public IEnumerable<Contacts> GetContacts()
    {
      return contactService.getAllContacts();
    }


    public IEnumerable<Contacts> getSomeContacts(string query)
    {
      return contactService.getQueryContacts(query);
    }

    //READ SOME

    //READ ONE
    [HttpGet]
    public IHttpActionResult getContact(int id)
    {
      return Ok(contactService.getContact(id));
    }

    //CREATE
    [HttpPost]
    public IHttpActionResult create([FromBody] Contacts contact)
    {
      return Ok(contactService.create(contact));
    }

    //UPDATE
    [HttpPut]
    public IHttpActionResult update(Contacts contact)
    {
      return Ok(contactService.update(contact));
    }

    //DELETE
    [HttpDelete]
    public IHttpActionResult delete(int id)
    {
      return Ok(contactService.delete(id));
    }
  }
}
