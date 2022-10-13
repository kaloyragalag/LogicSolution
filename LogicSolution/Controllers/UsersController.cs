using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LogicSolution.Data;
using LogicSolution.Model;
using Microsoft.AspNetCore.Http;
using System.Net;
using LogicSolution.Services;

namespace LogicSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        public async Task<IActionResult> Get()
        {
              return Ok(await _context.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        public async Task<IActionResult> Create(User user)
        {
            user.Password = AuthorizeService.CreateMD5(user.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(User user)
        {
            User dbUser = await _context.Users.FindAsync(user.Id);
            if (dbUser == null)
            {
                return NotFound();
            }
            dbUser.UserName = user.UserName;
            dbUser.Password = AuthorizeService.CreateMD5(user.Password);
            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.Email = user.Email;

            await _context.SaveChangesAsync();
            return Ok(dbUser);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            User dbUser = await _context.Users.FindAsync(id);
            if (dbUser == null)
            {
                return NotFound();
            }

            _context.Users.Remove(dbUser);
            await _context.SaveChangesAsync();
            return Ok(dbUser);
        }
    }
}
