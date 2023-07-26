using System.Collections.Generic;
using CRM_System.Data.Models;
using CRM_System.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CRM_System.Controllers {
    public class ContactsController : Controller {




        public ViewResult List() {
            ViewBag.Title = "Контакты";
            ContactsViewModel obj = new ContactsViewModel();
            obj.allContacts = new List<Contact> {
                new Contact {Name = "Крылов Роман Алексеевич",
                             Email = "romankrylov56230@gmail.com",
                             PhoneNumber = "89172103831"},
                new Contact {Name = "Андреев Максим Артемович",
                             Email = "romeget@mail.ru",
                             PhoneNumber = "89192874478"}

            };

            return View(obj);
        }
    }
}
