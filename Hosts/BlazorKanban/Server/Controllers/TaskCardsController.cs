using BlazorKanban.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace BlazorKanban.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskCardsController : ControllerBase
    {
        private readonly ILogger<TaskCardsController> logger;

        public TaskCardsController(ILogger<TaskCardsController> logger)
        {
            this.logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateTaskCard(TaskCard card)
        {
            return 2;
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> UpdateTaskCard(int id)
        {
            return 2;
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> DeleteTaskCard(int id)
        {
            return 2;
        }
    }
}
