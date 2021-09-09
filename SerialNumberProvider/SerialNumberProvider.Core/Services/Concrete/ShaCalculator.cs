using System.Security.Cryptography;
using System.Text;
using SerialNumberProvider.Core.Services.Abstract;

namespace SerialNumberProvider.Core.Services.Concrete
{
    public class ShaCalculator : IShaCalculator
    {
        public string Compute(string value)
        {
            // Create a SHA256   
            using SHA256 sha256Hash = SHA256.Create();
            // ComputeHash - returns byte array  
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(value));  
  
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