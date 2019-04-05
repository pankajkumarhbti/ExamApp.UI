using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ExamApp.Business;
using ExamApp.DataAccess;
using Microsoft.Practices.Unity;
using System.Threading;

namespace ExamApp.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IUnityContainer container = new UnityContainer();
        GroupManager groupManager;
        string msg = string.Empty;
        //GroupManager  groupManager = new GroupManager();
        
        public MainWindow()
        {
            InitializeComponent();
            groupManager = container.Resolve<GroupManager>();            
        }
       

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            groupManager.AddGroup(new GroupMaster() { GroupName = txtName.Text, GroupDesc = txtDesc.Text, CreatedBy = 100 });
        }

        private  void BtnFind_Click(object sender, RoutedEventArgs e)
        {
            GroupMaster group = groupManager.FindGroup(Convert.ToInt32(txtGroupID.Text));
            txtName.Text = group?.GroupName;
            txtDesc.Text = group?.GroupDesc;
            //var res= await SpendTime();
            
            var result = AccessTheWebAsync();
            for (Int64 num = 0; num < 100000; num++)
            {
                int abc = 100;
                var xyz = abc.ToString();
            }
            txtDesc.Text = group?.GroupDesc;
            

            MessageBox.Show(msg);
        }


        private bool SpendTimeAsynch()
        {
            for (Int64 num = 0; num < 10000; num++)
            {
                int abc = 100;
                var xyz = abc.ToString();
            }   
           
            return true;
        }

        // Three things to note in the signature:  
        //  - The method has an async modifier.   
        //  - The return type is Task or Task<T>. (See "Return Types" section.)  
        //    Here, it is Task<int> because the return statement returns an integer.  
        //  - The method name ends in "Async."  
        async Task<int> AccessTheWebAsync()
        {
            // You need to add a reference to System.Net.Http to declare client.  
            HttpClient client = new HttpClient();

            // GetStringAsync returns a Task<string>. That means that when you await the  
            // task you'll get a string (urlContents). 
            
            Task<string> getStringTask =client.GetStringAsync("https://msdn.microsoft.com");

            // You can do work here that doesn't rely on the string from GetStringAsync.  
            DoIndependentWork();

            // The await operator suspends AccessTheWebAsync.  
            //  - AccessTheWebAsync can't continue until getStringTask is complete.  
            //  - Meanwhile, control returns to the caller of AccessTheWebAsync.  
            //  - Control resumes here when getStringTask is complete.   
            //  - The await operator then retrieves the string result from getStringTask. 
            
            string urlContents = await getStringTask;
            
            // string urlconnection1=await client.GetStringAsync("https://msdn.microsoft.com"); //When there is no work to do.


            // The return statement specifies an integer result.  
            // Any methods that are awaiting AccessTheWebAsync retrieve the length value.
            
            return urlContents.Length;
        }

        private void DoIndependentWork()
        {
            
            GroupMaster group = groupManager.FindGroup(Convert.ToInt32(txtGroupID.Text));
            txtName.Text = group?.GroupName;
            txtDesc.Text = group?.GroupDesc;
            string name = "sdfsd";
            Action action = () => { Thread.Sleep(50000); name = name + "99000090";};
            ThreadStart threadStart = new ThreadStart(action);
            Thread thread = new Thread(threadStart);
            thread.Start();
           
        }
        
    }

}
