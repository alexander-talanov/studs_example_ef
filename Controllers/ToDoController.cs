using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todo_list.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace todo_list.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private ToDoRepository repository = new ToDoRepository();

        // GET: api/<ToDoController>
        [HttpGet]
        public IEnumerable<ToDoDto> Get()
        {
            return repository.GetAll();
        }

        // POST api/<ToDoController>
        [HttpPost]
        public int Post([FromBody] ToDoDto dto)
        {
            return repository.Add(dto);
        }

        // PUT api/<ToDoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ToDoDto dto)
        {
            repository.Update(id, dto);
        }
    }
}
