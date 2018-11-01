namespace MovieTournament.Backoffice.Api
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public ApiError Error { get; set; }
    }
}
