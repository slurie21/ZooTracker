﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooTracker.Models.Entity
{
    public class Zoo
    {
        [Key]
        public int Id { get; set; }
    }
}
