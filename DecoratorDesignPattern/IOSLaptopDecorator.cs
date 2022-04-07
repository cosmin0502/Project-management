using System;
using System.Collections.Generic;
using System.Text;                    

namespace DecoratorMementoDesignPattern
{
    // DecoratorDesignPattern
    public class IOSLaptopDecorator : LaptopDecorator
    {
        public IOSLaptopDecorator(ILaptop Laptop) : base(Laptop)
        {

        }
        public override ILaptop ComponentsLaptop()
        {
            Laptop.ComponentsLaptop();
            AddLaptopOperatingSystem(Laptop);
            return Laptop;
        }

        public void AddLaptopOperatingSystem(ILaptop Laptop)
        {
            if (Laptop is HPLaptop)
            {
                HPLaptop HPLaptop = (HPLaptop)Laptop;
                HPLaptop.LaptopOperatingSystem = " IOS Laptop Operating System";
                Console.WriteLine(" IOS Laptop Decorator add IOS Laptop Operating System to the Laptop :" + Laptop);
            }
        }

    }
}
