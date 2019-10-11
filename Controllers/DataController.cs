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
    IAPIService IAPIInterface;

    public DataController(IAPIService IAPIInterface)
    {
      this.IAPIInterface = IAPIInterface;
    }

    //READ ALL
    [HttpGet]
    public IEnumerable<Home> getAllContacts()
    {
      return IAPIInterface.getAllContacts();
    }


    public IEnumerable<Home> getSomeContacts(string query)
    {
      return IAPIInterface.getQueryContacts(query);
    }

    //READ SOME

    //READ ONE
    [HttpGet]
    public IHttpActionResult getContact(int id)
    {
      return Ok(IAPIInterface.getContact(id));
    }

    //CREATE
    [HttpPost]
    public IHttpActionResult create([FromBody] Home contact)
    {
      return Ok(IAPIInterface.create(contact));
    }

    //UPDATE
    [HttpPut]
    public IHttpActionResult update(Home contact)
    {
      return Ok(IAPIInterface.update(contact));
    }

    //DELETE
    [HttpDelete]
    public IHttpActionResult delete(int id)
    {
      return Ok(IAPIInterface.delete(id));
    }
  }
}