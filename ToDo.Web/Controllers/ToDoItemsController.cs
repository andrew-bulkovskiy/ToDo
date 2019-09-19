﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Application.ToDoItems.Queries.GetToDoItemsList;
using ToDo.Domain.Entities;
using ToDo.Persistence;

namespace ToDo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly ToDoDbContext _context;
        private readonly IMediator _mediator;

        public ToDoItemsController(IMediator mediator, ToDoDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        // GET: api/ToDoItems
        [HttpGet]
        [ProducesResponseType(200)]
        //public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDoItems()
        public async Task<ActionResult<string>> GetToDoItems()
        {
            var result = await _mediator.Send(new GetToDoItemsListQuery());
            //return await _context.ToDoItems.Include(t => t.Category).ToListAsync();
            return Ok(result);
        }

        // GET: api/ToDoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItem(int id)
        {
            var toDoItem = await _context.ToDoItems.FindAsync(id);

            if (toDoItem == null)
            {
                return NotFound();
            }

            return toDoItem;
        }

        // PUT: api/ToDoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItem(int id, ToDoItem toDoItem)
        {
            if (id != toDoItem.ToDoItemId)
            {
                return BadRequest();
            }

            _context.Entry(toDoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoItemExists(id))
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

        // POST: api/ToDoItems
        [HttpPost]
        public async Task<ActionResult<ToDoItem>> PostToDoItem(ToDoItem toDoItem)
        {
            _context.ToDoItems.Add(toDoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetToDoItem", new { id = toDoItem.ToDoItemId }, toDoItem);
        }

        // DELETE: api/ToDoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ToDoItem>> DeleteToDoItem(int id)
        {
            var toDoItem = await _context.ToDoItems.FindAsync(id);
            if (toDoItem == null)
            {
                return NotFound();
            }

            _context.ToDoItems.Remove(toDoItem);
            await _context.SaveChangesAsync();

            return toDoItem;
        }

        private bool ToDoItemExists(int id)
        {
            return _context.ToDoItems.Any(e => e.ToDoItemId == id);
        }
    }
}
