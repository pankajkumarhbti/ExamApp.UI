using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ExamApp.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GroupManager  groupManager = new GroupManager();
        public MainWindow()
        {
            InitializeComponent();
        }
       

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            groupManager.AddGroup(new GroupMaster() { GroupName = txtName.Text, GroupDesc = txtDesc.Text, CreatedBy = 100 });
        }

        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {
            GroupMaster group = groupManager.FindGroup(Convert.ToInt32(txtGroupID.Text));
            txtName.Text = group.GroupName;
            txtDesc.Text = group.GroupDesc;
        }
    }
}
