using System;
using Microsoft.AspNetCore.Mvc;
using SerialNumberProvider.Core.Services.Abstract;
using SerialNumberProvider.Core.Services.Requests;

namespace SerialNumberProvider.Api.Controllers
{
    [Route("api/serial-number")]
    public class SerialNumberController : ControllerBase
    {
        private readonly ISerialNumberGenerator _serialNumberGenerator;
        private readonly ISerialNumberValidator _serialNumberValidator;

        public SerialNumberController(ISerialNumberGenerator serialNumberGenerator, ISerialNumberValidator serialNumberValidator)
        {
            _serialNumberGenerator = serialNumberGenerator;
            _serialNumberValidator = serialNumberValidator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(string),200)]
        public IActionResult GetSerialNumberForDevice(string name, string version, DateTime productionDate)
        {
            string generatedSerialNumber = _serialNumberGenerator.GenerateSerialNumber(
                new GenerateSerialNumberRequest(name, version, productionDate));

            return Ok(generatedSerialNumber);
        }
        
        [HttpGet("validate")]
        [ProducesResponseType(typeof(bool),200)]
        public IActionResult ValidateSerialNumberForDevice(string name, string version, DateTime productionDate,string numberToValidate)
        {
            bool isCorrect = _serialNumberValidator.Validate(new ValidateSerialNumberRequest(name,version,productionDate,numberToValidate));

            return Ok(isCorrect);
        }
    }
}