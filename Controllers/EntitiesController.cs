using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Reflection;
using WebAPIAssignment.Database;
using WebAPIAssignment.Model;

namespace WebAPIAssignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntitiesController : Controller
    {
        private readonly EntityAPIDbContext dbContext;

        public EntitiesController(EntityAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetEntities()
        {
            var entities = await dbContext.Entities
                .Select(e => new
                {   e.EntityId,
                    Addresses = e.Addresses.Select(a => new { a.Country, a.AddressLine, a.City }),
                    Dates = e.Dates.Select(d => new { d.DateType, d.DateValue }),
                    e.Deceased,
                    e.Gender,
                    Names = e.Names.Select(n => new { n.FirstName, n.MiddleName, n.Surname }),
                })
                .ToListAsync();

            return Ok(entities);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntity(int id)
        {
            var entity = await dbContext.Entities
                .Where(e => e.EntityId == id)
                .Select(e => new
                {   
                    e.EntityId,
                    Addresses = e.Addresses.Select(a => new { a.Country, a.AddressLine, a.City }),
                    Dates = e.Dates.Select(d => new { d.DateType, d.DateValue }),
                    e.Deceased,
                    e.Gender,
                    Names = e.Names.Select(n => new { n.FirstName, n.MiddleName, n.Surname })
                    
                })
                .FirstOrDefaultAsync();

            if (entity == null)            
                return NotFound();           

            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntity(AddEntityDTO entityDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map DTO to Entity
            var entity = new Entity
            {   
                EntityId = entityDto.EntityId,
                Deceased = entityDto.Deceased,
                Gender = entityDto.Gender,
                Addresses = entityDto.Addresses?.Select(a => new Address
                {
                    Country = a.Country,
                    AddressLine = a.AddressLine,
                    City = a.City
                }).ToList(),
                Dates = entityDto.Dates?.Select(d => new Date
                {
                    DateType = d.DateType,
                    DateValue = d.DateValue
                }).ToList(),
                Names = entityDto.Names?.Select(n => new Name
                {
                    FirstName = n.FirstName,
                    MiddleName = n.MiddleName,
                    Surname = n.Surname
                }).ToList()
            };

            dbContext.Entities.Add(entity);
            await dbContext.SaveChangesAsync();

            return Ok("New Entity has been created Succesfully");
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEntity(int id, UpdateEntityDTO entityDto)
        {            
            

            var entity = await dbContext.Entities.Include(e => e.Names)
                                                 .Include(e => e.Dates)
                                                 .Include(e => e.Addresses)
                                                 .FirstOrDefaultAsync(e => e.EntityId == id);

            if (entity == null)           
                return NotFound();
            

            
            entity.Deceased = entityDto.Deceased;
            entity.Gender = entityDto.Gender;

            // Update navigation properties
            if (entityDto.Names != null)
            {
                entity.Names.Clear();
                entity.Names.AddRange(entityDto.Names.Select(n => new Name
                {
                    FirstName = n.FirstName,
                    MiddleName = n.MiddleName,
                    Surname = n.Surname
                }));
            }

            if (entityDto.Dates != null)
            {
                entity.Dates.Clear();
                entity.Dates.AddRange(entityDto.Dates.Select(d => new Date
                {
                    DateType = d.DateType,
                    DateValue = d.DateValue
                }));
            }

            if (entityDto.Addresses != null)
            {
                entity.Addresses.Clear();
                entity.Addresses.AddRange(entityDto.Addresses.Select(a => new Address
                {
                    Country = a.Country,
                    AddressLine = a.AddressLine,
                    City = a.City
                }));
            }

            dbContext.Entry(entity).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok($"Entity  with id:{id} has been updated succesfully!");
        }

        private bool EntityExists(int id)
        {
            return dbContext.Entities.Any(e => e.EntityId == id);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(int id)
        {
            var entity = await dbContext.Entities.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            dbContext.Entities.Remove(entity);
            await dbContext.SaveChangesAsync();

            return Ok("Entity has been deleted succesfully!!!");
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchEntities(
            string? addressCountry, 
            string? addressLine, 
            string? firstName, 
            string? middleName, 
            string? surname)
        {
            IQueryable<AddEntityDTO> query = dbContext.Entities
                .Include(e => e.Addresses)
                .Include(e => e.Names)
                .Include(e => e.Dates)
                .AsQueryable() // Ensure queryable for projection
                .Select(e => new AddEntityDTO
                {   EntityId = e.EntityId,
                    Addresses = e.Addresses.Select(a => new AddressDto
                    {
                        Country = a.Country,
                        AddressLine = a.AddressLine,
                        City = a.City
                    }).ToList(),
                    Dates = e.Dates.Select(d => new DateDto
                    {
                        DateType = d.DateType,
                        DateValue = d.DateValue
                    }).ToList(),
                    Deceased = e.Deceased,
                    Gender = e.Gender,
                    Names = e.Names.Select(n => new NameDto
                    {
                        FirstName = n.FirstName,
                        MiddleName = n.MiddleName,
                        Surname = n.Surname
                    }).ToList()
                });

            if (!string.IsNullOrEmpty(addressCountry))
            {
                query = query.Where(e => e.Addresses.Any(a => EF.Functions.Like(a.Country, $"%{addressCountry}%")));
            }

            if (!string.IsNullOrEmpty(addressLine))
            {
                query = query.Where(e => e.Addresses.Any(a => EF.Functions.Like(a.AddressLine, $"%{addressLine}%")));
            }

            if (!string.IsNullOrEmpty(firstName))
            {
                query = query.Where(e => e.Names.Any(n => EF.Functions.Like(n.FirstName, $"%{firstName}%")));
            }

            if (!string.IsNullOrEmpty(middleName))
            {
                query = query.Where(e => e.Names.Any(n => EF.Functions.Like(n.MiddleName, $"%{middleName}%")));
            }

            if (!string.IsNullOrEmpty(surname))
            {
                query = query.Where(e => e.Names.Any(n => EF.Functions.Like(n.Surname, $"%{surname}%")));
            }

            var entities = await query.ToListAsync();
            return Ok(entities);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> FilterEntities(
            [FromQuery]string? gender, 
            [FromQuery]DateTime? startDate,
            [FromQuery]DateTime? endDate,
            [FromQuery] List<string>? countries)
        {
            IQueryable<AddEntityDTO> query = dbContext.Entities
                .Include(e => e.Addresses)
                .Include(e => e.Names)
                .Include(e => e.Dates)
                .AsQueryable() // Ensure queryable for projection
                .Select(e => new AddEntityDTO
                {   EntityId = e.EntityId,
                    Addresses = e.Addresses.Select(a => new AddressDto
                    {
                        Country = a.Country,
                        AddressLine = a.AddressLine,
                        City = a.City
                    }).ToList(),
                    Dates = e.Dates.Select(d => new DateDto
                    {
                        DateType = d.DateType,
                        DateValue = d.DateValue
                    }).ToList(),
                    Deceased = e.Deceased,
                    Gender = e.Gender,
                    Names = e.Names.Select(n => new NameDto
                    {
                        FirstName = n.FirstName,
                        MiddleName = n.MiddleName,
                        Surname = n.Surname
                    }).ToList()
                });

            if (!string.IsNullOrEmpty(gender))            
                query = query.Where(e => e.Gender == gender);


            if (startDate != null || endDate != null)
            {
                if (startDate != null && endDate != null)               
                    query = query.Where(e => e.Dates.Any(d => d.DateValue >= startDate && d.DateValue <= endDate));
                
                else if (startDate != null)
                    query = query.Where(e => e.Dates.Any(d => d.DateValue >= startDate));
                
                else if (endDate != null)
                    query = query.Where(e => e.Dates.Any(d => d.DateValue <= endDate));
                
            }

            if (countries != null && countries.Any())            
                query = query.Where(e => e.Addresses.Any(a => countries.Contains(a.Country)));
            

            var entities = await query.ToListAsync();
            return Ok(entities);
        }

    }
}
