using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataControllManager;
namespace UnitTestProject
{
    [TestClass]
    public class UnitTestGrateDiscription
    {
        /// <summary>
        /// Тестовые данные исключения MinMax высоты фундамента
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestHeightFoundationArgumentBound()
        {
            var grateDiscription = new GrateDiscription();
                grateDiscription.FoundationHeight = 30; //аргумент вне [15; 20]
        }

        /// <summary>
        /// Тестовые данные исключения MinMax ширины фундамента
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException))]
        public void TestWidthFoundationArgumentBound()
        {
            var grateDiscription = new GrateDiscription();
            {
                grateDiscription.FoundationWidth = 100; //аргумент вне [60; 80]
            }
        }

        /// <summary>
        /// Тестовые данные для исключения на соотношение параметров ширины и высоты фундамента
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void TestWidthFoundationArgument()
        {
            var grateDiscription = new GrateDiscription();
            {
                grateDiscription.FoundationHeight = 20;
                grateDiscription.FoundationWidth = 60;//ложный аргумент
            }
        }
        
        /// <summary>
        /// Тестовые данные исключения MinMax для длины фундамента
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestFoundationLengthBound()
        {
            var grateDiscription = new GrateDiscription();
            {
                grateDiscription.FoundationLength = 40; //аргумент вне [45; 60]
            }
        }

        /// <summary>
        /// Тестовые данные для исключения на соотношение параметров длины и высоты фундамента
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestLengthFoundationArgument()
        {
            var grateDiscription = new GrateDiscription();
            {
                grateDiscription.FoundationHeight = 20;
                grateDiscription.FoundationLength = 45;//ложный аргумент
            }
        }


        /// <summary>
        /// Тестовые данные исключения MinMax для высоты надфундаментной плиты
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestFoundationPlateHeightBound()
        {
            var grateDiscription = new GrateDiscription();
            {
                grateDiscription.FoundationPlateHeight = 12; //аргумент вне [7,5; 10]
            }
        }

        /// <summary>
        /// Тестовые данные для исключения на соотношение параметров высоты надфундаментной плиты и высоты фундамента
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestHeightFoundationPlateArgument()
        {
            var grateDiscription = new GrateDiscription();
            {
                grateDiscription.FoundationHeight = 15;
                grateDiscription.FoundationPlateHeight = 8;//ложный аргумент
            }
        }

        /// <summary>
        /// Тестовые данные исключения MinMax для ширины надфундаментной плиты
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestFoundationPlateWidthBound()
        {
            var grateDiscription = new GrateDiscription();
            {
                grateDiscription.FoundationPlateWidth = 120; //аргумент вне [80; 100]
            }
        }

        /// <summary>
        /// Тестовые данные для исключения на соотношение параметров ширины надфундаментной плиты и ширины фундамента
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWidthFoundationPlateArgument()
        {
            var grateDiscription = new GrateDiscription();
            {
                grateDiscription.FoundationWidth = 80;
                grateDiscription.FoundationPlateWidth = 80;//ложный аргумент
            }
        }

        /// <summary>
        /// Тестовые данные исключения MinMax для длины надфундаментной плиты
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestFoundationPlateLengthBound()
        {
            var grateDiscription = new GrateDiscription();
            {
                grateDiscription.FoundationPlateLength = 60; //аргумент вне [65; 80]
            }
        }

        /// <summary>
        /// Тестовые данные для исключения на соотношение параметров длины надфундаментной плиты и длины фундамента
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestLengthFoundationPlateArgument()
        {
            var grateDiscription = new GrateDiscription();
            {
                grateDiscription.FoundationLength = 60;
                grateDiscription.FoundationPlateLength = 70;//ложный аргумент
            }
        }

        /// <summary>
        /// Тестовые данные исключения MinMax для высоты печного блока
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestFurnaceBlockHeightBound()
        {
            var grateDiscription = new GrateDiscription();
            {
                grateDiscription.FurnaceBlockHeight = 60; //аргумент вне [40; 50]
            }
        }

        /// <summary>
        /// Тестовые данные исключения MinMax для ширины печного блока
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestFurnaceBlockWidthBound()
        {
            var grateDiscription = new GrateDiscription();
            {
                grateDiscription.FurnaceBlockWidth = 40; //аргумент вне [50; 70]
            }
        }

        /// <summary>
        /// Тестовые данные для исключения на соотношение параметров ширины печного блока и ширины фундамента
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWidthFurnaceBlockArgument()
        {
            var grateDiscription = new GrateDiscription();
            {
                grateDiscription.FoundationWidth = 60;
                grateDiscription.FurnaceBlockWidth = 60;//ложный аргумент
            }
        }

        /// <summary>
        /// Тестовые данные исключения MinMax для длины печного блока
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestFurnaceBlockLengthBound()
        {
            var grateDiscription = new GrateDiscription();
            {
                grateDiscription.FurnaceBlockLength = 60; //аргумент вне [40; 55]
            }
        }

        /// <summary>
        /// Тестовые данные для исключения на соотношение параметров длины печного блока и длины фундамента
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestLengthFurnaceBlockArgument()
        {
            var grateDiscription = new GrateDiscription();
            {
                grateDiscription.FoundationLength = 55;
                grateDiscription.FurnaceBlockLength = 55;//ложный аргумент
            }
        }

        /// <summary>
        /// Тестовые данные исключения MinMax для высотф трубы
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TesеPipeHeightBound()
        {
            var grateDiscription = new GrateDiscription();
            {
                grateDiscription.PipeHeight = 60; //аргумент вне [80; 100]
            }
        }
        /// <summary>
        /// Тестовые данные исключения MinMax для высоты огранки трубы
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMantelHeightBound()
        {
            var grateDiscription = new GrateDiscription();
            {
                grateDiscription.MantelHeight = 60; //аргумент вне [15; 30]
            }
        }
    }
}
