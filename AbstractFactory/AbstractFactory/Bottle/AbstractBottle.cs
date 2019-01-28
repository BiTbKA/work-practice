using AbstractFactory.Water;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.Bottle
{
    public abstract class AbstractBottle
    {
        public abstract void Interact(AbstractWater water);
    }
}
