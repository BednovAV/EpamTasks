﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._1._2.Figures.Exceptions
{
    class IncorrectRadiusExeption : ArgumentException
    {
        public IncorrectRadiusExeption(string message) : base(message) { }
    }
}
