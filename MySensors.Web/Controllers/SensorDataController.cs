using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MySensors.ApplicationCore.Constants;
using MySensors.ApplicationCore.DTOs;
using MySensors.ApplicationCore.Entities;
using MySensors.ApplicationCore.Interfaces;
using MySensors.Infrastructure.Identity;
using MySensors.Web.ViewModels;

namespace MySensors.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorDataController : Controller
    {
        private readonly ISensorValuesService _sensorValuesService;
        
        public SensorDataController(ISensorValuesService sensorValuesService)
        {
            _sensorValuesService = sensorValuesService;
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddValues(string token)
        {
            var queryDictionary = HttpContext.Request.Query.ToDictionary(_=> _.Key, _=> _.Value);

            try
            {
                SensorRequestAddValuesDTO sensorRequest = new();
                if (queryDictionary.First().Key == "token" && queryDictionary.First().Value.Count > 0)
                {
                    sensorRequest.Token = queryDictionary.First().Value;
                    List<SensorParameterWithValueDTO> sensorParameterValue = new();
                    foreach (var keyValuePair in queryDictionary.Skip(1))
                    {
                        sensorParameterValue.Add(
                            new SensorParameterWithValueDTO()
                            {
                                ParameterRequestName = keyValuePair.Key,
                                ParameterValue = double.Parse(keyValuePair.Value)
                            });
                    }

                    sensorRequest.ParametersWithValues = sensorParameterValue;
                }

                await _sensorValuesService.Add(sensorRequest);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
            catch (SystemException e)
            {
                return BadRequest("Input values are invalid");
            }

            return Ok("Ok");
        }
    }
}