using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Aplicatie_Mobila_Lobont_Denisa.Data;
using System.IO;

namespace Aplicatie_Mobila_Lobont_Denisa
{
    public partial class App : Application
    {
        static SchedulingListDatabase database;

        public static SchedulingListDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                    SchedulingListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SchedulingList.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ListEntryPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
