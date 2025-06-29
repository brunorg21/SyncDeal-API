﻿
using System.Net;

namespace SyncDeal.Exceptions.Errors
{
    public class ErrorOnValidationException : SyncDealException
    {
        private readonly List<string> _errors;
        public ErrorOnValidationException(List<string> errors) : base(string.Empty)
        {
            _errors = errors;
        }
        public override int StatusCode => (int)HttpStatusCode.BadRequest;

        public override List<string> GetErrors()
        {
            return _errors;
        }
    }
}
