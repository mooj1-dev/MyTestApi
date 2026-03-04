using Microsoft.AspNetCore.Mvc;
using MyTestApi.Models;
using MyTestApi.Repositories;

namespace MyTestApi.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _repo;

        public UserController(UserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }

        [HttpGet("{id:long}")]
        public IActionResult GetById(long id)
        {
            var user = _repo.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create(User user) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = _repo.Create(user);

            return CreatedAtAction(
            nameof(GetById),
            new { id = created.id },
            created);

        }

        [HttpPut("{id:long}")]
        public IActionResult Update(long id, User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ok = _repo.Update(id, user);
            if (!ok) return NotFound();

            return NoContent();
        }

        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            var ok = _repo.Delete(id);
            if (!ok) return NotFound();

            return NoContent();
        }
    }
}
