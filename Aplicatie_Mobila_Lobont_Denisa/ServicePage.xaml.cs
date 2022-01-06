using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicatie_Mobila_Lobont_Denisa.Models;
using Aplicatie_Mobila_Lobont_Denisa.Data;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Nume_Pren_Lab10.Models;

namespace Aplicatie_Mobila_Lobont_Denisa
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServicePage : ContentPage
    {
        SchedulingList sl;
        public ServicePage(SchedulingList slist)
        {
            InitializeComponent();
            sl = slist;
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var service = (Service)BindingContext;
            await App.Database.SaveServiceAsync(service);
            listView.ItemsSource = await App.Database.GetServicesAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var service = (Service)BindingContext;
            await App.Database.DeleteServiceAsync(service);
            listView.ItemsSource = await App.Database.GetServicesAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetServicesAsync();
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Service p;
            if (e.SelectedItem != null)
            {
                p = e.SelectedItem as Service;
                var lp = new ListService()
                {
                    SchedulingListID = sl.ID,
                    ServiceID = p.ID
                };

                await App.Database.SaveListServiceAsync(lp);
                p.ListServices = new List<ListService> { lp };
                await Navigation.PopAsync();
            }
        }
    } 
}