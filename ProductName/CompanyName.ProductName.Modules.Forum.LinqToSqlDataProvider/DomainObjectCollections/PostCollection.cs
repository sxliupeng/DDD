using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using CompanyName.ProductName.Modules.Forum.DomainEvents;
using CompanyName.ProductName.Modules.Forum.DomainObjects;
using EventBasedDDD;

namespace CompanyName.ProductName.Modules.Forum.LinqToSqlDataProvider
{
    public class PostCollection : DomainObjectCollection<Post, Guid>
    {
        #region Private Variables

        private DataContext dataContext;
        private ITable<PostObject> postTable;

        #endregion

        #region Constructors

        public PostCollection(IUnitOfWork unitOfWork, IDataContextProvider dataContextProvider)
        {
            dataContext = dataContextProvider.DataContext;
            unitOfWork.RegisterPersistableCollection(this);
            postTable = dataContext.GetTable<PostObject>();
        }

        #endregion

        #region Collection Methods Overrides

        protected override Post GetFromPersistence(Guid id)
        {
            var postObj = postTable.Where(p => p.Id == id).FirstOrDefault();
            if (postObj != null)
            {
                return postObj.ToPost();
            }
            return null;
        }
        protected override void PersistNewDomainObjects(List<Post> newDomainObjects)
        {
            foreach (var newPost in newDomainObjects)
            {
                postTable.InsertOnSubmit(newPost.ToPostObject());
            }
        }
        protected override void PersistModifiedDomainObjects(List<Post> modifiedDomainObjects)
        {
            foreach (var modifiedPost in modifiedDomainObjects)
            {
                var postObj = postTable.Where(p => p.Id == modifiedPost.Id).FirstOrDefault();
                if (postObj != null)
                {
                    postObj.UpdateAccordingWith(modifiedPost);
                }
            }
        }
        protected override void PersistRemovedDomainObjects(List<Post> removedDomainObjects)
        {
            foreach (var removedPost in removedDomainObjects)
            {
                var postObj = postTable.Where(p => p.Id == removedPost.Id).FirstOrDefault();
                if (postObj != null)
                {
                    postTable.DeleteOnSubmit(postObj);
                }
            }
        }

        #endregion

        #region Event Handlers

        public IList<Post> Handle(FindPostsEvent evnt)
        {
            return GetDomainObjects(postTable.Where(p => p.ThreadId == evnt.ThreadId).ToPostList(),
                                    p => p.ThreadId == evnt.ThreadId);
        }

        #endregion
    }
}
