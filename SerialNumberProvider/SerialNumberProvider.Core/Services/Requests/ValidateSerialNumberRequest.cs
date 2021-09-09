using System;

namespace SerialNumberProvider.Core.Services.Requests
{
    public class ValidateSerialNumberRequest : GenerateSerialNumberRequest
    {
        public string SerialNumberToValidate { get; }

        public ValidateSerialNumberRequest(Guid id, string name, string version, 
            DateTime productionDate, string serialNumberToValidate) : base(id, name, version, productionDate)
        {
            SerialNumberToValidate = serialNumberToValidate;
        }
    }
}