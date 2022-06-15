using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarWash2.Data;
using CarWash2.Models;

namespace CarWash2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServiceCategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ServiceCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceCategory>>> GetServiceCategories()
        {
          if (_context.ServiceCategories == null)
          {
              return NotFound();
          }
            return await _context.ServiceCategories.ToListAsync();
        }

        // GET: api/ServiceCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceCategory>> GetServiceCategory(int id)
        {
          if (_context.ServiceCategories == null)
          {
              return NotFound();
          }
            var serviceCategory = await _context.ServiceCategories.FindAsync(id);

            if (serviceCategory == null)
            {
                return NotFound();
            }

            return serviceCategory;
        }

        // PUT: api/ServiceCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceCategory(int id, ServiceCategory serviceCategory)
        {
            if (id != serviceCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceCategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ServiceCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceCategory>> PostServiceCategory(ServiceCategory serviceCategory)
        {
          if (_context.ServiceCategories == null)
          {
              return Problem("Entity set 'AppDbContext.ServiceCategories'  is null.");
          }
            _context.ServiceCategories.Add(serviceCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceCategory", new { id = serviceCategory.Id }, serviceCategory);
        }

        // DELETE: api/ServiceCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceCategory(int id)
        {
            if (_context.ServiceCategories == null)
            {
                return NotFound();
            }
            var serviceCategory = await _context.ServiceCategories.FindAsync(id);
            if (serviceCategory == null)
            {
                return NotFound();
            }

            _context.ServiceCategories.Remove(serviceCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceCategoryExists(int id)
        {
            return (_context.ServiceCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
