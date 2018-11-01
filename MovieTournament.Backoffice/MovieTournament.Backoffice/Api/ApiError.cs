namespace MovieTournament.Backoffice.Api
{
    public class ApiError
    {
        public const string ErrorMessage = "Ocorreu um problema interno.";

        public ApiError(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; set; }
        public string Message { get; set; }
    }
}
