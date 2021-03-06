using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayerProject.Core.Models;
using NLayerProject.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IService<Person> _personService;

        public PersonsController(IService<Person> personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            throw new Exception("tüm dataları çekerken bir hata meydana geldi");

            var persons = await _personService.GetAllAsync();
            return Ok(persons);

        }

        [HttpPost]
        public async Task<IActionResult> Save(Person person)
        {
            var newperson = await _personService.AddAsync(person);
            return Ok(newperson);
        }
    }
}
