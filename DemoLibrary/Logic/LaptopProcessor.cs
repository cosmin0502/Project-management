using DemoLibrary.Models;
using DemoLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary.Logic
{
    public class LaptopProcessor : ILaptopProcessor
    {
        ISqliteDataAccess _database;

        public LaptopProcessor(ISqliteDataAccess database)
        {
            _database = database;
        }

        public LaptopModel CreateLaptop(string brandName, string colorName, string heightText)
        {
            LaptopModel output = new LaptopModel();

            if (ValidateName(brandName) == true)
            {
                output.BrandName = brandName;
            }
            else
            {
                throw new ArgumentException("The value was not valid", "brandName");
            }

            if (ValidateName(colorName) == true)
            {
                output.ColorName = colorName;
            }
            else
            {
                throw new ArgumentException("The value was not valid", "colorName");
            }

            var height = ConvertHeightTextToInches(heightText);

            if (height.isValid == true)
            {
                output.DisplayInInches = height.heightInInches;
            }
            else
            {
                throw new ArgumentException("The value was not valid", "heightText");
            }

            return output;
        }

        public List<LaptopModel> LoadLaptop()
        {
            string sql = "select * from Laptop";

            var output = _database.LoadData<LaptopModel>(sql);

            return output;
        }

        public void SaveLaptop(LaptopModel laptop)
        {
            string sql = "insert into Laptop (BrandName, ColorName, DisplayInInches) " +
                "values (@BrandName, @ColorName, @DisplayInInches)";

            sql = sql.Replace("@BrandName", $"'{laptop.BrandName}'");
            sql = sql.Replace("@ColorName", $"'{laptop.ColorName}'");
            sql = sql.Replace("@DisplayInInches", $"{laptop.DisplayInInches}");

            _database.SaveData(laptop, sql);
        }

        public void UpdateLaptop(LaptopModel laptop)
        {
            string sql = "update Laptop set BrandName = @BrandName, ColorName = @ColorName" +
                ", DisplayInInches = @DisplayInInches where Id = @Id";

            _database.UpdateData(laptop, sql);
        }

        public (bool isValid, double heightInInches) ConvertHeightTextToInches(string heightText)
        {
            bool isValid = true;
            double heightInInches = 0;

            int feetMarkerLocation = heightText.IndexOf('\'');
            int inchesMarkerLocation = heightText.IndexOf('"');

            if (feetMarkerLocation < 0
                || inchesMarkerLocation < 0
                || inchesMarkerLocation < feetMarkerLocation)
            {
                return (false, 0);
            }

            // Split on both the feet and inches indicators
            string[] heightParts = heightText.Split(new char[] { '\'', '"' });


            // Part 0 should be feet, part 1 should be inches
            if (int.TryParse(heightParts[0], out int feet) == false
                || double.TryParse(heightParts[1], out double inches) == false)
            {
                return (false, 0);
            }

            heightInInches = (feet * 12) + inches;

            return (isValid, heightInInches);
        }

        private bool ValidateName(string name)
        {
            bool output = true;
            char[] invalidCharacters = "`~!@#$%^&*()_+=0123456789<>,.?/\\|{}[]'\"".ToCharArray();

            if (name.Length < 2)
            {
                output = false;
            }

            if (name.IndexOfAny(invalidCharacters) >= 0)
            {
                output = false;
            }

            return output;
        }
    }
}
