using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Newtonsoft.Json;
using SaleWeb.Models;
using System.Drawing.Printing;
using System.Text;
using System.Text.Json.Serialization;

namespace SaleWeb.Controllers
{
    
    public class ProductoController : Controller
    {
        Uri apiURL = new Uri("http://192.168.56.1/api");
        private readonly HttpClient _client;

        public ProductoController()
        {
            _client = new HttpClient();
            _client.BaseAddress = apiURL;
            
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Producto> productList = new List<Producto>();
            HttpResponseMessage response = _client.GetAsync(apiURL + "/Producto").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                productList = JsonConvert.DeserializeObject<List<Producto>>(data);
            }
            return View(productList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        
        }

        [HttpPost]
        public IActionResult Create(Producto model)
        {
            try
            {
                String data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PostAsync(apiURL + "/Producto", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Producto Agregado";
                    return RedirectToAction("Index");
                }
            }

            catch (Exception ex)
            {
                TempData["ErrorMessge"] = ex.Message;
                return View();
            }
            return View();
        }


        [HttpGet]

        public IActionResult Edit(int id)
        {
            Producto producto = new Producto();
            HttpResponseMessage response = _client.GetAsync(apiURL + "/Producto/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                producto = JsonConvert.DeserializeObject<Producto>(data);
            }
            return View(producto);
        }
        [HttpPost]
        public IActionResult Edit(Producto model)
        {
            try
            {
                string data = JsonConvert.SerializeObject(model);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = _client.PutAsync(apiURL + "/Producto", content).Result;

                if (response.IsSuccessStatusCode)
                {
                    TempData["SuccessMessage"] = "Producto Actualizado";
                    return RedirectToAction("Index");
                }
            }

            catch (Exception ex)
            {
                TempData["ErrorMessge"] = ex.Message;
                return View();
            }
            return View();
        }
    }
}
