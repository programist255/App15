using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App15.Models;
using App15.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App15.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class day1 : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }
        public day1()
        {
            InitializeComponent();
            
            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);


            Items = new ObservableCollection<string>
            {

                "Item 1",
                "Item 2",
                "Item 3",
                "Item 4",
                "Item 5"
            };

            MyListView1.ItemsSource = Items;
            MyListView2.ItemsSource = Items;
            MyListView3.ItemsSource = Items;


        }
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
        bool OnTimerTick()
        {

            DateTime dt = DateTime.Now;

            MainDate.Text = dt.ToString("d");
            MainDate1.Text = dt.ToString("dddd");
            MainDate2.Text = dt.ToString("MMMM yyyy");
            return true;
        }

       
    }
}