using System;
using System.Collections.Generic;
using System.Text;                    

namespace DecoratorMementoDesignPattern
{
    // DecoratorDesignPattern
    public abstract class LaptopDecorator : ILaptop
    {
        protected ILaptop Laptop;
        public LaptopDecorator(ILaptop Laptop)
        {
            this.Laptop = Laptop;
        }

        public virtual ILaptop ComponentsLaptop()
        {
            return Laptop.ComponentsLaptop();
        }

    }
}
