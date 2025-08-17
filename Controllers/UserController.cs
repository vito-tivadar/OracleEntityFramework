using Microsoft.AspNetCore.Mvc;

namespace OracleEntityFramework.Controllers
{
    public class UserController : Controller
    {
        private readonly DbContex.AppDbContext _context;

        public UserController(DbContex.AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("api/users")]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("api/users/{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }



        [HttpPost("api/users")]
        public IActionResult CreateUser([FromBody] Models.User user)
        {
            if (user == null)
            {
                return BadRequest("User cannot be null");
            }

            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }

        [HttpPut("api/users/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] Models.User user)
        {
            if (user == null || user.Id != id)
            {
                return BadRequest("User data is invalid");
            }

            var existingUser = _context.Users.Find(id);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;

            _context.Users.Update(existingUser);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("api/users/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }


    }
}
