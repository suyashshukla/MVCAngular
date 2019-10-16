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

    public IEnumerable<Contacts> Get()
    {
      return contactService.Get();
    }

    public IEnumerable<Contacts> GetQuery(string query)
    {
      return contactService.GetQuery(query);
    }

    public IHttpActionResult GetContact(int id)
    {
      return Ok(contactService.GetContact(id));
    }

    public IHttpActionResult Post([FromBody] Contacts contact)
    {
      return Ok(contactService.Post(contact));
    }

    public IHttpActionResult Put(Contacts contact)
    {
      return Ok(contactService.Put(contact));
    } 

    public IHttpActionResult Delete(int id)
    {
      return Ok(contactService.Delete(id));
    }
  }
}
