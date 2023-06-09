using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CSharpProject
{
    [TestClass]
    class DashBoard_Formtests
    {
        private IWebDriver _driver;
        private DashBoard_Form _dashboardForm;

        [SetUp]
        public void Setup()
        {
            // Create a new instance of the ChromeDriver
            _driver = new ChromeDriver();

            // Create an instance of the form
            _dashboardForm = new DashBoard_Form();
        }

        [Test]
        public void SlidePanel_ButtonClick_PanelSlides()
        {
            // Arrange
            var button1 = _driver.FindElement(By.Id("button1")); // Replace "button1" with the actual ID of the button
            var panelSide = _driver.FindElement(By.Id("panelSide")); // Replace "panelSide" with the actual ID of the panel

            // Act
            button1.Click();

            // Assert
            // Verify that the panel slides and its height and top position change as expected
            Assert.AreEqual(button1.Size.Height, panelSide.Size.Height);
            Assert.AreEqual(button1.Location.Y, panelSide.Location.Y);


        }


        [TearDown]
        public void TearDown()
        {
            // Dispose of the form and quit the driver
            _dashboardForm.Dispose();
            _driver.Quit();
        }
    }
}
