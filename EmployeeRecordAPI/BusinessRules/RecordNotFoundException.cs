using System.Net;

namespace WatchPortal.Api.Source.Domain.BusinessRules
{
    public class RecordNotFoundException : BusinessRulesException
    {
        private const string message = "Record Not Found";

        public RecordNotFoundException() : base(HttpStatusCode.NotFound, message) { }

        public RecordNotFoundException(string formattedMessage) : base(HttpStatusCode.NotFound, string.Format("{0}: {1}", message, formattedMessage)) { }
    }
}
