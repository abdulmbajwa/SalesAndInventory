﻿using System.Collections.Generic;

namespace SalesInventory.Core.DomainModels
{
    public class Page<T>
    {
        public long CurrentPage { get; set; }

        public long ItemsPerPage { get; set; }

        public long TotalPages { get; set; }

        public long TotalItems { get; set; }

        public List<T> Items { get; set; }
    }
}
