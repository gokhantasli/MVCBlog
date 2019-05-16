﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.ENTITY
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public virtual List<Article> Articles { get; set; }
    }
}
