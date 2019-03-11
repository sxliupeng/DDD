using System;
using CompanyName.ProductName.Modules.Forum.DomainEvents;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.DomainObjects
{
    public class User : DomainObject<Guid>
    {
        #region Constructors

        public User(string userName)
            : this(Guid.NewGuid(), userName)
        {
        }
        public User(Guid id, string userName)
            : base(id)
        {
            this.UserName = userName;
        }

        #endregion

        #region Public Properties

        [TrackingProperty]
        public string UserName { get; private set; }
        [TrackingProperty]
        public string NickName { get; set; }
        [TrackingProperty]
        public int TotalMarks { get; set; }
        [TrackingProperty]
        public string AvatarFileName { get; set; }
        [TrackingProperty]
        public byte[] AvatarContent { get; set; }
        [TrackingProperty]
        public string Language { get; set; }
        [TrackingProperty]
        public string SiteTheme { get; set; }
        [TrackingProperty]
        public UserStatus UserStatus { get; set; }

        #endregion

        #region Event Handlers

        public void Handle(PreAddDomainObjectEvent<Thread> evnt)
        {
            if (this.TotalMarks < evnt.DomainObject.Marks)
            {
                throw new DomainException(ForumValidationError.ThreadAuthorTotalMarksNotEnough.GetName());
            }
        }
        public void Handle(DomainObjectAddedEvent<Thread> evnt)
        {
            TotalMarks -= evnt.DomainObject.Marks;
        }
        public void AddThreadOwnerMarks(ThreadClosedEvent evnt)
        {
            TotalMarks += evnt.Thread.Marks / 5;
        }
        public void AddThreadReplierMarks(ThreadClosedEvent evnt)
        {
            TotalMarks += evnt.PostAuthorMarks[this.Id];
        }

        #endregion
    }
}
