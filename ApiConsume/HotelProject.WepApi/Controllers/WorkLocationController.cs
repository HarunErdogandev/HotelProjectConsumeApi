﻿using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkLocationController : ControllerBase
    {
        public IWorkLocationService _workLocationService;
        public WorkLocationController(IWorkLocationService workLocationService)
        {
            _workLocationService = workLocationService;
        }

        [HttpGet]
        public IActionResult WorkLocationList()
        {
            var values = _workLocationService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddWorkLocation(WorkLocation workLocation)
        {
            _workLocationService.TInsert(workLocation);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteWorkLocation(int id)
        {
            var WorkLocation = _workLocationService.TGetById(id);
            _workLocationService.TDelete(WorkLocation);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateWorkLocation(WorkLocation workLocation)
        {
            _workLocationService.TUpdate(workLocation);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetWorkLocation(int id)
        {
            var WorkLocation = _workLocationService.TGetById(id);

            return Ok(WorkLocation);
        }
    }
}
