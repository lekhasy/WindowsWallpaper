using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WindowsWallpaper.Domain;

namespace WindowsWallpaper.ImageSource
{
    public class BingDailyImageSource : IDailyImageSource
    {
        public async Task<IEnumerable<Domain.Entities.WwImageSource>> GetTodayImageSourceAsync()
        {
            // We can specify the region we want for the Bing Image of the Day.
            string strRegion = "en-US";
            var _numOfImages = 5;
            string strBingImageURL = string.Format("http://www.bing.com/HPImageArchive.aspx?format=js&idx=0&n={0}&mkt={1}", _numOfImages, strRegion);
            string strJSONString = "";

            HttpClient client = new HttpClient();

            // Using an Async call makes sure the app is responsive during the time the response is fetched.
            // GetAsync sends an Async GET request to the Specified URI.
            HttpResponseMessage response = await client.GetAsync(new Uri(strBingImageURL));

            // Content property get or sets the content of a HTTP response message. 
            // ReadAsStringAsync is a method of the HttpContent which asynchronously 
            // reads the content of the HTTP Response and returns as a string.
            strJSONString = await response.Content.ReadAsStringAsync();

            var strs = JsonConvert.DeserializeObject<BingImageSourceResult>(strJSONString);
            var uris = strs.images.Select(s => new Domain.Entities.WwImageSource { Source = new Uri("https://www.bing.com" + s.url), Description = s.copyright });
            return uris;
        }
    }

    public class BingImageSourceResult
    {
        public Image[] images { get; set; }
        public Tooltips tooltips { get; set; }
    }
    public class Tooltips
    {
        public string loading { get; set; }
        public string previous { get; set; }
        public string next { get; set; }
        public string walle { get; set; }
        public string walls { get; set; }
    }

    public class Image
    {
        public string startdate { get; set; }
        public string fullstartdate { get; set; }
        public string enddate { get; set; }
        public string url { get; set; }
        public string urlbase { get; set; }
        public string copyright { get; set; }
        public string copyrightlink { get; set; }
        public bool wp { get; set; }
        public string hsh { get; set; }
        public int drk { get; set; }
        public int top { get; set; }
        public int bot { get; set; }
        public object[] hs { get; set; }
    }
}
