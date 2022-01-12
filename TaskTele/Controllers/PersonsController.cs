using Microsoft.AspNetCore.Mvc;

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


        [Route("Persons/List")]
        [Route("Persons/List/{sex}")] // передается пол
        [Route("Persons/List/{sex}/{x}/{y}")]// необходима дополнительная проверка на ввод числа или обернуть в try catch
        public ActionResult List (string sex, string x, string y) {

            List<Person> person = null;
            bool result = int.TryParse(sex, out var number);


            if (string.IsNullOrEmpty(sex)) { // проверка на значения пола работа с ViewResult

                person = _person.Persons.ToList();

            } else {
                if (string.Equals("male", sex, StringComparison.OrdinalIgnoreCase)) {
                    person = _person.Persons.Where(i => i.sex == true).ToList();
                } else if (string.Equals("female", sex, StringComparison.OrdinalIgnoreCase)) {
                    person = _person.Persons.Where(i => i.sex == false).ToList();
                } else if (result == true) {
                    person = _person.getObjPerson(number).ToList();
                }

                if (!string.IsNullOrEmpty(x) & !string.IsNullOrEmpty(y)) {
                    //  try {
                    person = person.Where(i => (i.age > Convert.ToInt32(x)) && (i.age < Convert.ToInt32(y))).OrderBy(i => i.age).ToList();
                    //} catch(FormatException e) {
                    //    x = "0";
                    //    y = "100";
                    //    person = person.OrderBy(i => i.age);
                }
            }

            return View(person);


        }



    }
}

