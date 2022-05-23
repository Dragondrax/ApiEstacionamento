using System.Security.Cryptography;
using System.Text;

namespace ApiEstacionamento.Services
{
    public class CreateHashEncrypting
    {
        public string GerarHashSha256(string input)
        {
            SHA256 hash = SHA256.Create();
            byte[] data = hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
