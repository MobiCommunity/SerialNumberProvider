using Microsoft.AspNetCore.Mvc;
using SerialNumberProvider.Api.Models;
using SerialNumberProvider.Core.Services.Abstract;
using SerialNumberProvider.Core.Services.Requests;

namespace SerialNumberProvider.Api.Controllers
{
    [Route("api/serial-number")]
    public class SerialNumberController : ControllerBase
    {
        private readonly ISerialNumberGenerator _serialNumberGenerator;
        private readonly ISerialNumberValidator _serialNumberValidator;

        public SerialNumberController(ISerialNumberGenerator serialNumberGenerator,
            ISerialNumberValidator serialNumberValidator)
        {
            _serialNumberGenerator = serialNumberGenerator;
            _serialNumberValidator = serialNumberValidator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), 200)]
        public IActionResult GetSerialNumberForDevice(GenerateSerialNumberRequestModel requestModel)
        {
            GenerateSerialNumberRequest request = PrepareGenerateSerialNumberRequest(requestModel);

            string generatedSerialNumber = _serialNumberGenerator.GenerateSerialNumber(request);

            return Ok(generatedSerialNumber);
        }

        [HttpPost("validate")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult ValidateSerialNumberForDevice(ValidateSerialNumberRequestModel requestModel)
        {
            ValidateSerialNumberRequest request = PrepareValidateSerialNumberRequest(requestModel);

            bool isCorrect = _serialNumberValidator.Validate(request);

            return Ok(isCorrect);
        }

        private static GenerateSerialNumberRequest PrepareGenerateSerialNumberRequest(
            GenerateSerialNumberRequestModel response)
            => new GenerateSerialNumberRequest(response.Id, response.Name, response.Version, response.ProductionDate);
        
        private static ValidateSerialNumberRequest PrepareValidateSerialNumberRequest(
            ValidateSerialNumberRequestModel response)
            => new ValidateSerialNumberRequest(response.Id, response.Name, response.Version, response.ProductionDate,
                response.SerialNumber);
    }
}