using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySensors.ApplicationCore.DTOs;
using MySensors.ApplicationCore.Interfaces;
using MySensors.Web.Extensions;

namespace MySensors.Web.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class SensorsController : Controller
    {
        private readonly ISensorsService _sensorsService;
        public SensorsController(ISensorsService sensorsService)
        {
            _sensorsService = sensorsService;
        }
        
        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorOverviewDTO>>> GetAll()
        {
            var sensors = await _sensorsService.GetSensorsOverview(User.GetUserId());

            return Ok(sensors);
        }
    }
}