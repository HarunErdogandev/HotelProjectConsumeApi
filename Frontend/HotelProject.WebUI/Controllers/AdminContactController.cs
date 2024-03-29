﻿using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.RoomDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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
            var responseMessage = await client.GetAsync("http://localhost:5279/api/Contact/InboxList");

            var clientGetContact = _httpClientFactory.CreateClient();
            var responseMessageContact = await clientGetContact.GetAsync("http://localhost:5279/api/Contact/GetContactCount");

            var clientGetSendMessage = _httpClientFactory.CreateClient();
            var responseMessageSend = await clientGetSendMessage.GetAsync("http://localhost:5279/api/SendMessage/GetSendMessageCount");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<InboxContactDto>>(jsonData);

                var ContactCountData = await responseMessageContact.Content.ReadAsStringAsync();
                ViewBag.contactCount = ContactCountData;

                var MessageSendCountData = await responseMessageSend.Content.ReadAsStringAsync();
                ViewBag.sendMessageCount = MessageSendCountData;
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> SendBox()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5279/api/SendMessage");

            var clientGetContact = _httpClientFactory.CreateClient();
            var responseMessageContact = await clientGetContact.GetAsync("http://localhost:5279/api/Contact/GetContactCount");

            var clientGetSendMessage = _httpClientFactory.CreateClient();
            var responseMessageSend = await clientGetSendMessage.GetAsync("http://localhost:5279/api/SendMessage/GetSendMessageCount");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSendBoxDto>>(jsonData);

                var ContactCountData = await responseMessageContact.Content.ReadAsStringAsync();
                ViewBag.contactCount = ContactCountData;

                var MessageSendCountData = await responseMessageSend.Content.ReadAsStringAsync();
                ViewBag.sendMessageCount=MessageSendCountData;

                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult AddSendMessage()
        {

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessageDto createSendMessageDto)
        {
            createSendMessageDto.SenderMail = "admin@gmail.com";
            createSendMessageDto.SenderName = "admin";
            createSendMessageDto.Date = DateTime.Parse(DateTime.Now.ToString());
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSendMessageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5279/api/SendMessage", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SendBox");
            }
            return View();

        }

        public async Task<PartialViewResult> SidebarAdminContactPartial()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5279/api/Contact/GetContactCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();

                ViewBag.contactCount = jsonData;
                return PartialView(jsonData);
            }
           
            return PartialView();
        }
        public PartialViewResult SidebarAdminContactCategoryPartial()
        {
            return PartialView();
        }

        public async Task<IActionResult> MessageDetails(int id)
        {
           
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5279/api/SendMessage/"+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIDDto>(jsonData);
                return View(values);
            }
            return View();
            
        }
        public async Task<IActionResult> MessageDetailsInbox(int id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5279/api/Contact/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageSendInboxById>(jsonData);
                return View(values);
            }
            return View();

        }
    }
}
