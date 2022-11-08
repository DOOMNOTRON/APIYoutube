using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace APIYoutube
{
    /// <summary>
    /// A class to work with the Youtube API
    /// Manage and get started documentation for the API found at: https://developers.google.com/youtube/v3
    /// modify the API acess here: https://console.cloud.google.com/welcome?project=youtubeapi-367918
    /// API key 
    ///Authorization: Bearer[YOUR_ACCESS_TOKEN]
    ///Accept: application/json
    /// yt channel ID: https://www.youtube.com/channel/UC3OBm9yCUqqVZ-hguyFmxVg
    /// </summary>
    public static class DoomnotronYoutubeVideos
    {
        private static HttpClient _httpClient;

        static DoomnotronYoutubeVideos()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Returns a response object from the API
        /// or throw HttpRequestException if cal is unsuccessful
        /// </summary>
        /// <exception cref="HttpRequestException">Thrown if call is unsuccessful</exception>
        /// <returns></returns>
        public async static Task<YoutubeAPIResponse?> GetYoutubeVideos()
        {
            HttpResponseMessage response =
                await _httpClient.GetAsync("https://youtube.googleapis.com/youtube/v3/search?part=snippet&channelId=UC3OBm9yCUqqVZ-hguyFmxVg&maxResults=1&order=viewCount&key=AIzaSyBj6jFO_sOzZeZLafrQoPm5Kb6sbAVjjhs");
            response.EnsureSuccessStatusCode();
            string responseText = await response.Content.ReadAsStringAsync();
            YoutubeAPIResponse? responseObject = JsonConvert.DeserializeObject<YoutubeAPIResponse>(responseText);
            return responseObject;



        }
    }
}

// Generate JSON as C# objects
// VS can use paste special -> Paste JSON as classes
// or: https://json2csharp.com/ can be used

public class YoutubeAPIResponse
{
    public string kind { get; set; }
    public string etag { get; set; }
    public string nextPageToken { get; set; }
    public string regionCode { get; set; }
    public Pageinfo pageInfo { get; set; }
    public Item[] items { get; set; }
}

public class Pageinfo
{
    public int totalResults { get; set; }
    public int resultsPerPage { get; set; }
}

public class Item
{
    public string kind { get; set; }
    public string etag { get; set; }
    public Id id { get; set; }
    public Snippet snippet { get; set; }
}

public class Id
{
    public string kind { get; set; }
    public string videoId { get; set; }
}

public class Snippet
{
    public DateTime publishedAt { get; set; }
    public string channelId { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public Thumbnails thumbnails { get; set; }
    public string channelTitle { get; set; }
    public string liveBroadcastContent { get; set; }
    public DateTime publishTime { get; set; }
}

public class Thumbnails
{
    public Default _default { get; set; }
    public Medium medium { get; set; }
    public High high { get; set; }
}

public class Default
{
    public string url { get; set; }
    public int width { get; set; }
    public int height { get; set; }
}

public class Medium
{
    public string url { get; set; }
    public int width { get; set; }
    public int height { get; set; }
}

public class High
{
    public string url { get; set; }
    public int width { get; set; }
    public int height { get; set; }
}
