﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.Business.GenRepository;
using ExamApp.DataAccess;
using ExamApp.DataAccess.DAL;
using Microsoft.Practices.Unity;

namespace ExamApp.Business
{
    
    public class GroupManager
    {
        IUnityContainer container = new UnityContainer();
        //private UnitOfWork unitOfWork = new UnitOfWork();
        private UnitOfWork unitOfWork;
        public GroupManager()
        {
            unitOfWork = container.Resolve<UnitOfWork>();
        }
        public  bool AddGroup(GroupMaster group)
        {
            try
            {
                //GroupRepository repository = new GroupRepository();
                //repository.InsertGroup(group);
                //repository.Save();
                unitOfWork.GroupRepository.Insert(group);
                unitOfWork.Save();
                return true;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public  GroupMaster FindGroup(int groupID)
        {
            try
            {
                //GroupRepository repository = new GroupRepository();
                //return repository.GetGroupByID(groupID);
                 return unitOfWork.GroupRepository.GetByID(groupID);


            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
    public class TestClass
    {
        public string result = string.Empty;
        dynamic order = new Order().Customer;
        public void Func(Order order)
        {
            var xys = order?.Customer?.Name;
        }
    }
    public class Order
        {
            public Customer Customer { get; set; }
        }

        public class Customer
        {
            public string Name { get; set; }
        }
  

}
