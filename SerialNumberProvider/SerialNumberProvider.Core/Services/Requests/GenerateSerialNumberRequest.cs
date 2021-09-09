using System;

namespace SerialNumberProvider.Core.Services.Requests
{
    public class GenerateSerialNumberRequest
    {
        public string Name { get; }
        public string Version { get; }
        public DateTime ProductionDate { get; }

        public GenerateSerialNumberRequest(string name, string version, DateTime productionDate)
        {
            Name = name;
            Version = version;
            ProductionDate = productionDate;
        }
    }
}