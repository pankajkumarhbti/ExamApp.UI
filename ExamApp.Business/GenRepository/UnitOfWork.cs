using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ExamApp.DataAccess;
using ExamApp.DataAccess.DAL;

namespace ExamApp.Business.GenRepository
{
    public class UnitOfWork : IDisposable
    {
        private TTEntities context = new TTEntities();
        private GenericRepository<GroupMaster> groupRepository;
        private GenericRepository<SubGroupMaster> subGroupRepository;
        //Add other repositories here and make properties like below

        public GenericRepository<GroupMaster> GroupRepository
        {
            get
            {

                if (this.groupRepository == null)
                {
                    this.groupRepository = new GenericRepository<GroupMaster>(context);
                }
                return groupRepository;
            }
        }

        public GenericRepository<SubGroupMaster> SubGroupRepository
        {
            get
            {

                if (this.subGroupRepository == null)
                {
                    this.subGroupRepository = new GenericRepository<SubGroupMaster>(context);
                }
                return subGroupRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
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
    }
}
