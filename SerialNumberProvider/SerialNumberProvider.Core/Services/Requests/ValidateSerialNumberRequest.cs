using System;

namespace SerialNumberProvider.Core.Services.Requests
{
    public class ValidateSerialNumberRequest : GenerateSerialNumberRequest
    {
        public string SerialNumberToValidate { get; }

        public ValidateSerialNumberRequest(string name, string version, DateTime productionDate, string serialNumberToValidate) 
            : base(name, version, productionDate)
        {
            SerialNumberToValidate = serialNumberToValidate;
        }
    }
}