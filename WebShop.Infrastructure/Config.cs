﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Infrastructure
{
    public class Config : IConfig
    {
        public string ConnectionString { get; set; }
    }
}
