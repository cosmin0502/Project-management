using System;
using System.Collections.Generic;
using Autofac.Extras.Moq;
using DemoLibrary.Logic;
using DemoLibrary.Models;
using DemoLibrary.Utilities;
using Moq;
using Xunit;

namespace Tests.Logic
{
    public class LaptopProcessorTests
    {
        [Theory]
        [InlineData("6'8\"", true, 80)]
        [InlineData("6\"8'", false, 0)]
        [InlineData("six'eight\"", false, 0)]
        public void ConvertHeightTextToInches_VariousOptions(
            string heightText,
            bool expectedIsValid,
            double expectedDisplayInInches)
        {
            LaptopProcessor processor = new LaptopProcessor(null);

            var actual = processor.ConvertHeightTextToInches(heightText);

            Assert.Equal(expectedIsValid, actual.isValid);
            Assert.Equal(expectedDisplayInInches, actual.heightInInches);
        }

        [Theory]
        [InlineData("HP", "Red", "15\"", 80)]
        [InlineData("Asus", "Silver", "15\"", 64)]
        public void CreateLaptop_Successful(string brandName, string colorName, string heightText, double expectedHeight)
        {
            LaptopProcessor processor = new LaptopProcessor(null);

            LaptopModel expected = new LaptopModel
            {
                BrandName = brandName,
                ColorName = colorName,
                DisplayInInches = expectedHeight,
                Id = 0
            };

            var actual = processor.CreateLaptop(brandName, colorName, heightText);

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.BrandName, actual.ColorName);
            Assert.Equal(expected.ColorName, actual.ColorName);
            Assert.Equal(expected.DisplayInInches, actual.DisplayInInches);

        }

        [Theory]
        [InlineData("HP#", "Red1", "6'8\"", "firstName")]
        [InlineData("Asus", "Silver4", "5'4\"", "lastName")]
        [InlineData("Jonnn", "Coooorey", "Twelve", "heightText")]
        public void CreateLaptop_ThrowsException(string brandName, string colorName, string heightText, string expectedInvalidParameter)
        {
            LaptopProcessor processor = new LaptopProcessor(null);

            var ex = Record.Exception(() => processor.CreateLaptop(brandName, colorName, heightText));

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
            if (ex is ArgumentException argEx)
            {
                Assert.Equal(expectedInvalidParameter, argEx.ParamName);
            }

        }

        [Fact]
        public void LoadLaptop_ValidCall()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<ISqliteDataAccess>()
                    .Setup(x => x.LoadData<LaptopModel>("select * from Laptop"))
                    .Returns(GetSamplePeople());

                var cls = mock.Create<LaptopProcessor>();
                var expected = GetSamplePeople();

                var actual = cls.LoadLaptop();

                Assert.True(actual != null);
                Assert.Equal(expected.Count, actual.Count);

                for (int i = 0; i < expected.Count; i++)
                {
                    Assert.Equal(expected[i].BrandName, actual[i].BrandName);
                    Assert.Equal(expected[i].ColorName, actual[i].ColorName);
                }
            }
        }

        [Fact]
        public void SaveLaptop_ValidCall()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var laptop = new LaptopModel
                {
                    Id = 1,
                    BrandName = "HP",
                    ColorName = "Red",
                    DisplayInInches = 80
                };
                string sql = "insert into Laptop (BrandName, ColorName, DisplayInInches) " +
                "values ('HP', 'Red', 80)";

                mock.Mock<ISqliteDataAccess>()
                    .Setup(x => x.SaveData(laptop, sql));

                var cls = mock.Create<LaptopProcessor>();

                cls.SaveLaptop(laptop);

                mock.Mock<ISqliteDataAccess>()
                    .Verify(x => x.SaveData(laptop, sql), Times.Exactly(1));

            }
        }

        private List<LaptopModel> GetSamplePeople()
        {
            List<LaptopModel> output = new List<LaptopModel>
            {
                new LaptopModel
                {
                    BrandName = "HP",
                    ColorName = "Red"
                },
                new LaptopModel
                {
                    BrandName = "Asus",
                    ColorName = "Silver"
                },
                new LaptopModel
                {
                    BrandName = "Samsung",
                    ColorName = "White"
                },
                new LaptopModel
                {
                    BrandName = "Lenovo",
                    ColorName = "Black"
                }
            };

            return output;
        }
    }
}
