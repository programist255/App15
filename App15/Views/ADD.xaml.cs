using App15.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App15.Views
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ADD : ContentPage
    {
        public Item Item { get; set; }

        public string ValidationMessage { get; set; }
        public ADD()
        {
            InitializeComponent();

            Item = new Item
            {
                
            };

            BindingContext = this; 
            
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            //await Login();
            MessagingCenter.Send(this, "AddItem", Item);
            
            await Navigation.PopAsync();
        }

        //private async Login()
        //{
        //    if(string.IsNullOrEmpty(Convert.ToString(Nasv)))
        //    {
        //        await Application.Current
        //            return;
        //    }
        //    if()
        //    {

        //    }
        //    return;
        //}

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}