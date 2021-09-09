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

        public bool Validate(ValidateSerialNumberRequest validateSerialNumberRequest)
            => NewGeneratedOne(validateSerialNumberRequest) == validateSerialNumberRequest.SerialNumberToValidate;

        private string NewGeneratedOne(GenerateSerialNumberRequest generateSerialNumberRequest)
            => _serialNumberGenerator.GenerateSerialNumber(generateSerialNumberRequest);
    }
}