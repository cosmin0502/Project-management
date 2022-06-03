using DemoLibrary.Logic;
using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class Application : IApplication
    {
        ILaptopProcessor _laptopProcessor;

        public Application(ILaptopProcessor laptopProcessor)
        {
            _laptopProcessor = laptopProcessor;
        }

        public void Run()
        {
            IdentifyNextStep();
        }

        private void IdentifyNextStep()
        {
            string selectedAction = "";

            do
            {
                selectedAction = GetActionChoice();

                Console.WriteLine();

                switch (selectedAction)
                {
                    case "1":
                        DisplayLaptops(_laptopProcessor.LoadLaptop());
                        break;
                    case "2":
                        AddLaptop();
                        break;
                    case "3":
                        Console.WriteLine("Thanks for using this application");
                        break;
                    default:
                        Console.WriteLine("That was an invalid choice. Hit enter and try again.");
                        break;
                }

                Console.WriteLine("Hit return to continue...");
                Console.ReadLine();

            } while (selectedAction != "3");
        }

        private void AddLaptop()
        {
            Console.Write("What is the brand for the laptop: ");
            string brandName = Console.ReadLine();
            Console.Write("What is the colour: ");
            string colorName = Console.ReadLine();
            Console.Write("What is the memory in GB: ");
            string height = Console.ReadLine();

            var person = _laptopProcessor.CreateLaptop(brandName, colorName, height);
            _laptopProcessor.SaveLaptop(person);
        }

        private void DisplayLaptops(List<LaptopModel> laptop)
        {
            foreach (var p in laptop)
            {
                Console.WriteLine(p.FullLaptop);
            }
        }

        private string GetActionChoice()
        {
            string output = "";

            Console.Clear();
            Console.WriteLine("Menu Options".ToUpper());
            Console.WriteLine("1 - Load Laptops");
            Console.WriteLine("2 - Create and Save Laptops");
            Console.WriteLine("3 - Exit");
            Console.Write("What would you like to choose: ");
            output = Console.ReadLine();

            return output;
        }
    }
}
