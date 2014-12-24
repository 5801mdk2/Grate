using System;
using Manager;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject
{
    /// <summary>
    /// Тест класса Vizualizator.
    /// </summary>
    [TestClass]
    public class VizualizatorTest
    {
        /// <summary>
        /// Тест открытия КОМПАС-3D.
        /// </summary>
        [TestMethod]
        public void OpenKompasTest()
        {
            var kompas = new Vizualizator();
            try
            {
                kompas.OpenKompas();
            }
            catch (Exception exception)
            {
                Assert.Fail("Expected no exception, but got: " + exception.Message);
            }
        }

        /// <summary>
        /// Тест yдачного докyмента.
        /// </summary>
        [TestMethod]
        public void CreateDocumenTest()
        {
            var kompas = new Vizualizator();
            try
            {
                kompas.OpenKompas();
                kompas.CreateDocument();
            }
            catch (Exception exception)
            {
                Assert.Fail("Expected no exception, but got: " + exception.Message);
            }
        }

        /// <summary>
        /// Тест закрытия докyмента
        /// </summary>
        [TestMethod]
        public void CloseDocumenTest()
        {
            var kompas = new Vizualizator();
            try
            {
                kompas.OpenKompas();
                kompas.CloseDocument();
            }
            catch (Exception exception)
            {
                Assert.Fail("Expected no exception, but got: " + exception.Message);
            }
        }
    }
}


     /*   /// <summary>
        /// Тест yдачного создания докyмента.
        /// </summary>
        [Test]
        public void CreateDocumentSuccesTest()
        {
            var kompas = new Kompas();
            Assert.DoesNotThrow(kompas.OpenKompas3D);
            Assert.DoesNotThrow(kompas.CreateDocument);
        }

        /// <summary>
        /// Тест неyдачного создания докyмента.
        /// </summary>
        [Test]
        public void CreateDocumentFailTest()
        {
            var kompas = new Kompas();
            
            Assert.Throws(typeof(NullReferenceException), kompas.CreateDocument);
        }

        /// <summary>
        /// Тест закрытия КОМПАСА-3D.
        /// </summary>
        [Test]
        public void CloseKompasSuccesTest()
        {
            var kompas = new Kompas();

            Assert.DoesNotThrow(kompas.OpenKompas3D);
            Assert.DoesNotThrow(kompas.CloseKompas3D);
        }

        /// <summary>
        /// Тест неyдачного закрытия КОМПАСА-3D.
        /// </summary>
        [Test]
        public void CloseKompasFailTest()
        {
            var kompas = new Kompas();

            Assert.Throws(typeof(NullReferenceException), kompas.CloseKompas3D);
        }

        /// <summary>
        /// Тест закрытия докyмента
        /// </summary>
        [Test]
        public void CloseDocumentTest()
        {
            var kompas = new Kompas();

            Assert.DoesNotThrow(OpenKompas3DTest);
            Assert.DoesNotThrow(kompas.CloseDocument);
        }*/