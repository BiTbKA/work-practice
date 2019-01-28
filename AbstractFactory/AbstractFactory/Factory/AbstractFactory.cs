using AbstractFactory.Bottle;
using AbstractFactory.Water;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Factory
{
    public abstract class AbstractFactory
    {
        public abstract AbstractWater CreateWater();

        public abstract AbstractBottle CreateBottle();
    }
}
