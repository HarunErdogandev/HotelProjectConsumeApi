using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private static string requestUri = "http://localhost:5279/api/Staff";

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var response_message = await client.GetAsync(requestUri);
            if (response_message.IsSuccessStatusCode)
            {
                var jsonData = await response_message.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddStaff()
        {
            
            return View();

        }
        [HttpPost]
        public async Task< IActionResult> AddStaff(AddStaffViewModel model)
        {
            var client=_httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(model);
            StringContent stringContent= new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync(requestUri, stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }

        
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"{requestUri}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5279/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);

                return View(values);
            }


            return View();
        }
    }
}
