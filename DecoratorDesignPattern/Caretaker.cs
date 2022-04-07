using System;
using System.Collections.Generic;
using System.Text;                          

namespace DecoratorMementoDesignPattern
{
    //Memento Desing Patterns

    public class Caretaker
    {
        private List<Memento> hplist = new List<Memento>();
        public void AddMemento(Memento m)
        {
            hplist.Add(m);
            Console.WriteLine("HP is snapshots maintained by caretaker: " + m.GetDetails());
        }
        public Memento GetMemento(int index)
        {
            return hplist[index];
        }
    }
}
