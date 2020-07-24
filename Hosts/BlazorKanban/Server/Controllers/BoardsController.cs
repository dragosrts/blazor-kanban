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
        public async Task<IEnumerable<TaskBoard>> Get()
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
    }
}