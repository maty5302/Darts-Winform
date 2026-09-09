using Newtonsoft.Json;
using System.Reflection;

namespace Domain
{
	public static class GithubIntegration
	{
		public static async Task<string> GetLatestRelease()
		{
			using (HttpClient client = new HttpClient())
			{
				string apiUrl = $"https://api.github.com/repos/maty5302/DartsCounter/releases/latest";

				client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

				var response = await client.GetAsync(apiUrl);
				response.EnsureSuccessStatusCode();

				string responseJson = await response.Content.ReadAsStringAsync();
				dynamic? responseObject = JsonConvert.DeserializeObject(responseJson);

				string latestRelease = responseObject?.tag_name + "\n" + responseObject?.body ?? "";

				return latestRelease;
			}
		}

		public static async Task<string> GetGitVersion()
		{
			using (HttpClient client = new HttpClient())
			{
				string apiUrl = $"https://api.github.com/repos/maty5302/DartsCounter/releases/latest";

				client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

				client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

				HttpResponseMessage response = await client.GetAsync(apiUrl);
				response.EnsureSuccessStatusCode();

				string responseJson = await response.Content.ReadAsStringAsync();
				dynamic? responseObject = JsonConvert.DeserializeObject(responseJson);

				string latestRelease = responseObject?.tag_name ?? "";

				return latestRelease;
			}
		}
        
        public static async Task<string> GetReleaseNotes(string version)
        {
            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"https://api.github.com/repos/maty5302/DartsCounter/releases/tags/{version}";

                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");

                var response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string responseJson = await response.Content.ReadAsStringAsync();
                dynamic? responseObject = JsonConvert.DeserializeObject(responseJson);

                string releaseNotes = responseObject?.body ?? "";

                return releaseNotes;
            }
        }

        public static async Task<bool> CheckForUpdates()
        {
            try
            {
                var gitVersionString = await GetGitVersion();
                var appVersionString = Assembly.GetEntryAssembly()?.GetName().Version?.ToString();

                if (string.IsNullOrEmpty(gitVersionString) || string.IsNullOrEmpty(appVersionString))
                    return false;

                gitVersionString = gitVersionString.Replace("v", "", StringComparison.OrdinalIgnoreCase)
                    .Replace("beta", "", StringComparison.OrdinalIgnoreCase);

                int indexof = appVersionString.IndexOf('+');
                if (indexof != -1)
                    appVersionString = appVersionString.Remove(indexof);

                if (Version.TryParse(gitVersionString, out var gitVersion) && 
                    Version.TryParse(appVersionString, out var appVersion))
                {
                    return gitVersion > appVersion;
                }

                return false;
            }
            catch
            {
                return false;
            }
        }
	}
}
