using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


    public static class FileExtensions
    {
        public static async Task<string> ReadAsStringAsync(this IFormFile file)
        {
            var result = new StringBuilder();
            var buffer = new byte[4096];
            int bytesRead;

            using (var stream = file.OpenReadStream())
            {
                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    result.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                }
            }

            return result.ToString();
        }
    }
