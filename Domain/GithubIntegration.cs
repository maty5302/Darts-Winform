 using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
	public class GithubIntegration
	{
		public static async Task<string> GetLatestRelease()
		{
			using (HttpClient client = new HttpClient())
			{
				string apiUrl = $"https://api.github.com/repos/maty5302/Darts-Winform/releases/latest";

				client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

				var response = await client.GetAsync(apiUrl);
				response.EnsureSuccessStatusCode();

				string responseJson = await response.Content.ReadAsStringAsync();
				dynamic responseObject = JsonConvert.DeserializeObject(responseJson);

				string latestRelease = responseObject.tag_name+"\n"+responseObject.body;

				return latestRelease;
			}
		}

		public static async Task<string> GetGitVersion()
		{
			using (HttpClient client = new HttpClient())
			{
				string apiUrl = $"https://api.github.com/repos/maty5302/Darts-Winform/releases/latest";

				client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

				HttpResponseMessage response = await client.GetAsync(apiUrl);
				response.EnsureSuccessStatusCode();

				string responseJson = await response.Content.ReadAsStringAsync();
				dynamic responseObject = JsonConvert.DeserializeObject(responseJson);

				string latestRelease = responseObject.tag_name;

				return latestRelease;
			}
		}
        
        public static async Task<string> GetReleaseNotes(string version)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"https://api.github.com/repos/maty5302/Darts-Winform/releases/tags/{version}";

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

                var response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();
                dynamic responseObject = JsonConvert.DeserializeObject(responseJson);

                string releaseNotes = responseObject.body;

                return releaseNotes;
            }
        }

        public static async Task<bool> CheckForUpdates()
        {
            var gitVersion = await GetGitVersion();
            var appVersion = Assembly.GetEntryAssembly()?.GetName().Version?.ToString() ?? "0.0.0.0";
            gitVersion = gitVersion.Replace(".", "").Replace("v", "").Replace("beta", "");
            appVersion = appVersion.Replace(".", "");
            
            int indexof = appVersion.IndexOf('+');
            if (indexof != -1)
                appVersion = appVersion.Remove(indexof);

            if (String.Compare(gitVersion, appVersion) > 0)
            {
                return true;
            }

            return false;
        }

	}
}
