using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewWebAPI.Models;

namespace NewWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactContext _context;

        private string message = "400:error";
        public ContactsController(ContactContext context)
        {
            _context = context;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactItem>>> GetContacts()
        {
          if (_context.Contacts == null)
          {
              return NotFound();
          }
            return await _context.Contacts.ToListAsync();
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactItem>> GetContact(long id)
        {
          if (_context.Contacts == null)
          {
              return NotFound();
          }
            var ContactItem = await _context.Contacts.FindAsync(id);

            if (ContactItem == null)
            {
                return NotFound();
            }

            return ContactItem;
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(long id, ContactItem ContactItem)
        {
            if (id != ContactItem.Id)
            {
                return BadRequest(message);
            }
            ContactItem.Updated = DateTime.Now;
            _context.Entry(ContactItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactItemExists(id))
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


        // POST: api/Contacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactItem>> PostContact(ContactItem ContactItem)
        { 
            //contactテーブルデータ作成
            _context.Contacts.Add(ContactItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = ContactItem.Id }, ContactItem);
            return CreatedAtAction(nameof(GetContact), new { id = ContactItem.Id }, ContactItem);
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            if (_context.Contacts == null)
            {
                return NotFound();
            }
            var ContactItem = await _context.Contacts.FindAsync(id);
            if (ContactItem == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(ContactItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactItemExists(long id)
        {
            return (_context.Contacts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
