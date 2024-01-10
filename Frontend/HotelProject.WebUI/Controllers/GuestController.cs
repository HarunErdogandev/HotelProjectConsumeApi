using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class GuestController : Controller
    {
        public IHttpClientFactory _httpClientFactory;
        public static  string ApiUrl = $"{DefaultApi.GetApi}Guest";
        public GuestController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task< IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(ApiUrl);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGuestDto>>(jsonData);
                return View(values);
            }


            return View();
        }

        [HttpGet]
        public IActionResult AddGuest()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddGuest(CreateGuestDto createGuestDto)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createGuestDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync(ApiUrl, stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
                return View();
            }
            else
              return View();
        }
        
        public async Task<IActionResult> DeleteGuest(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"{ApiUrl}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateGuest(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{ApiUrl}/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateGuestDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateGuest(UpdateGuestDto updateGuestDto)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateGuestDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync(ApiUrl, stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("index");
                }
                return View();
            }
            return View();
            
        }
    }
}
