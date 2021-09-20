using SerialNumberProvider.Core.Services.Abstract;
using SerialNumberProvider.Core.Services.Requests;

namespace SerialNumberProvider.Core.Services.Concrete
{
    public class SerialNumberValidator : ISerialNumberValidator
    {
        private readonly ISerialNumberGenerator _serialNumberGenerator;

        public SerialNumberValidator(ISerialNumberGenerator serialNumberGenerator)
        {
            _serialNumberGenerator = serialNumberGenerator;
        }

        public bool ValidateSHA256(ValidateSerialNumberRequest validateSerialNumberRequest)
            => NewGeneratedOneSHA256(validateSerialNumberRequest) == validateSerialNumberRequest.SerialNumberToValidate;
        public bool ValidateMD5(ValidateSerialNumberRequest validateSerialNumberRequest)
          => NewGeneratedOneMD5(validateSerialNumberRequest) == validateSerialNumberRequest.SerialNumberToValidate;

        private string NewGeneratedOneSHA256(GenerateSerialNumberRequest generateSerialNumberRequest)
            => _serialNumberGenerator.GenerateSHA256SerialNumber(generateSerialNumberRequest);
        private string NewGeneratedOneMD5(GenerateSerialNumberRequest generateSerialNumberRequest)
          => _serialNumberGenerator.GenerateMD5SerialNumber(generateSerialNumberRequest);
    }
}