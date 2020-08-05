using BlazorKanban.Application.TaskBoards.Queries.GetTaskBoardDetail;
using BlazorKanban.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorKanban.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskBoardsController : ControllerBase
    {
        private readonly ILogger<TaskBoardsController> logger;

        private readonly IMediator mediator;

        public TaskBoardsController(ILogger<TaskBoardsController> logger, IMediator mediator)
        {
            this.logger = logger;
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskBoard>> GetTaskBoards()
        {
            var list =
                new List<TaskBoard>();
                //{
                //    new TaskBoard
                //    {
                //        Id = 1,
                //        Title = "First Board",
                //        Description = "Description of the First Board",
                //        Columns = new List<TaskColumn>
                //        {
                //            new TaskColumn
                //            {
                //                Id = 1,
                //                BoardId = 1,
                //                Title = "Column A",
                //                Description = "Description Column A",
                //                Cards = new List<TaskCard>
                //                {
                //                    new TaskCard
                //                    {
                //                        Id = 1,
                //                        ColumnId = 1,
                //                        Title = "Task 1A",
                //                        Description = "Description Task 1A",
                //                    },
                //                    new TaskCard
                //                    {
                //                        Id = 2,
                //                        ColumnId = 1,
                //                        Title = "Task 2A",
                //                        Description = "Description Task 2A",
                //                    },
                //                    new TaskCard
                //                    {
                //                        Id = 1,
                //                        ColumnId = 1,
                //                        Title = "Task 3A",
                //                        Description = "Description Task 3A",
                //                    },
                //                    new TaskCard
                //                    {
                //                        Id = 2,
                //                        ColumnId = 1,
                //                        Title = "Task 4A",
                //                        Description = "Description Task 4A",
                //                    },
                //                    new TaskCard
                //                    {
                //                        Id = 1,
                //                        ColumnId = 1,
                //                        Title = "Task 5A",
                //                        Description = "Description Task 5A",
                //                    },
                //                }
                //            },
                //            new TaskColumn
                //            {
                //                Id = 1,
                //                BoardId = 1,
                //                Title = "Column B",
                //                Description = "Description Column B",
                //                Cards = new List<TaskCard>
                //                {
                //                    new TaskCard
                //                    {
                //                        Id = 1,
                //                        ColumnId = 1,
                //                        Title = "Task 1B",
                //                        Description = "Description Task 1B",
                //                    }
                //                }
                //            },
                //            new TaskColumn
                //            {
                //                Id = 1,
                //                BoardId = 1,
                //                Title = "Column C",
                //                Description = "Description Column C",
                //                Cards = new List<TaskCard>
                //                {
                //                    new TaskCard
                //                    {
                //                        Id = 1,
                //                        ColumnId = 1,
                //                        Title = "Task 1C",
                //                        Description = "Description Task 1C",
                //                    },
                //                    new TaskCard
                //                    {
                //                        Id = 2,
                //                        ColumnId = 1,
                //                        Title = "Task 2C",
                //                        Description = "Description Task 2C",
                //                    }
                //                }
                //            },
                //            new TaskColumn
                //            {
                //                Id = 1,
                //                BoardId = 1,
                //                Title = "Column D",
                //                Description = "Description Column D",
                //                Cards = new List<TaskCard>
                //                {
                //                    new TaskCard
                //                    {
                //                        Id = 1,
                //                        ColumnId = 1,
                //                        Title = "First Board First Column First Card",
                //                        Description = "Description of the First Board First Column First Card",
                //                    },
                //                    new TaskCard
                //                    {
                //                        Id = 1,
                //                        ColumnId = 1,
                //                        Title = "First Board First Column First Card",
                //                        Description = "Description of the First Board First Column First Card",
                //                    },
                //                    new TaskCard
                //                    {
                //                        Id = 2,
                //                        ColumnId = 1,
                //                        Title = "First Board First Column Second Card",
                //                        Description = "Description of the First Board First Column Second Card",
                //                    },
                //                    new TaskCard
                //                    {
                //                        Id = 1,
                //                        ColumnId = 1,
                //                        Title = "First Board First Column First Card",
                //                        Description = "Description of the First Board First Column First Card",
                //                    },
                //                    new TaskCard
                //                    {
                //                        Id = 2,
                //                        ColumnId = 1,
                //                        Title = "First Board First Column Second Card",
                //                        Description = "Description of the First Board First Column Second Card",
                //                    },
                //                    new TaskCard
                //                    {
                //                        Id = 1,
                //                        ColumnId = 1,
                //                        Title = "First Board First Column First Card",
                //                        Description = "Description of the First Board First Column First Card",
                //                    },
                //                    new TaskCard
                //                    {
                //                        Id = 2,
                //                        ColumnId = 1,
                //                        Title = "First Board First Column Second Card",
                //                        Description = "Description of the First Board First Column Second Card",
                //                    },
                //                    new TaskCard
                //                    {
                //                        Id = 1,
                //                        ColumnId = 1,
                //                        Title = "First Board First Column First Card",
                //                        Description = "Description of the First Board First Column First Card",
                //                    },
                //                    new TaskCard
                //                    {
                //                        Id = 2,
                //                        ColumnId = 1,
                //                        Title = "First Board First Column Second Card",
                //                        Description = "Description of the First Board First Column Second Card",
                //                    },
                //                }
                //            },
                //            new TaskColumn
                //            {
                //                Id = 1,
                //                BoardId = 1,
                //                Title = "First Board First Column",
                //                Description = "Description of the First Board First Column",
                //                Cards = new List<TaskCard>
                //                {
                //                    new TaskCard
                //                    {
                //                        Id = 1,
                //                        ColumnId = 1,
                //                        Title = "First Board First Column First Card",
                //                        Description = "Description of the First Board First Column First Card",
                //                    },
                //                    new TaskCard
                //                    {
                //                        Id = 2,
                //                        ColumnId = 1,
                //                        Title = "First Board First Column Second Card",
                //                        Description = "Description of the First Board First Column Second Card",
                //                    },
                //                }
                //            },
                //            new TaskColumn
                //            {
                //                Id = 1,
                //                BoardId = 1,
                //                Title = "First Board First Column",
                //                Description = "Description of the First Board First Column",
                //                Cards = new List<TaskCard>
                //                {
                //                    new TaskCard
                //                    {
                //                        Id = 1,
                //                        ColumnId = 1,
                //                        Title = "First Board First Column First Card",
                //                        Description = "Description of the First Board First Column First Card",
                //                    },
                //                }
                //            },
                //            new TaskColumn
                //            {
                //                Id = 1,
                //                BoardId = 1,
                //                Title = "First Board First Column",
                //                Description = "Description of the First Board First Column",
                //                Cards = new List<TaskCard>
                //                {
                //                    new TaskCard
                //                    {
                //                        Id = 1,
                //                        ColumnId = 1,
                //                        Title = "First Board First Column First Card",
                //                        Description = "Description of the First Board First Column First Card",
                //                    },
                //                }
                //            },
                //            new TaskColumn
                //            {
                //                Id = 1,
                //                BoardId = 1,
                //                Title = "First Board First Column",
                //                Description = "Description of the First Board First Column",
                //                Cards = new List<TaskCard>
                //                {
                //                    new TaskCard
                //                    {
                //                        Id = 1,
                //                        ColumnId = 1,
                //                        Title = "First Board First Column First Card",
                //                        Description = "Description of the First Board First Column First Card",
                //                    },
                //                }
                //            },
                //        }
                //    },
                //};

            return list;
        }

        [HttpGet("{id}")]
        public async Task<Domain.Objects.Entities.TaskBoard> GetTaskBoard(string id)
        {
            var vm = await mediator.Send(new GetTaskBoardDetailQuery() { Id = id });
            
            //var mappedTaskCard = new TaskCard
            //{

            //}


            //var mapped = new TaskBoard
            //{
            //    Id = vm.Id,
            //    Title = vm.Title,
            //    Description = vm.Description,
            //    Columns = vm.Columns
            //};

            return vm;
        }

        [HttpPost]
        public async Task<TaskBoard> CreateTaskBoard(TaskBoard board)
        {
            var list = new TaskBoard();
            //    new TaskBoard
            //    {
            //        Id = 1,
            //        Title = "First Board",
            //        Description = "Description of the First Board",
            //        Columns = new List<TaskColumn>
            //{
            //                new TaskColumn
            //                {
            //                    Id = 1,
            //                    BoardId = 1,
            //                    Title = "First Board First Column",
            //                    Description = "Description of the First Board First Column",
            //                    Cards = new List<TaskCard>
            //                    {
            //                        new TaskCard
            //                        {
            //                            Id = 1,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column First Card",
            //                            Description = "Description of the First Board First Column First Card",
            //                        },
            //                        new TaskCard
            //                        {
            //                            Id = 2,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column Second Card",
            //                            Description = "Description of the First Board First Column Second Card",
            //                        },
            //                        new TaskCard
            //                        {
            //                            Id = 1,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column First Card",
            //                            Description = "Description of the First Board First Column First Card",
            //                        },
            //                        new TaskCard
            //                        {
            //                            Id = 2,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column Second Card",
            //                            Description = "Description of the First Board First Column Second Card",
            //                        },
            //                        new TaskCard
            //                        {
            //                            Id = 1,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column First Card",
            //                            Description = "Description of the First Board First Column First Card",
            //                        },
            //                        new TaskCard
            //                        {
            //                            Id = 2,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column Second Card",
            //                            Description = "Description of the First Board First Column Second Card",
            //                        },
            //                        new TaskCard
            //                        {
            //                            Id = 1,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column First Card",
            //                            Description = "Description of the First Board First Column First Card",
            //                        },
            //                        new TaskCard
            //                        {
            //                            Id = 2,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column Second Card",
            //                            Description = "Description of the First Board First Column Second Card",
            //                        },
            //                    }
            //                },
            //                new TaskColumn
            //                {
            //                    Id = 1,
            //                    BoardId = 1,
            //                    Title = "First Board First Column",
            //                    Description = "Description of the First Board First Column",
            //                    Cards = new List<TaskCard>
            //                    {
            //                        new TaskCard
            //                        {
            //                            Id = 1,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column First Card",
            //                            Description = "Description of the First Board First Column First Card",
            //                        }
            //                    }
            //                },
            //                new TaskColumn
            //                {
            //                    Id = 1,
            //                    BoardId = 1,
            //                    Title = "First Board First Column",
            //                    Description = "Description of the First Board First Column",
            //                    Cards = new List<TaskCard>
            //                    {
            //                        new TaskCard
            //                        {
            //                            Id = 1,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column First Card",
            //                            Description = "Description of the First Board First Column First Card",
            //                        },
            //                        new TaskCard
            //                        {
            //                            Id = 2,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column Second Card",
            //                            Description = "Description of the First Board First Column Second Card",
            //                        }
            //                    }
            //                },
            //                new TaskColumn
            //                {
            //                    Id = 1,
            //                    BoardId = 1,
            //                    Title = "First Board First Column",
            //                    Description = "Description of the First Board First Column",
            //                    Cards = new List<TaskCard>
            //                    {
            //                        new TaskCard
            //                        {
            //                            Id = 1,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column First Card",
            //                            Description = "Description of the First Board First Column First Card",
            //                        },
            //                        new TaskCard
            //                        {
            //                            Id = 1,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column First Card",
            //                            Description = "Description of the First Board First Column First Card",
            //                        },
            //                        new TaskCard
            //                        {
            //                            Id = 2,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column Second Card",
            //                            Description = "Description of the First Board First Column Second Card",
            //                        },
            //                        new TaskCard
            //                        {
            //                            Id = 1,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column First Card",
            //                            Description = "Description of the First Board First Column First Card",
            //                        },
            //                        new TaskCard
            //                        {
            //                            Id = 2,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column Second Card",
            //                            Description = "Description of the First Board First Column Second Card",
            //                        },
            //                        new TaskCard
            //                        {
            //                            Id = 1,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column First Card",
            //                            Description = "Description of the First Board First Column First Card",
            //                        },
            //                        new TaskCard
            //                        {
            //                            Id = 2,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column Second Card",
            //                            Description = "Description of the First Board First Column Second Card",
            //                        },
            //                        new TaskCard
            //                        {
            //                            Id = 1,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column First Card",
            //                            Description = "Description of the First Board First Column First Card",
            //                        },
            //                        new TaskCard
            //                        {
            //                            Id = 2,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column Second Card",
            //                            Description = "Description of the First Board First Column Second Card",
            //                        },
            //                    }
            //                },
            //                new TaskColumn
            //                {
            //                    Id = 1,
            //                    BoardId = 1,
            //                    Title = "First Board First Column",
            //                    Description = "Description of the First Board First Column",
            //                    Cards = new List<TaskCard>
            //                    {
            //                        new TaskCard
            //                        {
            //                            Id = 1,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column First Card",
            //                            Description = "Description of the First Board First Column First Card",
            //                        },
            //                        new TaskCard
            //                        {
            //                            Id = 2,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column Second Card",
            //                            Description = "Description of the First Board First Column Second Card",
            //                        },
            //                    }
            //                },
            //                new TaskColumn
            //                {
            //                    Id = 1,
            //                    BoardId = 1,
            //                    Title = "First Board First Column",
            //                    Description = "Description of the First Board First Column",
            //                    Cards = new List<TaskCard>
            //                    {
            //                        new TaskCard
            //                        {
            //                            Id = 1,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column First Card",
            //                            Description = "Description of the First Board First Column First Card",
            //                        },
            //                    }
            //                },
            //                new TaskColumn
            //                {
            //                    Id = 1,
            //                    BoardId = 1,
            //                    Title = "First Board First Column",
            //                    Description = "Description of the First Board First Column",
            //                    Cards = new List<TaskCard>
            //                    {
            //                        new TaskCard
            //                        {
            //                            Id = 1,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column First Card",
            //                            Description = "Description of the First Board First Column First Card",
            //                        },
            //                    }
            //                },
            //                new TaskColumn
            //                {
            //                    Id = 1,
            //                    BoardId = 1,
            //                    Title = "First Board First Column",
            //                    Description = "Description of the First Board First Column",
            //                    Cards = new List<TaskCard>
            //                    {
            //                        new TaskCard
            //                        {
            //                            Id = 1,
            //                            ColumnId = 1,
            //                            Title = "First Board First Column First Card",
            //                            Description = "Description of the First Board First Column First Card",
            //                        },
            //                    }
            //                },
            //}
            //    };

            return list;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> UpdateTaskBoard(int id)
        {
            return 2;
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTaskBoard(int id)
        {
            return Ok();
        }
    }
}