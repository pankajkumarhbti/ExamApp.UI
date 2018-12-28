using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ExamApp.Business;
using ExamApp.DataAccess;
using ExamApp.Business.GenRepository;

namespace ExamApp.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        UnityContainer IU = new UnityContainer();
        public App()
        {
            IU.RegisterType<TTEntities>();
            IU.RegisterType<GenericRepository<object>>();
            IU.RegisterType<UnitOfWork>();
        }
    }
}
