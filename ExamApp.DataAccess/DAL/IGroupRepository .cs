using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using ExamApp.DataAccess;

namespace ExamApp.DataAccess.DAL
{
    interface IGroupRepository :IDisposable
    {
        IEnumerable<GroupMaster> GetGroups();
        GroupMaster GetGroupByID(int groupID);
        void InsertGroup(GroupMaster group);
        void DeleteGroup(int groupID);
        void UpdateGroup(GroupMaster group);
        void Save();
    }

    public class GroupRepository : IGroupRepository
    {
        private TTEntities context;
        public GroupRepository(TTEntities context)
        {
            this.context = context;
        }
        public GroupRepository()
        {
            this.context = new TTEntities();
        }
        public void DeleteGroup(int groupID)
        {
            GroupMaster group = context.GroupMasters.Find(groupID);
            context.GroupMasters.Remove(group);
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                   context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public GroupMaster GetGroupByID(int groupID)
        {
           return context.GroupMasters.Find(groupID);
        }

        public IEnumerable<GroupMaster> GetGroups()
        {
            return context.GroupMasters.ToList();
        }

        public void InsertGroup(GroupMaster group)
        {
            try
            {
                context.GroupMasters.Add(group);
                //context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public  void Save()
        {
             context.SaveChanges();
        }

        public void UpdateGroup(GroupMaster group)
        {
            context.Entry(group).State = System.Data.Entity.EntityState.Modified;
        }
    }
}


