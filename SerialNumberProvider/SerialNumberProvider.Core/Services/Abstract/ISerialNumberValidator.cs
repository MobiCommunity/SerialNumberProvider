using SerialNumberProvider.Core.Services.Requests;

namespace SerialNumberProvider.Core.Services.Abstract
{
    public interface ISerialNumberValidator
    {
        bool Validate(ValidateSerialNumberRequest validateSerialNumberRequest);
    }
}