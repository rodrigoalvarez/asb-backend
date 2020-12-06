using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASBbackend.Models;

namespace ASBbackend.Controllers
{
    // Documentation: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api

    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        private readonly CreditCardContext _context;

        public CreditCardsController(CreditCardContext context)
        {
            _context = context;
        }

        /// GET: api/CreditCards
        /// <summary>
        /// Retrieves all CreditCards
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CreditCard>>> GetCreditCards()
        {
            return await _context.CreditCards.ToListAsync();
        }

        /// GET: api/CreditCards/5
        /// <summary>
        /// Retrieves a specific CreditCard by unique id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<CreditCard>> GetCreditCard(Guid id)
        {
            var creditCard = await _context.CreditCards.FindAsync(id);

            // CreditCard doesn't exist
            if (creditCard == null)
            {
                return NotFound();
            }

            return creditCard;
        }

        /// POST: api/CreditCards
        /// <summary>
        /// Create a CreditCard
        /// </summary>
        /// <response code="200">CreditCard created</response>
        [HttpPost]
        public async Task<ActionResult<CreditCard>> PostCreditCard(CreditCard creditCard)
        {
            // Generate Id
            creditCard.Id = Guid.NewGuid();

            // Store CreditCard
            _context.CreditCards.Add(creditCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCreditCard), new { id = creditCard.Id }, creditCard);
        }
    }
}
