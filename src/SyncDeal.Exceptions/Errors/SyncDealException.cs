namespace SyncDeal.Exceptions.Errors
{
    public abstract class SyncDealException : SystemException
    {
        protected SyncDealException(string message) : base(message) { }

        public abstract int StatusCode { get; }

        public abstract List<string> GetErrors();
    }
}
