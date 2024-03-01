using MovieApp_Backend.Models;
using Newtonsoft.Json;

namespace MovieApp_Backend.Services
{
	public class OmdbService
	{
		private readonly HttpClient _httpClient;
		private readonly string _apiKey = "ecd0cd0a";

		private List<string> _searchHistory = new List<string>();

		public OmdbService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_searchHistory = new List<string>();
		}

		public async Task<OmdbSearchResponse> SearchMoviesAsync(string title)
		{
			string apiUrl = $"http://www.omdbapi.com/?apikey={_apiKey}&s={title}";

			var response = await _httpClient.GetStringAsync(apiUrl);

			SaveSearchQuery(title);

			return JsonConvert.DeserializeObject<OmdbSearchResponse>(response);
		}

		public async Task<OmdbMovieDetailsResponse> GetMovieDetailsAsync(string imdbId)
		{
			string apiUrl = $"http://www.omdbapi.com/?apikey={_apiKey}&i={imdbId}";

			var response = await _httpClient.GetStringAsync(apiUrl);

			return JsonConvert.DeserializeObject<OmdbMovieDetailsResponse>(response);
		}

		public void SaveSearchQuery(string title)
		{
			_searchHistory.Insert(0, title);
			if (_searchHistory.Count > 5)
				_searchHistory = _searchHistory.Take(5).ToList();
		}

		public List<string> GetSearchHistory()
		{
			return _searchHistory;
		}

	}
}
