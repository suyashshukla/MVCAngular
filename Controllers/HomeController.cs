using AutoMapper;
using MVCAngular.App_Start;
using MVCAngular.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAngular.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
      return View();
        }

    public ActionResult DBView()
    {

      var dataContext = new PetaPoco.Database("sqladdress");
      
      var contacts = dataContext.Query<Contacts>("SELECT * FROM contacts;");

      return View(contacts);

    }
    
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(ContactsMapper mContact)
    {

      IMapper mapper = AutoMapperInitializer.getMapper();

      var contact = mapper.Map<Contacts>(mContact);

      var back = mapper.Map<ContactsMapper>(contact);

      var dataContext = new PetaPoco.Database("sqladdress");
      dataContext.Insert(contact);

      return RedirectToAction("Index");

    }

    public ActionResult Edit(int id)
    {

      var dataContext = new PetaPoco.Database("sqladdress");
      var data = dataContext.Single<Contacts>("SELECT * FROM contacts WHERE id=@0",id);

      return View(data);

    }

    [HttpPost]
    public ActionResult Edit(Contacts contact)
    {
      var dataContext = new PetaPoco.Database("sqladdress");
      dataContext.Update("contacts", "id", contact);

      return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult delete(int id)
    {
      var dataContext = new PetaPoco.Database("sqladdress");

      var contact = dataContext.Single<Contacts>("SELECT * FROM contacts WHERE id=@0", id);

      return View(contact);
    }

    [HttpPost]
    public ActionResult delete(int id,Contacts home)
    {
      var dataContext = new PetaPoco.Database("sqladdress");
      dataContext.Delete<Contacts>(id);

      return RedirectToAction("DBView");
    }

    public ActionResult details(int id)
    {
      var dataContext = new PetaPoco.Database("sqladdress");
      var details = dataContext.Single<Contacts>("SELECT * FROM contacts WHERE id=@0", id);

      return View(details);
    }

    }
}
