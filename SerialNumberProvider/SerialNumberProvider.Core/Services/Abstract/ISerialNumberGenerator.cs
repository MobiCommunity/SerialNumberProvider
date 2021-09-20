using System;
using SerialNumberProvider.Core.Services.Requests;

namespace SerialNumberProvider.Core.Services.Abstract
{
    public interface ISerialNumberGenerator
    {
        string GenerateSHA256SerialNumber(GenerateSerialNumberRequest request);
        string GenerateMD5SerialNumber(GenerateSerialNumberRequest request);
    }
}