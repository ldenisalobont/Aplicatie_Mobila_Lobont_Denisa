using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.LocalNotification;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Aplicatie_Mobila_Lobont_Denisa.Models;
using Nume_Pren_Lab10.Models;

namespace Aplicatie_Mobila_Lobont_Denisa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var plist = (SchedulingList)BindingContext;
            plist.Date = DateTime.UtcNow;
            await App.Database.SaveSchedulingListAsync(plist);
            await Navigation.PopAsync();
            var notification = new NotificationRequest
            {
                Description = "Programarea a fost efectuata, veti primi detaliile programarii printr-un email",
                Title = "Programare efectuata!"
            };
            await NotificationCenter.Current.Show(notification);
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var plist = (SchedulingList)BindingContext;
            await App.Database.DeleteSchedulingListAsync(plist);
            await Navigation.PopAsync();
        }
        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ServicePage((SchedulingList)this.BindingContext)
            {
                BindingContext = new Service()
            });
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var schl = (SchedulingList)BindingContext;
            listView.ItemsSource = await App.Database.GetListServicesAsync(schl.ID);
        }
    }
}