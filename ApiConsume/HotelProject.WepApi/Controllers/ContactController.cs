using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("InboxList")]
        public IActionResult InboxContactList()
        {
            var values = _contactService.TGetList();

            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            contact.Date=Convert.ToDateTime(DateTime.Now.ToString());
            _contactService.TInsert(contact);
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var contact = _contactService.TGetById(id);
            _contactService.TDelete(contact);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateContact(Contact contact)
        {
            _contactService.TUpdate(contact);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var contact = _contactService.TGetById(id);

            return Ok(contact);
        }
    }
}
