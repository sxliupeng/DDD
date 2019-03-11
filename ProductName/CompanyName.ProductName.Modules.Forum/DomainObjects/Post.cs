using System;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.DomainObjects
{
    public class Post : DomainObject<Guid>
    {
        #region Constructors

        public Post(Guid threadId, Guid authorId, DateTime createDate)
            : this(Guid.NewGuid(), threadId, authorId, createDate)
        {
        }
        public Post(Guid id, Guid threadId, Guid authorId, DateTime createDate)
            : base(id)
        {
            this.ThreadId = threadId;
            this.AuthorId = authorId;
            this.CreateDate = createDate;
        }

        #endregion

        #region Public Properties

        [TrackingProperty]
        public string Body { get; set; }

        public Guid ThreadId { get; private set; }
        public Guid AuthorId { get; private set; }
        public DateTime CreateDate { get; private set; }

        #endregion

        #region Event Handlers

        private void Handle(DomainObjectRemovedEvent<Thread> evnt)
        {
            Repository.Remove(this);
        }

        #endregion
    }
}
