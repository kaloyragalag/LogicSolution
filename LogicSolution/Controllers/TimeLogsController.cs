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
using LogicSolution.Model.Dtos;

namespace LogicSolution.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeLogsController : ControllerBase
    {
        private readonly DataContext _context;

        public TimeLogsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TimeLogs))]
        public async Task<IActionResult> Get(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return NotFound();

            return Ok(await _context.TimeLogs.Where(x => x.UserId == userId).ToListAsync());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TimeLogs))]
        public async Task<IActionResult> Create(TimeLogsDto timeLogs)
        {
            var user = await _context.Users.FindAsync(timeLogs.UserId);
            if (user == null)
                return NotFound();

            var dbTimeLogs = new TimeLogs()
            {
                LogType = timeLogs.LogType,
                LogDate = timeLogs.LogDateTime.ToString("MM/dd/yyyy"),
                LogTime = timeLogs.LogDateTime.ToString("HH:mm:ss"),
                UserId = timeLogs.UserId
            };
            _context.TimeLogs.Add(dbTimeLogs);
            await _context.SaveChangesAsync();
            return Ok(dbTimeLogs);
        }
    }
}
