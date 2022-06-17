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
    public class CustomerCarsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomerCarsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerCars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerCar>>> GetCustomerCars()
        {
          if (_context.CustomerCars == null)
          {
              return NotFound();
          }
            return await _context.CustomerCars.ToListAsync();
        }

        // GET: api/CustomerCars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerCar>> GetCustomerCar(int id)
        {
          if (_context.CustomerCars == null)
          {
              return NotFound();
          }
            var customerCar = await _context.CustomerCars.FindAsync(id);

            if (customerCar == null)
            {
                return NotFound();
            }

            return customerCar;
        }

        // GET: api/CustomerCars?plate = 1234
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CustomerCar>>> GetCustomerCarByPlate(string plate)
        {
            if (_context.CustomerCars == null)
            {
                return NotFound();
            }
            var customerCar = await _context.CustomerCars.Where(x=> x.Plate == plate).ToListAsync();

            if (customerCar == null)
            {
                return NotFound();
            }

            return customerCar;
        }

        // GET: api/CustomerCars?CustomerId = 1234
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CustomerCar>>> GetCustomerCarByCustomerId(int CustomerId)
        {
            if (_context.CustomerCars == null)
            {
                return NotFound();
            }
            var customerCar = await _context.CustomerCars.Where(x => x.CustomerId == CustomerId).ToListAsync();

            if (customerCar == null)
            {
                return NotFound();
            }

            return customerCar;
        }

        // GET: api/CustomerCars?CarId = 1234
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<CustomerCar>>> GetCustomerCarByCarId(int CarId)
        {
            if (_context.CustomerCars == null)
            {
                return NotFound();
            }
            var customerCar = await _context.CustomerCars.Where(x => x.CarId == CarId).ToListAsync();

            if (customerCar == null)
            {
                return NotFound();
            }

            return customerCar;
        }

        // PUT: api/CustomerCars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerCar(int id, CustomerCar customerCar)
        {
            if (id != customerCar.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerCar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerCarExists(id))
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

        // POST: api/CustomerCars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerCar>> PostCustomerCar(CustomerCar customerCar)
        {
          if (_context.CustomerCars == null)
          {
              return Problem("Entity set 'AppDbContext.CustomerCars'  is null.");
          }
            _context.CustomerCars.Add(customerCar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerCar", new { id = customerCar.Id }, customerCar);
        }

        // DELETE: api/CustomerCars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerCar(int id)
        {
            if (_context.CustomerCars == null)
            {
                return NotFound();
            }
            var customerCar = await _context.CustomerCars.FindAsync(id);
            if (customerCar == null)
            {
                return NotFound();
            }

            _context.CustomerCars.Remove(customerCar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerCarExists(int id)
        {
            return (_context.CustomerCars?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
