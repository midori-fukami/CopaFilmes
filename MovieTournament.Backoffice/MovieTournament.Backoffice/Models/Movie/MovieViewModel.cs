namespace MovieTournament.Backoffice.Models.Movie
{
    public class MovieViewModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public double Score { get; set; }

        public bool IsChecked { get; set; }
    }
}
