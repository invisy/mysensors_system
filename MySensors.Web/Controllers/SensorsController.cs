using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySensors.ApplicationCore.DTOs;
using MySensors.ApplicationCore.Exceptions;
using MySensors.ApplicationCore.Interfaces;
using MySensors.Web.Extensions;
using MySensors.Web.ViewModels;

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
        
        // POST
        [HttpPost("add")]
        public async Task<IActionResult> Add(SensorDTO sensor)
        {
            sensor.UserId = User.GetUserId();
            await _sensorsService.AddSensor(sensor);

            return Ok();
        }
        
        // GET
        [HttpGet("token/{id}")]
        public async Task<ActionResult<SensorToken>> GetToken(int id)
        {
            try
            {
                var sensorUserId = await _sensorsService.GetOwnerUserId(id);
                if (sensorUserId == User.GetUserId())
                {
                    var sensorToken = new SensorToken() {Token = await _sensorsService.GetTokenBySensorId(id)};
                    return sensorToken;
                }
            }
            catch (EntityNotFoundException)
            {
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NotFound();
        }
    }
}