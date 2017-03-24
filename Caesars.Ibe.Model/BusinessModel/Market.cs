﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caesars.Ibe.Model.BusinessModel
{
    public class Market
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public List<Branch> BranchList { get; set; }

    }
}
