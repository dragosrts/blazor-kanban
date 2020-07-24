﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorKanban.Shared
{
    public class JobDto
    {
        public int Id { get; set; }
        public JobStatuses Status { get; set; }
        public string Description { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    public enum JobStatuses
    {
        Todo,
        Started,
        Completed
    }
}