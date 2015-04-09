using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using Data;
using Models;
using DomainModel.Abstract;
using Mvc4Architecture.Models;

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
            List<PersonTdVM> personVMs = new List<PersonTdVM>();

            foreach (Person person in persons)
            {
                personVMs.Add(new PersonTdVM
                            {
                                Person = person as Person,
                                AddressCount = person.Addresses.Count(),
                                AddressTitleString = String.Join("; ", person.Addresses.Select(a => a.Street))

                            });
            }

            return View(personVMs);
        }

        public PartialViewResult PersonDetails(int id)
        {
            Person person = _personHandler.GetPersonById(id);

            return PartialView("_PersonDetails", person);
        }

        public JsonResult GetPersonAddresses(int personId)
        {
            var addresses = _personHandler.GetPersonAddresses(personId);
            return Json(addresses, JsonRequestBehavior.AllowGet);
        }
    }
}
