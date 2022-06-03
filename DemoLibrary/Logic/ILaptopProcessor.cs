using System.Collections.Generic;
using DemoLibrary.Models;

namespace DemoLibrary.Logic
{
    public interface ILaptopProcessor
    {
        (bool isValid, double heightInInches) ConvertHeightTextToInches(string heightText);
        LaptopModel CreateLaptop(string brandName, string colorName, string heightText);
        List<LaptopModel> LoadLaptop();
        void SaveLaptop(LaptopModel person);
        void UpdateLaptop(LaptopModel person);
    }
}