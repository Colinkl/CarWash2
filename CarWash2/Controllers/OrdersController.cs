using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarWash2.Data;
using CarWash2.Models;
using System.Diagnostics;

namespace CarWash2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly AppDbContext _context;

        public OrdersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders(int page, int pageSize = 30, int sort = 0)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }

            var orders = _context.Orders
                .Include(x => x.CustomerCar)
                .Where(p => p.Id > pageSize * page)
                .Take(pageSize);

            if (sort != 0)
            {
                orders = Sorter(orders, sort);
            }                

            return await orders.ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // GET: api/Orders?Status = 1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByStatus(int Status)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var orders = await _context.Orders.Where(x => x.Status == Status).ToListAsync();

            if (orders == null)
            {
                return NotFound();
            }

            return orders;
        }

        // GET: api/Orders?SericeId = 1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByServiceId(int SericeId, int sort = 0)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var ordersReq = _context.Orders.Where(x => x.ServiceId == SericeId);

            if (sort != 0)
            {
                ordersReq = Sorter(ordersReq, sort);
            }

            var orders = await ordersReq.ToListAsync();

            if (orders == null)
            {
                return NotFound();
            }

            return orders;
        }

        // GET: api/Orders?CustomerCarId = 1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByCustomerCarId(int CustomerCarId, int sort = 0)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var ordersReq = _context.Orders.Where(x => x.CustomerCarId == CustomerCarId);

            if (sort != 0)
            {
                ordersReq = Sorter(ordersReq, sort);
            }

            var orders = await ordersReq.ToListAsync();

            if (orders == null)
            {
                return NotFound();
            }

            return orders;
        }

        // GET: api/Orders?EmployeeId = 1 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByEmployeeId(int EmployeeId, int sort = 0)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var ordersReq = _context.Orders.Where(x => x.EmployeeId == EmployeeId);

            if (sort != 0)
            {
                ordersReq = Sorter(ordersReq, sort);
            }

            var orders = await ordersReq.ToListAsync();

            if (orders == null)
            {
                return NotFound();
            }

            return  orders;
        }

        private IQueryable<Order> Sorter(IQueryable<Order> orders, int mode)
        {
            switch (mode)
            {
                case 1:
                    return orders.OrderBy(x => x.StartTime);
                case 2:
                    return orders.OrderByDescending(x => x.StartTime);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'AppDbContext.Orders'  is null.");
            }
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            var customerCar = await _context.CustomerCars
                .Include(u=>u.Customer)
                .Where(x=> x.Id == order.CustomerCarId)
                .FirstOrDefaultAsync();

            if (customerCar is not null && customerCar.Customer.IsSendNotify)
            {
                Debug.WriteLine($"Meow meow! Notification here! {customerCar.Customer.FirstName} your order created");
            }

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (_context.Orders == null)
            {
                return NotFound();
            }
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
