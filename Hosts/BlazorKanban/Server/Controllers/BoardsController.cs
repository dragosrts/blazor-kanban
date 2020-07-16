using BlazorKanban.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorKanban.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoardsController : ControllerBase
    {
        private readonly ILogger<BoardsController> logger;

        public BoardsController(ILogger<BoardsController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Board>> Get()
        {
            var list =
                new List<Board>
                {
                    new Board
                    {
                        Id = 1,
                        Title = "First Board",
                        Description = "Description of the First Board",
                        Columns = new List<Column>
                        {
                            new Column
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<Card>
                                {
                                    new Card
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    }
                                }
                            }
                        }
                    },
                    new Board(),
                    new Board(),
                    new Board(),
                    new Board(),
                    new Board(),
                    new Board(),
                    new Board(),
                    new Board(),
                    new Board(),
                    new Board(),
                    new Board(),
                    new Board(),
                    new Board(),
                    new Board(),
                    new Board(),
                    new Board(),
                    new Board(),
                    new Board(),
                };

            return list;
        }
    }
}