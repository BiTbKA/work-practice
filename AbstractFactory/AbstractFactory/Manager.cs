using AbstractFactory.Bottle;
using AbstractFactory.Water;
using AbstractFactory.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class Manager
    {
        protected AbstractWater water;
        protected AbstractBottle bottle;

        public Manager(AbstractFactory.Factory.AbstractFactory factory)
        {
            water = factory.CreateWater();
            bottle = factory.CreateBottle();
        }

        public void Run()
        {
            bottle.Interact(water);
        }
    }
}
