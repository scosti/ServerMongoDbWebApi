using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstWebApp.Models;
using WebApiServer.Models;
using WebApiServer.Services;

namespace WebApiServer.Controllers
{

    [Route("api/users/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserServices _crudService;

        public UsersController(UserServices userServices)
        {
            _crudService = userServices;
        }

        [HttpGet]
        public ActionResult<List<User>> Get() =>
            _crudService.Get();

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var user = _crudService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            _crudService.Create(user);

            return CreatedAtRoute("GetNote", new { id = user.Id.ToString() }, user);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, User userIn)
        {
            var note = _crudService.Get(id);

            if (note == null)
            {
                return NotFound();
            }

            _crudService.Update(id, userIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = _crudService.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            _crudService.Remove(user);

            return NoContent();
        }
    }
}
