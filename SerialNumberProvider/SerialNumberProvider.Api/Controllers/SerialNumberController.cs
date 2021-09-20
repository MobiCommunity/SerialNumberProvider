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

        [HttpPost("sha256")]
        [ProducesResponseType(typeof(string), 200)]
        public IActionResult GetSHA256SerialNumberForDevice(GenerateSerialNumberRequestModel requestModel)
        {
            GenerateSerialNumberRequest request = PrepareGenerateSerialNumberRequest(requestModel);

            string generatedSerialNumber = _serialNumberGenerator.GenerateSHA256SerialNumber(request);

            return Ok(generatedSerialNumber);
        }


        [HttpPost("MD5")]
        [ProducesResponseType(typeof(string), 200)]
        public IActionResult GetMD5SerialNumberForDevice(GenerateSerialNumberRequestModel requestModel)
        {
            GenerateSerialNumberRequest request = PrepareGenerateSerialNumberRequest(requestModel);

            string generatedSerialNumber = _serialNumberGenerator.GenerateMD5SerialNumber(request);

            return Ok(generatedSerialNumber);
        }

        [HttpPost("validate")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult ValidateSerialNumberForDevice(ValidateSerialNumberRequestModel requestModel)
        {
            ValidateSerialNumberRequest request = PrepareValidateSerialNumberRequest(requestModel);

            if (_serialNumberValidator.ValidateSHA256(request) == true)
                return Ok(true);
            else if (_serialNumberValidator.ValidateMD5(request) == true)
                return Ok(true);
            else
                return Ok(false);
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