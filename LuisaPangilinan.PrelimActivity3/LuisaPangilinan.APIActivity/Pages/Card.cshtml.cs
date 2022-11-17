using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using RestSharp;

namespace LuisaPangilinan.APIActivity.Pages
{
    public class CardModel : PageModel
    {
        public WordDefinition? Definition { get; set; }
        public void OnGet()
        {
        }

        public class WordDefinition
        {
            public string? Word { get; set; }
            public string? Phonetics { get; set; }
            public string? Meaning { get; set; }
        }
        public void Onpost()
        {
            var client = new RestClient("https://api.dictionaryapi.dev/api/v2/entries/en/");

            var request = new RestRequest("", Method.Get);

            RestResponse response = client.Execute(request);

            var content = response.Content;

            var definition = JsonConvert.DeserializeObject<WordDefinition>(content);
        }
    }
}
