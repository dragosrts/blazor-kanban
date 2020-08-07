using BlazorKanban.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlazorKanban.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskListsController : ControllerBase
    {
        private readonly ILogger<TaskListsController> logger;

        public TaskListsController(ILogger<TaskListsController> logger)
        {
            this.logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateTaskList(Column column)
        {
            return 2;
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> UpdateTaskList(int id)
        {
            return 2;
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> DeleteTaskList(int id)
        {
            return 2;
        }
    }
}