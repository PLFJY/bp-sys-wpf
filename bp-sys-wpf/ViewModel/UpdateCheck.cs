using Flurl.Http;
using System.Diagnostics;
using System.Net.Cache;
using System.Net.Http;
using System.Text.Json;

namespace bp_sys_wpf.ViewModel
{
    public class UpdateCheck
    {
        public string repository = null, releasesUrl = null;
        public GiteeReleaseInfo releaseInfo = new();
        public string DownloadUrl = string.Empty;
        public bool Issuccessful = false;
        public async Task FetchLatestReleaseInfoAsync(string baseUrl, string mirrorURL)
        {
            repository = "plfjy/bp-sys-wpf-update";
            releasesUrl = $"{baseUrl}/repos/{repository}/releases/latest";
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Firefox/116.0";
            using (HttpClient client = new())
            {
                client.DefaultRequestHeaders.Add("User-Agent", userAgent);
                client.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8");
                client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.5");
                try
                {
                    // 发起GET请求并获取JSON响应内容
                    HttpResponseMessage response = await client.GetAsync(releasesUrl);
                    response.EnsureSuccessStatusCode();
                    var responseJson = await response.Content.ReadAsStringAsync();
                    // 使用System.Text.Json进行反序列化
                    releaseInfo = System.Text.Json.JsonSerializer.Deserialize<GiteeReleaseInfo>(responseJson);
                    Issuccessful = true;
                }
                catch (FlurlHttpException ex)
                {
                    Debug.WriteLine($"请求失败: {ex.Message}");
                    Issuccessful = false;
                }
                catch (JsonException jex)
                {
                    Debug.WriteLine($"JSON解析失败: {jex.Message}");
                    Issuccessful = false;
                }
            }
        }
    }
    public class GiteeReleaseInfo
    {
        public string tag_name { get; set; }
        public string body { get; set; }
        public Assets[] assets { get; set; }
        public class Assets
        {
            public string browser_download_url { get; set; }
            public string name { get; set; }
        }
    }
}
