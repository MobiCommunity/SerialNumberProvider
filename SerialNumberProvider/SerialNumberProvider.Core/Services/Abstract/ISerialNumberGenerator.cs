using System;
using SerialNumberProvider.Core.Services.Requests;

namespace SerialNumberProvider.Core.Services.Abstract
{
    public interface ISerialNumberGenerator
    {
        string GenerateSerialNumber(GenerateSerialNumberRequest request);
        string GenerateSerialNumber(GenerateSerialNumberRequest request, bool isMicrowave);
    }
}