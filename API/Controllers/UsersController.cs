using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
       // public ActionResult<IEnumerable<AppUser>> GetUsers()  --> synchronous
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            //return _context.Users.ToList();   --> synchronous
            //await - unwraps result from the task 
            return await _context.Users.ToListAsync();

        } 

        //api/Users/3
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            //return _context.Users.Find(id);
            return await _context.Users.FindAsync(id);
        } 
    }
}