﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLib.Models
{
    public class PaginatedResponse<T>
    {
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public List<T> Data { get; set; }
    }
}
