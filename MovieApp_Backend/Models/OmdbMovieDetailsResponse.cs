namespace MovieApp_Backend.Models
{
	public class OmdbMovieDetailsResponse
	{
		public string Title { get; set; } = string.Empty;
		public string Year { get; set; } = string.Empty;
		public string ImdbID { get; set; } = string.Empty;
		public string Type { get; set; } = string.Empty;
		public string Poster { get; set; } = string.Empty;
	}
}
