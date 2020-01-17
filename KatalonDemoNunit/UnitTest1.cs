using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System;

namespace KatalonDemoNunit
{
 
    public class UnitTest1
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void TestMethod1()
        {
            


            /*driver.Navigate().GoToUrl("http://apps.supernet.bo/ic/Autentication.aspx");
            Thread.Sleep(500);
            driver.FindElement(By.Id("IFMainContent_txtLogin")).Click();
            driver.FindElement(By.Id("IFMainContent_txtLogin")).Clear();
            driver.FindElement(By.Id("IFMainContent_txtLogin")).SendKeys("dmanzano@bnb.com.bo");
            driver.FindElement(By.Id("IFMainContent_txtPasswd")).Click();
            driver.FindElement(By.Id("IFMainContent_txtPasswd")).Clear();
            driver.FindElement(By.Id("IFMainContent_txtPasswd")).SendKeys("Daniela123*");
            driver.FindElement(By.Id("IFMainContent_btnEntrar")).Click();
            Thread.Sleep(1000);*/

            string[] datos = File.ReadAllLines(@"D:\dataSetWeb.csv");
            int c = 0;
            foreach (var d in datos)
            {
                var valores = d.Split(',');

                string usuario = valores[0];
                string password = valores[1];
                string cuentaDebito = valores[2];
                string cuentaAbono = valores[3];
                string moneda = valores[4];
                string montoTranferencia = valores[5];
                string referencia = valores[6];

                if (c > 0)
                {

                    IWebDriver driver = new ChromeDriver();
                    driver.Navigate().GoToUrl("http://10.16.22.88/BNBNet/IniciarSesion/IniciarIdentificador");
                    driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='UFV:'])[1]/following::div[1]")).Click();
                    driver.FindElement(By.Id("IdentificadorEncriptado")).Click();
                    driver.FindElement(By.Id("IdentificadorEncriptado")).Clear();
                    driver.FindElement(By.Id("IdentificadorEncriptado")).SendKeys(usuario); //ingresamos el usuario
                    driver.FindElement(By.Id("RespuestaCapchaEncriptado")).Click();
                    driver.FindElement(By.Id("RespuestaCapchaEncriptado")).Clear();
                    driver.FindElement(By.Id("RespuestaCapchaEncriptado")).SendKeys("abcd");// este es el codigo captchap se debe deshabilitar.
                    driver.FindElement(By.Id("submitEnviar")).Click();
                    driver.FindElement(By.Id("Clave")).Clear();
                    driver.FindElement(By.Id("Clave")).SendKeys(password); //ingresamos el password
                    driver.FindElement(By.Id("submitEnviar")).Click();
                    driver.FindElement(By.LinkText("Operaciones")).Click();
                    driver.FindElement(By.LinkText("Transferencias")).Click();
                    driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Transferencias'])[2]/following::button[1]")).Click();
                    //Select ProductoOrigenSeleccionado
                    driver.FindElement(By.Id("ProductoOrigenSeleccionado")).Click();
                    //driver.FindElement(By.Id("ProductoOrigenSeleccionado")).Click();
                    driver.FindElement(By.XPath("//select[@id='ProductoOrigenSeleccionado']/option[contains(text(),'" + cuentaDebito + "')]")).Click(); // seleccionamos la cuenta debito
                    //Select ProductoDestinoSeleccionado
                    driver.FindElement(By.Id("ProductoDestinoSeleccionado")).Click();
                    //driver.FindElement(By.Id("ProductoDestinoSeleccionado")).Click();
                    driver.FindElement(By.XPath("//select[@id='ProductoDestinoSeleccionado']/option[contains(text(),'" + cuentaAbono + "')]")).Click(); // seleccionamos la cuenta abono
                    driver.FindElement(By.Id("MonedaSeleccionada")).Click();
                    //driver.FindElement(By.Id("MonedaSeleccionada")).Click();
                    driver.FindElement(By.XPath("//select[@id='MonedaSeleccionada']/option[contains(text(),'" + moneda + "')]")).Click(); //seleccionamos el tipo de moneda 

                    driver.FindElement(By.Id("Monto")).Click();
                    driver.FindElement(By.Id("Monto")).Clear();
                    driver.FindElement(By.Id("Monto")).SendKeys(montoTranferencia); // introducimos el monto a transferir.
                    driver.FindElement(By.Id("CodigoPromocion")).Click();
                    driver.FindElement(By.Id("CodigoPromocion")).Clear();
                    driver.FindElement(By.Id("CodigoPromocion")).SendKeys("abcd");
                    driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Los campos marcados con (*) son obligatorios.'])[1]/following::tbody[1]")).Click();
                    driver.FindElement(By.Id("CodigoPromocion")).Click();
                    driver.FindElement(By.Id("CodigoPromocion")).Clear();
                    driver.FindElement(By.Id("CodigoPromocion")).SendKeys("");
                    driver.FindElement(By.Id("Referencia")).Click();
                    driver.FindElement(By.Id("Referencia")).Clear();
                    driver.FindElement(By.Id("Referencia")).SendKeys(referencia); // introducimos la referencia
                    driver.FindElement(By.Id("submitTransferir")).Click();
                    driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Transferencias BNB propias > A cuentas propias'])[1]/following::h1[1]")).Click();

                    driver.Close();

                }
                c++;

            }


        }
    }
}
