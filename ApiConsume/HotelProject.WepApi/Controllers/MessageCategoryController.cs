﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageCategoryController : ControllerBase
    {
        private readonly IMessageCategoryService _messageCategoryService;

        public MessageCategoryController(IMessageCategoryService messageCategoryService)
        {
            _messageCategoryService = messageCategoryService;
        }

        [HttpGet]
        public IActionResult MessageCategoryList()
        {
            var values = _messageCategoryService.TGetList();

            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddMessageCategory(MessageCategory messageCategory)
        {
            _messageCategoryService.TInsert(messageCategory);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMessageCategory(int id)
        {
            var values = _messageCategoryService.TGetById(id);
            _messageCategoryService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateMessageCategory(MessageCategory messageCategory)
        {
            _messageCategoryService.TUpdate(messageCategory);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetMessageCategory(int id)
        {
            var MessageCategory = _messageCategoryService.TGetById(id);

            return Ok(MessageCategory);
        }
    }
}
