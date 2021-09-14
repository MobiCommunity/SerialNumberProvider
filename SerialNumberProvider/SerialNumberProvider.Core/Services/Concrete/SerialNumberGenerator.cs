using System.Security.Cryptography;
using System.Text;
using SerialNumberProvider.Core.Services.Abstract;
using SerialNumberProvider.Core.Services.Requests;

namespace SerialNumberProvider.Core.Services.Concrete
{
    public class SerialNumberGenerator : ISerialNumberGenerator
    {
        public string GenerateSerialNumber(GenerateSerialNumberRequest request)
            => ComputeSha256Hash($"{request.Id}+{request.Version}+{request.Name}+{request.ProductionDate.Ticks}");
        public string GenerateSerialNumber(GenerateSerialNumberRequest request, bool isMicrowave)
        => ComputeMD5Hash($"{request.Id}+{request.Version}+{request.Name}+{request.ProductionDate.Ticks}");

        private static string ComputeSha256Hash(string rawData)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            StringBuilder builder = new StringBuilder();
            foreach (byte t in bytes)
            {
                builder.Append(t.ToString("x2"));
            }

            return builder.ToString();
        }

        private static string ComputeMD5Hash(string rawData)
        {
            using MD5 sha256Hash = MD5.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            StringBuilder builder = new StringBuilder();
            foreach (byte t in bytes)
            {
                builder.Append(t.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}