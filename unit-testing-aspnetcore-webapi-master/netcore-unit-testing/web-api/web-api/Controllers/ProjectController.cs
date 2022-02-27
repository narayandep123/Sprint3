using APIWeb.Model;
using Microsoft.AspNetCore.Mvc;
using web_api.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        List<ProjectModel> projects = new List<ProjectModel>()
        {
            new ProjectModel (1, "TestProject1", "This is a test project", DateTime.Parse("2022-01-13")),
            new ProjectModel (2, "TestProject1", "This is a test project", DateTime.Parse("2022-01-13")),
            new ProjectModel (3, "TestProject1", "This is a test project", DateTime.Parse("2022-01-13")),
            new ProjectModel (4, "TestProject1", "This is a test project", DateTime.Parse("2022-01-13"))
        };
        private readonly IProjectService _service;
        public ProjectController(IProjectService service)
        {
            _service = service;

        }
        // GET: api/<ProjectController>
        [HttpGet]
        public IActionResult Get()
        {
            var items = _service.GetAllItems();
            return Ok(items);
        }

        // GET api/<ProjectController>/5
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

        // POST api/<ProjectController>
        [HttpPost]
        public IActionResult Post([FromBody] ProjectModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _service.Add(userModel);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
        public List<ProjectModel> Put(int id, [FromBody] ProjectModel value)
        {
            ProjectModel projectToUpdate = projects.Find(a => a.Id == id);
            int index = projects.IndexOf(projectToUpdate);

            projects[index].Name = value.Name;
            projects[index].Detail = value.Detail;
            projects[index].CreatedOn = value.CreatedOn;

            return projects;
        }

        // DELETE api/<ProjectController>/5
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
