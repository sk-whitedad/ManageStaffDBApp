﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStaffDBApp.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Position> Positions { get; set; }

    }
}
