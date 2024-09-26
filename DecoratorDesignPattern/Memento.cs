using System;
using System.Collections.Generic;
using System.Text;                         
namespace DecoratorMementoDesignPattern
{
    //Memento Desing Patterns

    public class Memento
    {
        public HP hp { get; set; }
        public Memento ( HP hp)
        {
            this.hp = hp;
        }
        public string GetDetails()
        {
            return "Memento [HP " + hp.GetDetails() + "] ";
        }
    }
}
