using System;

namespace SerialNumberProvider.Api.Models
{
    public class GenerateSerialNumberRequestModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public DateTime ProductionDate { get; set; }
    }
}