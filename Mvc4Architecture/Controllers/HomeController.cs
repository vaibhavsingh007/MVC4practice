using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using Data;
using Models;
using DomainModel.Abstract;

namespace Mvc4Architecture.Controllers
{
    public class HomeController : BaseController
    {
        private IPersonHandler _personHandler;

        public HomeController(IServiceLocator serviceLocator, IPersonHandler personHandler)
            : base(serviceLocator)
        {
            _personHandler = personHandler;
        }

        public ActionResult Index()
        {
            IEnumerable<Person> persons = _personHandler.GetAllPersons();
            return View(persons);
        }

        public PartialViewResult PersonDetails(int id)
        {
            Person person = _personHandler.GetPersonById(id);

            return PartialView("_PersonDetails", person);
        }

    }
}
