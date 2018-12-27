using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamApp.DataAccess;
using ExamApp.DataAccess.DAL;

namespace ExamApp.Business
{
    
    public class GroupManager
    {      

        public static bool AddGroup(GroupMaster group)
        {
            try
            {
                GroupRepository repository = new GroupRepository();
                repository.InsertGroup(group);
                repository.Save();
                return true;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
        }

        public static GroupMaster FindGroup(int groupID)
        {
            try
            {
                GroupRepository repository = new GroupRepository();
                return repository.GetGroupByID(groupID);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
    /*
    public string result = string.Empty;
    dynamic order = new Order().Customer;
    public void Func(Order order)
    {
        var xys = order?.Customer?.Name;
    }
    public class Order
    {
        public Customer Customer { get; set; }
    }

    public class Customer
    {
        public string Name { get; set; }
    }
    */
}
