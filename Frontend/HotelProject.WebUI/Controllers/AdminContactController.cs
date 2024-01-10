using HotelProject.WebUI.Dtos.ContactDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class AdminContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory= httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5279/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public PartialViewResult SidebarAdminContactPartial()
        {
            return PartialView();
        }
        public PartialViewResult SidebarAdminContactCategoryPartial()
        {
            return PartialView();
        }
    }
}
