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
        ItemsViewModel viewModel;
        public App[] product { get; set; }
        
        public day1()
        {
            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();

            Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);

            //Print(product);

            //Scr2.IsVisible = false;
            //Scr3.IsVisible = false;
            //Scr4.IsVisible = false;
            //Scr5.IsVisible = false;
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            if (viewModel.Items.Count == 0)

                viewModel.LoadItemsCommand.Execute(null);
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
            return;

            await Navigation.PushAsync(new ADD());
            Scr2.IsVisible = true;
            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }
        bool OnTimerTick()
        {

            DateTime dt = DateTime.Now;
            
            MainDate.Text = dt.ToString("d");
            MainDate1.Text = dt.ToString("dddd");
            MainDate2.Text = dt.ToString("MMMM yyyy");
            return true;
        }

        private void MainDate3_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ADD());
        }
        
        
    }
}