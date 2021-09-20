using SerialNumberProvider.Core.Services.Requests;

namespace SerialNumberProvider.Core.Services.Abstract
{
    public interface ISerialNumberValidator
    {
        bool ValidateSHA256(ValidateSerialNumberRequest validateSerialNumberRequest);
        bool ValidateMD5(ValidateSerialNumberRequest validateSerialNumberRequest);
    }
}