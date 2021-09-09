using System;
using System.Security.Cryptography;
using System.Text;
using SerialNumberProvider.Core.Services.Abstract;
using SerialNumberProvider.Core.Services.Requests;

namespace SerialNumberProvider.Core.Services.Concrete
{
    public class SerialNumberGenerator : ISerialNumberGenerator
    {
        public string GenerateSerialNumber(GenerateSerialNumberRequest request)
            => ComputeSha256Hash($"{request.Version}+{request.Name}+{request.ProductionDate.ToLongDateString()}");

            private static string ComputeSha256Hash(string rawData)
            {
                // Create a SHA256   
                using SHA256 sha256Hash = SHA256.Create();
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));  
  
                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();  
                foreach (byte t in bytes)
                {
                    builder.Append(t.ToString("x2"));
                }  
                return builder.ToString();
            }
    }
}