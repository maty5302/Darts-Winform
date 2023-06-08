using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class OnedriveDownload
    {
        public static async Task<string> GetTextFromOneDriveFile(string fileUrl)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(fileUrl);

                response.EnsureSuccessStatusCode();

                using (var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync()))
                {
                    return await streamReader.ReadToEndAsync();
                }
            }
        }
    }
}
