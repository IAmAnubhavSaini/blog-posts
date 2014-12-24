using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzFizzBuzz
{
    public class Sayer : ISaySomething
    {
        protected string WhatToSay { get; set; }
        protected int Divisor { get; set; }
        protected int Number { get; set; }

        public virtual string Say()
        {
            return Number.ToString();
        }

        public bool ShouldSay()
        {
            return Number%Divisor == 0;
        }
    }
}
