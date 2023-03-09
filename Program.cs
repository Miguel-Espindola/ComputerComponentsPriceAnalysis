
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V107.Network;

namespace WebScrapperv1
{
    class Program
    {
        struct Datos
        {
            public string URL;
            public string ComponentName;
            public string XPathComponentPrice;
            public double Price;
            public string hora;

            public Datos(string URL, string ComponentName, string XPathComponentPrice, double Price, string hora)
            {
                this.URL = URL;
                this.ComponentName = ComponentName;
                this.XPathComponentPrice = XPathComponentPrice;
                this.Price = Price;
                this.hora = hora;
            }
        }
        
        static void Main(string[] args)
        {
            Datos datos1 = new Datos(
                "https://www.cyberpuerta.mx/Computo-Hardware/Componentes/Tarjetas-de-Video/Tarjeta-de-Video-ASUS-NVIDIA-Phoenix-GeForce-RTX-3050-8G-8GB-128-bit-GDDR6-PCI-Express-4-0.html",
                "rtx3050",
                "//*[@id=\"productinfo\"]/form/div[2]/div[1]/div[2]/div/div[3]/div[2]/div/div/div[1]/span",
                0,
                ""
                );
            Datos datos2 = new Datos(
                "https://www.cyberpuerta.mx/Computo-Hardware/Componentes/Procesadores/Procesadores-para-PC/Procesador-AMD-Ryzen-9-5950X-S-AM4-3-40GHz-8MB-L3-Cache-no-incluye-Disipador.html",
                "AMD Ryzen 7 5800x",
                "//*[@id=\"productinfo\"]/form/div[2]/div[1]/div[2]/div/div[3]/div[2]/div/div/div[2]/span",
                0,
                ""
                );
 
            var chromOptions = new ChromeOptions();



            chromOptions.AddArguments("headless");
            IWebDriver driver = new ChromeDriver(chromOptions);
            driver.Navigate().GoToUrl(datos2.URL);
            var elemto = driver.FindElement(By.CssSelector("span.priceText"));
            Console.WriteLine(elemto.Text);

            Datos[] dataSearch = { datos1, datos2 };

           

            foreach (var datos in dataSearch )
            {
                driver.Navigate().GoToUrl(datos.URL);
                var element = driver.FindElement(By.XPath(datos.XPathComponentPrice));
                Console.WriteLine("Precio de: "+  datos.ComponentName + "    " +  element.Text);
            }
          

        }

       
       


    }
}