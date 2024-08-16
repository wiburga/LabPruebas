using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V125.Page;

namespace MSTestUnit
{
    [TestClass]
    public class UnitTest1
    {
        /*By googleSearchBar = By.Id("APjFqb");
        By googleButtonClick = By.Name("btnK");
        //By resultGoogleSearch = By.Id("_HFy7ZqKZCquOwbkP9p_24QE_31");
        By resultGoogleSearch = By.Id("rcnt");*/

        int tiempoEspera = 3000;

        private readonly IWebDriver driver;

        public UnitTest1()
        {
            driver = new ChromeDriver();
        }

        public void Dispose()
        {
            driver.Quit();
            driver.Dispose();
        }

        //[TestMethod]
        //public void TestPageGoogle()
        //{
        //    IWebDriver driver = new ChromeDriver();

        //    driver.Manage().Window.Maximize();

        //    driver.Navigate().GoToUrl("https://www.google.com");

        //    Thread.Sleep(tiempoEspera);

        //    driver.FindElement(googleSearchBar).SendKeys("Visual Studio Code");

        //    Thread.Sleep(tiempoEspera);

        //    driver.FindElement(googleButtonClick).Click();

        //    Thread.Sleep(tiempoEspera);

        //    var resultadoBusqueda = driver.FindElement(resultGoogleSearch);

        //    Assert.IsNotNull(resultadoBusqueda);

        //    driver.Quit();

        //}

        #region Pruebas de Crear Cliente
        By ButtonCreate = By.ClassName("btn-success");

        [TestMethod]
        public void Create_Get_ReturnCreateView()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            Thread.Sleep(tiempoEspera);

            driver.Navigate().GoToUrl("https://localhost:7002/Cliente/Create");

            Thread.Sleep(tiempoEspera);

            driver.FindElement(By.Name("cedula")).SendKeys("1750424051");
            driver.FindElement(By.Name("apellidos")).SendKeys("BURGA");
            driver.FindElement(By.Name("nombres")).SendKeys("ISAIAS");
            driver.FindElement(By.Name("fechaNacimiento")).SendKeys("17/07/1999");
            driver.FindElement(By.Name("mail")).SendKeys("wiburga@espe.edu.ec");
            driver.FindElement(By.Name("Telefono")).SendKeys("0962923294");
            driver.FindElement(By.Name("Direccion")).SendKeys("CALDERON");
            IWebElement checkbox = driver.FindElement(By.Name("Estado"));
            if (!checkbox.Selected)
            {
                checkbox.Click();
            }

            Thread.Sleep(tiempoEspera);

            driver.FindElement(ButtonCreate).Click();

            Thread.Sleep(tiempoEspera);

            bool clienteCreado = driver.PageSource.Contains("1750424051");

            Assert.IsTrue(clienteCreado);
        }
        #endregion

        #region Pruebas de Actualizar Cliente

        By ButtonUpdate = By.ClassName("btn-info");

        [TestMethod]
        public void Update_Get_ReturnUpdateView()
        {
            //IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            Thread.Sleep(tiempoEspera);

            driver.Navigate().GoToUrl("https://localhost:7002/Cliente");

            Thread.Sleep(tiempoEspera);

            driver.FindElement(ButtonUpdate).Click();

            Thread.Sleep(tiempoEspera);

            driver.FindElement(By.Name("Direccion")).Clear();
            driver.FindElement(By.Name("Direccion")).SendKeys("Mariscal Sucre y Michelena");
            IWebElement checkbox = driver.FindElement(By.Name("Estado"));
            checkbox.Click();

            Thread.Sleep(tiempoEspera);

            driver.FindElement(ButtonCreate).Click();

            Thread.Sleep(tiempoEspera);

            bool clienteActualizado = driver.PageSource.Contains("Mariscal Sucre y Michelena");

            Assert.IsTrue(clienteActualizado);
        }
        #endregion

        #region Pruebas de Eliminar Cliente

        By ButtonDelete = By.ClassName("btn-danger");

        [TestMethod]
        public void Delete_Get_ReturnDeleteView()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            Thread.Sleep(tiempoEspera);

            driver.Navigate().GoToUrl("https://localhost:7002/Cliente");

            Thread.Sleep(tiempoEspera);

            IWebElement deleteButton = driver.FindElement(By.XPath("//a[contains(@href, '/Cliente/Delete/5')]"));
            deleteButton.Click();

            Thread.Sleep(tiempoEspera);

            driver.FindElement(ButtonDelete).Click();

            bool clienteEliminado = !driver.PageSource.Contains("1709909458");

            Assert.IsTrue(clienteEliminado);

            driver.Quit();
        }
        #endregion

        #region Pruebas de Ver Cliente

        [TestMethod]
        public void View_Get_ReturnGetView()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            Thread.Sleep(tiempoEspera);

            driver.Navigate().GoToUrl("https://localhost:7002/");

            Thread.Sleep(tiempoEspera);

            IWebElement ViewButton = driver.FindElement(By.XPath("//a[contains(@href, '/Cliente')]"));
            ViewButton.Click();

            Thread.Sleep(tiempoEspera);

            IWebElement table = driver.FindElement(By.CssSelector(".table.table-head-fixed.table-hover.text-nowrap"));

            IWebElement tbody = table.FindElement(By.TagName("tbody"));

            var rows = tbody.FindElements(By.TagName("tr"));

            Assert.IsTrue(rows.Count > 0, "La tabla está vacía. La prueba falló.");

            driver.Quit();
        }
        #endregion
    }
}

