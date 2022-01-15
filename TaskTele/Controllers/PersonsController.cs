using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TaskTele.Data.Interfaces;
using TaskTele.Data.Models;



namespace TaskTele.Controllers
{
    public class PersonsController : Controller
    {

        private readonly IPerson _person;

        public PersonsController (IPerson iPerson) {
            _person = iPerson;
        }

        public async Task<IActionResult> List (string sex, string x, string y, int page = 1) {
            int pageSize = 4;   // количество элементов на странице

            IEnumerable<Person> person = null;
            bool result = int.TryParse(sex, out var number);
            if (result == true) {
                person = _person.getObjPerson(number);
            } else if (string.IsNullOrEmpty(sex)) { // проверка на значения пола работа с ViewResult

                person = _person.Persons;
                foreach (var age in person) {
                    age.age = 0;
                }
            } else {

                switch (sex) {
                    case "male":
                        person = _person.Persons.Where(i => i.sex == true);
                        break;
                    case "female":
                        person = _person.Persons.Where(i => i.sex == false);
                        break;
                }

                if (!string.IsNullOrEmpty(x) & !string.IsNullOrEmpty(y)) {
                    //  try {
                    person = person.Where(i => (i.age > Convert.ToInt32(x)) && (i.age < Convert.ToInt32(y))).OrderBy(i => i.age).ToList();
                   
                    //} catch(FormatException e) {
                    //    x = "0";
                    //    y = "100";
                    //    person = person.OrderBy(i => i.age);
                }
                foreach (var per in person) {
                    per.age = 0;
                }

            }

            IQueryable<Person> source = person.AsQueryable();
            var count = person.Count();
            var items = person.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                //Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel {
                PageViewModel = pageViewModel,
                Persons = items
            };
            return View(viewModel);
        }

       

        }

      


    }

   






