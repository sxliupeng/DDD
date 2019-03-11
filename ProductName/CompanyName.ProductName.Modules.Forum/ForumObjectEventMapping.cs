using System.Linq;
using CompanyName.ProductName.Modules.Forum.DomainEvents;
using CompanyName.ProductName.Modules.Forum.DomainObjects;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum
{
    public class ForumObjectEventMapping : ObjectEventMapping
    {
        protected override void InitializeObjectEventMappingItems()
        {
            //Group Event Mappings.
            RegisterObjectEventMappingItem<ChangeGroupSubjectEvent, Group>(evnt => evnt.GroupId);

            //Section Event Mappings.
            RegisterObjectEventMappingItem<ChangeSectionSubjectEvent, Section>(evnt => evnt.SectionId);

            //Thread Event Mappings.
            RegisterObjectEventMappingItem<CloseThreadEvent, Thread>(evnt => evnt.ThreadId);
            RegisterObjectEventMappingItem<DomainObjectAddedEvent<Post>, Thread>(evnt => evnt.DomainObject.ThreadId);
            RegisterObjectEventMappingItem<DomainObjectRemovedEvent<Post>, Thread>(evnt => evnt.DomainObject.ThreadId);

            //User Event Mappings.
            RegisterObjectEventMappingItem<PreAddDomainObjectEvent<Thread>, User>(evnt => evnt.DomainObject.AuthorId);
            RegisterObjectEventMappingItem<DomainObjectAddedEvent<Thread>, User>(evnt => evnt.DomainObject.AuthorId);
            RegisterObjectEventMappingItem<ThreadClosedEvent, User>(
                new GetDomainObjectIdEventHandlerInfo<ThreadClosedEvent>
                {
                    GetDomainObjectId = evnt => evnt.Thread.AuthorId,
                    EventHandlerName = "AddThreadOwnerMarks"
                },
                new GetDomainObjectIdsEventHandlerInfo<ThreadClosedEvent>
                {
                    GetDomainObjectIds = evnt => evnt.PostAuthorMarks.Select(entry => entry.Key).OfType<object>(),
                    EventHandlerName = "AddThreadReplierMarks"
                }
            );

            //Post Event Mappings.
            RegisterObjectEventMappingItem<DomainObjectRemovedEvent<Thread>, Post>(evnt => Repository.Find<Post, FindPostsEvent>(evt => evt.ThreadId = evnt.DomainObject.Id));
        }
    }
}
