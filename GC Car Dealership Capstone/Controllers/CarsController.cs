using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GC_Car_Dealership_Capstone.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GC_Car_Dealership_Capstone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly InventoryDBContext _context;
        public CarsController(InventoryDBContext context) {
            _context = context;
        }

        //GET: api/Cars
        [HttpGet]
        public List<Cars> GetCars(string make=null, string model=null, int year=0, string color=null)
        {
            IQueryable<Cars> cars = _context.Cars;
            if (make != null) cars = cars.Where(x => x.Make == make);
            if (model != null) cars = cars.Where(x => x.Model == model);
            if (year != 0) cars = cars.Where(x => x.Year == year);
            if (color != null) cars = cars.Where(x => x.Color == color);

            return cars.ToList<Cars>();
        }

        //GET: api/Car/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Cars>> GetCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                //returns a 404 error code if an employee with the given
                //id does not exist in the database
                return NotFound();
            }
            else
            {
                return car;
            }
        }

        //DELETE api/Car/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            else
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
                return NoContent();
                //204 status code -- successful and the API is not returning any content
            }
        }

        //POST: api/Car
        [HttpPost]
        public async Task<ActionResult<Cars>> AddCar(Cars newCar)
        {
            if (ModelState.IsValid)
            {
                _context.Cars.Add( newCar );
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetCar), new { id = newCar.Id }, newCar);
                //returns HTTP 201 status code - standard response for HTTP Post methods that create new
                //resources on the server
                //nameof(GetEmployee) - adds a location to the response, specifies the URI 
                //of the newly created employee (AKA where we can access the new employee)
                //C# "nameof" is used to avoid hard-coding the action in the CreatedAtAction call
            }
            else
            {
                return BadRequest();
            }
        }

        //PUT: api/Cars/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> PutCar(int id, Cars updatedCar)
        {
            if (id != updatedCar.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                _context.Entry(updatedCar).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
    }

}