using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection
{
    public class NumGenerator : INumGenerator
    {
        public int GetRandomNumber()
        {
            return new Random().Next(1000);
        }
    }
}
