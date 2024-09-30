namespace ControlGastos.Models
{
    public class ErrorLogDto
    {
        public ErrorLogDto(int id, string errorMessage = null, string errorStackTrace = null, string controller = null, string endpoint = null)
        {
            Id = id;
            ErrorMessage = errorMessage;
            ErrorStackTrace = errorStackTrace;
            Controller = controller;
            Endpoint = endpoint;
            ErrorTimestamp = DateTime.Now;
        }

        public int Id { get; set; }
        public string Controller { get; set; }
        public string Endpoint { get; set; }
        public string ErrorMessage { get; set; }
        public string ErrorStackTrace { get; set; }
        public DateTime ErrorTimestamp { get; set; }
    }
}
