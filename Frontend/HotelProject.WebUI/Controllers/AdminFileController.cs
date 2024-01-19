﻿using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HotelProject.WebUI.Controllers
{
    public class AdminFileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            var bytes = stream.ToArray();

            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();

            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);


            var httpClient = new HttpClient();
            var responseMessage = await httpClient.PostAsync("http://localhost:5279/api/FileProcess", multipartFormDataContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return View();
            }

            return View();
        }
    }
}
