using MVCAngular.Models;
using System;
using System.Collections.Generic;
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
      
      var contacts = dataContext.Query<Home>("SELECT * FROM contacts;");

      return View(contacts);

    }
    
    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Home contact)
    {
      var dataContext = new PetaPoco.Database("sqladdress");
      dataContext.Insert(contact);

      return RedirectToAction("DBView");

    }

    public ActionResult Edit(int id)
    {
      var dataContext = new PetaPoco.Database("sqladdress");
      var data = dataContext.Single<Home>("SELECT * FROM contacts WHERE id=@0",id);

      return View(data);
    }

    [HttpGet]
    public ActionResult delete(int id)
    {
      var dataContext = new PetaPoco.Database("sqladdress");

      var contact = dataContext.Single<Home>("SELECT * FROM contacts WHERE id=@0", id);

      return View(contact);

    }

    [HttpPost]
    public ActionResult delete(int id,Home home)
    {
      var dataContext = new PetaPoco.Database("sqladdress");
      dataContext.Delete<Home>(id);

      return RedirectToAction("DBView");
    }

    public ActionResult details(int id)
    {
      var dataContext = new PetaPoco.Database("sqladdress");
      var details = dataContext.Single<Home>("SELECT * FROM contacts WHERE id=@0", id);

      return View(details);
    }

    }
}
