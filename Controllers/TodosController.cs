using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using dotnet_tutorial_2022.Models;
using dotnet_tutorial_2022.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dotnet_tutorial_2022.Controllers
{
    [Route("todos")]
    public class TodosController : Controller
    {
        private readonly IMemoryCache memoryCache;

        public TodosController(IMemoryCache cache)
        {
            memoryCache = cache;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            if (memoryCache.TryGetValue("todos", out IList<Todo> todos))
            {
                return Ok(todos);
            }
            return Ok(new List<Todo>() { });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if (!memoryCache.TryGetValue("todos", out IList<Todo> todos))
            {
                return NotFound();
            }
            Todo todo = todos.First(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }
            return Ok(todo);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] VTodo newTodo)
        {
            if (!memoryCache.TryGetValue("todos", out IList<Todo> todos))
            {
                todos = new List<Todo>() { };
            }
            string id = Guid.NewGuid().ToString();
            string url = $"{Request.Host}{Request.Path}/${id}";
            Todo todo = new()
            {
                Id = id,
                Url = url,
                Title = newTodo.Title,
                Completed = newTodo.Completed,
                Order = newTodo.Order
            };
            todos.Add(todo);
            memoryCache.Set("todos", todos);
            return Ok(todo);
        }

        // PUT api/values/5
        [HttpPatch("{id}")]
        public IActionResult Patch(string id, [FromBody] VTodo updatedTodo)
        {
            if (!memoryCache.TryGetValue("todos", out IList<Todo> todos))
            {
                return NotFound();
            }
            Todo existingTodo = todos.First(t => t.Id == id);
            if (existingTodo == null)
            {
                return NotFound();
            }
            Todo todoAfterUpdate = new Todo
            {
                Id = id,
                Url = existingTodo.Url,
                Title = updatedTodo.Title,
                Completed = updatedTodo.Completed ?? existingTodo.Completed,
                Order = updatedTodo.Order ?? existingTodo.Order
            };
            todos.Remove(existingTodo);
            todos.Add(todoAfterUpdate);
            memoryCache.Set("todos", todos);
            return Ok(todoAfterUpdate);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (!memoryCache.TryGetValue("todos", out IList<Todo> todos))
            {
                return NotFound();
            }
            Todo existingTodo = todos.First(t => t.Id == id);
            if (existingTodo == null)
            {
                return NotFound();
            }
            bool success = todos.Remove(existingTodo);
            if (!success)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            memoryCache.Set("todos", todos);
            return Ok();
        }

        // DELETE api/values
        [HttpDelete]
        public IActionResult Delete()
        {
            memoryCache.Set("todos", new List<Todo>() { });
            return Ok();
        }
    }
}

