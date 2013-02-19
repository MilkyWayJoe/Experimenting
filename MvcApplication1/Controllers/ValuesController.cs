using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace MvcApplication1.Controllers {

    public class Person {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class ValuesController : ApiController {
        // GET api/values
        public object Get() {
            var chararacters = new List<Person>() { 
                new Person() {
                    Id = 1,
                    FirstName = "Hiro",
                    LastName = "Nakamura"
                },
                new Person() {
                    Id = 2,
                    FirstName = "Clark",
                    LastName = "Kent"
                },
                new Person() {
                    Id = 3,
                    FirstName = "Peter",
                    LastName = "Parker"
                }
            };
            return new { people = chararacters };
        }

        // GET api/values/5
        public string Get(int id) {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value) {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/values/5
        public void Delete(int id) {
        }
    }
}