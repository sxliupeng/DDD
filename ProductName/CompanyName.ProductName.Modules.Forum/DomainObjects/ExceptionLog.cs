using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.DomainObjects
{
    public class ExceptionLog : DomainObject<Guid>
    {
        #region Constructors

        public ExceptionLog()
            : this(Guid.NewGuid())
        {
        }
        public ExceptionLog(Guid id)
            : base(id)
        {
        }

        #endregion

        #region Public Propeties

        [TrackingProperty]
        public string Message { get; set; }
        [TrackingProperty]
        public string ExceptionDetails { get; set; }
        [TrackingProperty]
        public string UserName { get; set; }
        [TrackingProperty]
        public string IPAddress { get; set; }
        [TrackingProperty]
        public string UserAgent { get; set; }
        [TrackingProperty]
        public string HttpReferrer { get; set; }
        [TrackingProperty]
        public string HttpVerb { get; set; }
        [TrackingProperty]
        public string PathAndQuery { get; set; }
        [TrackingProperty]
        public DateTime DateCreated { get; set; }
        [TrackingProperty]
        public DateTime DateLastOccurred { get; set; }
        [TrackingProperty]
        public int Frequency { get; set; }

        #endregion
    }
}
