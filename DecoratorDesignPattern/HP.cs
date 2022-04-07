using System;
using System.Collections.Generic;
using System.Text;                                      

namespace DecoratorMementoDesignPattern
{
    //Memento Desing Patterns
    public class HP
    {
        public string Size { get; set; }
        public string Price { get; set; }
        public string Memory { get; set; }
        public string CameraFront { get; set; }      

        public HP(string Size, string Price, String Memory, String CameraFront)
        {
            this.Size = Size;
            this.Price = Price;
            this.Memory = Memory;
            this.CameraFront = CameraFront;         
        }

        public string GetDetails()
        {
            return "Samsung [Size= " + Size + ", Price= " + Price + ", Memory= " + Memory + "," +" CameraFront= " + CameraFront + "] ";
        }
    }
}
