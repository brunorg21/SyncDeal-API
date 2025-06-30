namespace SyncDeal.Communication.Responses
{
    public class ResponseErrorDTO
    {
        public List<string> ErrorMessages { get; set; }
        public ResponseErrorDTO(List<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }

        public ResponseErrorDTO(string errorMessage)
        {
            ErrorMessages = [errorMessage];
        }
    }
}
