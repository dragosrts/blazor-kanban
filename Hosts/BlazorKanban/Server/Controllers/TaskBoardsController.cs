using BlazorKanban.Shared;
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
        private readonly ILogger<BoardsController> logger;

        public TaskBoardsController(ILogger<BoardsController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<TaskBoard>> GetTaskBoards()
        {
            var list =
                new List<TaskBoard>
                {
                    new TaskBoard
                    {
                        Id = 1,
                        Title = "First Board",
                        Description = "Description of the First Board",
                        Columns = new List<TaskColumn>
                        {
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                }
                            },
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    }
                                }
                            },
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    }
                                }
                            },
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                }
                            },
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                }
                            },
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                }
                            },
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                }
                            },
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                }
                            },
                        }
                    },
                    //new TaskBoard
                    //{
                    //    Id = 1,
                    //    Title = "First Board",
                    //    Description = "Description of the First Board",
                    //    Columns = new List<TaskColumn>
                    //    {
                    //        new TaskColumn
                    //        {
                    //            Id = 1,
                    //            BoardId = 1,
                    //            Title = "First Board First Column",
                    //            Description = "Description of the First Board First Column",
                    //            Cards = new List<TaskCard>
                    //            {
                    //                new TaskCard
                    //                {
                    //                    Id = 1,
                    //                    ColumnId = 1,
                    //                    Title = "First Board First Column First Card",
                    //                    Description = "Description of the First Board First Column First Card",
                    //                }
                    //            }
                    //        }
                    //    }
                    //},
                    //new TaskBoard
                    //{
                    //    Id = 1,
                    //    Title = "First Board",
                    //    Description = "Description of the First Board",
                    //    Columns = new List<TaskColumn>
                    //    {
                    //        new TaskColumn
                    //        {
                    //            Id = 1,
                    //            BoardId = 1,
                    //            Title = "First Board First Column",
                    //            Description = "Description of the First Board First Column",
                    //            Cards = new List<TaskCard>
                    //            {
                    //                new TaskCard
                    //                {
                    //                    Id = 1,
                    //                    ColumnId = 1,
                    //                    Title = "First Board First Column First Card",
                    //                    Description = "Description of the First Board First Column First Card",
                    //                }
                    //            }
                    //        }
                    //    },
                    //},
                    //new TaskBoard
                    //{
                    //    Id = 1,
                    //    Title = "First Board",
                    //    Description = "Description of the First Board",
                    //    Columns = new List<TaskColumn>
                    //    {
                    //        new TaskColumn
                    //        {
                    //            Id = 1,
                    //            BoardId = 1,
                    //            Title = "First Board First Column",
                    //            Description = "Description of the First Board First Column",
                    //            Cards = new List<TaskCard>
                    //            {
                    //                new TaskCard
                    //                {
                    //                    Id = 1,
                    //                    ColumnId = 1,
                    //                    Title = "First Board First Column First Card",
                    //                    Description = "Description of the First Board First Column First Card",
                    //                }
                    //            }
                    //        }
                    //    },
                    //},
                    //new TaskBoard
                    //{
                    //    Id = 1,
                    //    Title = "First Board",
                    //    Description = "Description of the First Board",
                    //    Columns = new List<TaskColumn>
                    //    {
                    //        new TaskColumn
                    //        {
                    //            Id = 1,
                    //            BoardId = 1,
                    //            Title = "First Board First Column",
                    //            Description = "Description of the First Board First Column",
                    //            Cards = new List<TaskCard>
                    //            {
                    //                new TaskCard
                    //                {
                    //                    Id = 1,
                    //                    ColumnId = 1,
                    //                    Title = "First Board First Column First Card",
                    //                    Description = "Description of the First Board First Column First Card",
                    //                }
                    //            }
                    //        }
                    //    },
                    //},
                    //new TaskBoard
                    //{
                    //    Id = 1,
                    //    Title = "First Board",
                    //    Description = "Description of the First Board",
                    //    Columns = new List<TaskColumn>
                    //    {
                    //        new TaskColumn
                    //        {
                    //            Id = 1,
                    //            BoardId = 1,
                    //            Title = "First Board First Column",
                    //            Description = "Description of the First Board First Column",
                    //            Cards = new List<TaskCard>
                    //            {
                    //                new TaskCard
                    //                {
                    //                    Id = 1,
                    //                    ColumnId = 1,
                    //                    Title = "First Board First Column First Card",
                    //                    Description = "Description of the First Board First Column First Card",
                    //                }
                    //            }
                    //        }
                    //    },
                    //},
                    //new TaskBoard
                    //{
                    //    Id = 1,
                    //    Title = "First Board",
                    //    Description = "Description of the First Board",
                    //    Columns = new List<TaskColumn>
                    //    {
                    //        new TaskColumn
                    //        {
                    //            Id = 1,
                    //            BoardId = 1,
                    //            Title = "First Board First Column",
                    //            Description = "Description of the First Board First Column",
                    //            Cards = new List<TaskCard>
                    //            {
                    //                new TaskCard
                    //                {
                    //                    Id = 1,
                    //                    ColumnId = 1,
                    //                    Title = "First Board First Column First Card",
                    //                    Description = "Description of the First Board First Column First Card",
                    //                }
                    //            }
                    //        }
                    //    },
                    //},
                };

            return list;
        }

        [HttpGet("{id:int}")]
        public async Task<TaskBoard> GetTaskBoard(int Id)
        {
            var list =
                new TaskBoard
                {
                    Id = 1,
                    Title = "First Board",
                    Description = "Description of the First Board",
                    Columns = new List<TaskColumn>
                        {
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                }
                            },
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    }
                                }
                            },
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    }
                                }
                            },
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                }
                            },
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                }
                            },
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                }
                            },
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                }
                            },
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                }
                            },
                        }
                };

            return list;
        }

        [HttpPost]
        public async Task<TaskBoard> CreateTaskBoard(TaskBoard board)
        {
            var list =
                new TaskBoard
                {
                    Id = 1,
                    Title = "First Board",
                    Description = "Description of the First Board",
                    Columns = new List<TaskColumn>
            {
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                }
                            },
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    }
                                }
                            },
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    }
                                }
                            },
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                }
                            },
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                    new TaskCard
                                    {
                                        Id = 2,
                                        ColumnId = 1,
                                        Title = "First Board First Column Second Card",
                                        Description = "Description of the First Board First Column Second Card",
                                    },
                                }
                            },
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                }
                            },
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                }
                            },
                            new TaskColumn
                            {
                                Id = 1,
                                BoardId = 1,
                                Title = "First Board First Column",
                                Description = "Description of the First Board First Column",
                                Cards = new List<TaskCard>
                                {
                                    new TaskCard
                                    {
                                        Id = 1,
                                        ColumnId = 1,
                                        Title = "First Board First Column First Card",
                                        Description = "Description of the First Board First Column First Card",
                                    },
                                }
                            },
            }
                };

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