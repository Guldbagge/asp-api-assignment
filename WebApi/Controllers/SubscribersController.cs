using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SubscribersController(DataContext context) : ControllerBase
    {
        private readonly DataContext _context = context;

        #region CREATE
        [HttpPost]
        [UseApiKey]
        public async Task<IActionResult> Create(string email, bool isSubscribed, bool newsletterCheckbox1, bool newsletterCheckbox2, bool newsletterCheckbox3, bool newsletterCheckbox4, bool newsletterCheckbox5, bool newsletterCheckbox6)
        {
            if (!string.IsNullOrEmpty(email))
            {
                if (!await _context.Subscribers.AnyAsync(x => x.Email == email))
                {
                    try
                    {
                        var subscriberEntity = new SubscriberEntity
                        {
                            Email = email,
                            IsSubscribed = isSubscribed,
                            NewsletterCheckbox1 = newsletterCheckbox1,
                            NewsletterCheckbox2 = newsletterCheckbox2,
                            NewsletterCheckbox3 = newsletterCheckbox3,
                            NewsletterCheckbox4 = newsletterCheckbox4,
                            NewsletterCheckbox5 = newsletterCheckbox5,
                            NewsletterCheckbox6 = newsletterCheckbox6
                        };
                        _context.Subscribers.Add(subscriberEntity);
                        await _context.SaveChangesAsync();

                        return Created("", null);
                    }
                    catch
                    {
                        return Problem("Unable to create subscription.");
                    }
                }
                return Conflict("Email already exists.");
            }
            return BadRequest();
        }

        #endregion


        #region READ
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subscribers = await _context.Subscribers.ToListAsync();

            if (subscribers.Count > 0)
            {
                return Ok(subscribers);
            }

            return NotFound();
        }

        [HttpGet ("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            var subscriber = await _context.Subscribers.FindAsync(id); //move to repository

            if (subscriber != null)
            {
                return Ok(subscriber);
            }                                                                 

            return NotFound();
        }

        #endregion

        #region UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOne(int id, string email)
        {
            var subscriber = await _context.Subscribers.FindAsync(id); //move to repository

            if (subscriber != null)
            {
                subscriber.Email = email;
                _context.Subscribers.Update(subscriber);
                await _context.SaveChangesAsync();
                
                return Ok(subscriber);
            }
            return NotFound();
        }

        #endregion

        #region DELETE
        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteOne(string email)
        {
            var subscriber = await _context.Subscribers.FirstOrDefaultAsync(x => x.Email == email);
            if (subscriber != null)
            {
                _context.Subscribers.Remove(subscriber);
                await _context.SaveChangesAsync();

                return Ok();
            }

            return NotFound();
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOne(int id)
        //{
        //    var subscribers = await _context.Subscribers.FirstOrDefaultAsync(x => x.Id == id);
        //    if (subscribers != null)
        //    {
        //        _context.Subscribers.Remove(subscribers);
        //        await _context.SaveChangesAsync();

        //        return Ok();
        //    }

        //    return NotFound();
        //}

        #endregion

    }
}
