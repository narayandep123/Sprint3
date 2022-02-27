using APIWeb.Model;
using Microsoft.AspNetCore.Mvc;
using web_api.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        List<TaskModel> tasks = new List<TaskModel>()
        {
            new TaskModel (1, 1, 2, 1, "This ia test Task", DateTime.Parse("2022-01-13")),
            new TaskModel (2, 1, 3, 2, "This ia test Task", DateTime.Parse("2022-01-13")),
            new TaskModel (3, 2, 4, 2, "This ia test Task", DateTime.Parse("2022-01-13"))
        };

        private readonly ITaskService _service;
        public TaskController(ITaskService service)
        {
            _service = service;


        }
        // GET: api/<TaskController>
        [HttpGet]
        public IActionResult Get()
        {
            var items = _service.GetAllItems();
            return Ok(items);
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = _service.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST api/<TaskController>
        [HttpPost]
        public IActionResult Post([FromBody] TaskModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _service.Add(userModel);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        // PUT api/<TaskController>/5
        //[HttpPut("{id}")]
        //public List<TaskModel> Put(int id, [FromBody] TaskModel value)
        //{
        //    TaskModel taskToUpdate = tasks.Find(a => a.Id == id);
        //    int index = tasks.IndexOf(taskToUpdate);

        //    tasks[index].ProjectId = value.ProjectId;
        //    tasks[index].Status = value.Status;
        //    tasks[index].AssignedToUserID = value.AssignedToUserID;
        //    tasks[index].Detail = value.Detail;
        //    tasks[index].CreatedOn = value.CreatedOn;

        //    return tasks;
        //}

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingItem = _service.GetById(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            _service.Remove(id);
            return NoContent();
        }
    }
}
