using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySensors.ApplicationCore.DTOs;
using MySensors.ApplicationCore.Entities;
using MySensors.ApplicationCore.Interfaces;
using MySensors.Web.Extensions;
using MySensors.Web.ViewModels;

namespace MySensors.Web.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class SensorParametersController : Controller
    {
        private readonly ISensorParametersService _sensorParametersService;
        private readonly ISensorsService _sensorsService;
        
        public SensorParametersController(ISensorParametersService sensorParametersService, ISensorsService sensorsService)
        {
            _sensorParametersService = sensorParametersService;
            _sensorsService = sensorsService;
        }

        [HttpGet("sensor/{sensorId}")]
        public async Task<ActionResult<IEnumerable<SensorParameterDTO>>> GetBySensorId(int sensorId)
        {
            var sensorUserId = await _sensorsService.GetOwnerUserId(sensorId);
            if (sensorUserId == User.GetUserId())
            {
                var sensorParams = await _sensorParametersService.GetBySensorId(sensorId);
                    
                return Ok(sensorParams);
            }
            
            return NotFound();
        }
    }
}