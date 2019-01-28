using AbstractFactory.Bottle;
using AbstractFactory.Water;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Factory
{
    public class PepsiColaFactory : AbstractFactory
    {
        public override AbstractBottle CreateBottle()
        {
            return new PepsiColaBottle();
        }

        public override AbstractWater CreateWater()
        {
            return new PepsiColaWater();
        }
    }
}
