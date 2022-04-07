using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;                    

namespace DecoratorMementoDesignPattern
{
    // DecoratorDesignPattern

    public class HPLaptop : ILaptop
    {
        private string LaptopName = "HP";
        public string LaptopMaterials { get; set; }
        public string LaptopCameraFront { get; set; }        
        public string LaptopOperatingSystem { get; set; }

        public override string ToString()
        {
            return " LAPTOP [LaptopName: " + LaptopName + ", Materials= " + LaptopMaterials + " , " +
                "LaptopCameraFront= " + LaptopCameraFront + " , " + "LaptopOperatingSystem= " + LaptopOperatingSystem + "] ";
        }

        public ILaptop ComponentsLaptop()
        {
            LaptopMaterials = " Glass,Metal,Plastic ";
            LaptopCameraFront = " One camera front ";            
            LaptopOperatingSystem = " Windows ";
            return this;
        }


    }
}