﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITSourceManagement.Models
{
    public class PagerInfo
    {
        public int RecordCount { get; set; }

        public int CurrentPageIndex { get; set; }

        public int PageSize { get; set; }
    }
}