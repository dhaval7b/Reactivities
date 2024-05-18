using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/activities")]
    public class ActivityController : ControllerBase
    {
        private readonly DataContext _context;
        public ActivityController(DataContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            return await _context.Activities.ToListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Activity>> GetActivityById([FromRoute] Guid id)
        {
            return await _context.Activities.FindAsync(id);
        }
    }
}
