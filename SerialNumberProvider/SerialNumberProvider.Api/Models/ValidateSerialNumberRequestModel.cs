namespace SerialNumberProvider.Api.Models
{
    public class ValidateSerialNumberRequestModel : GenerateSerialNumberRequestModel
    {
        public string SerialNumber { get; set; }
    }
}