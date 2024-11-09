﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public interface IOrderable
    {
        string Name { get; }
        double Price { get; }
        void PrintDetails();
    }
}