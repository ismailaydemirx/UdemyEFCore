﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyEFCore.CodeFirst.DAL
{
    [Keyless]
    public class Person 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}