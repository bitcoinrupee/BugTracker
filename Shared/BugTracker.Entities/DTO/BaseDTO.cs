﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Entities.DTO
{
    public abstract class  BaseDTO
    {
       
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
