﻿using ReservationMobileApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReservationMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReservationView : ContentPage
    {
        public ReservationView()
        {
            InitializeComponent();
        }

        async void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var category = e.CurrentSelection.FirstOrDefault() as Category;
            if (category == null)
                return;

            await Navigation.PushModalAsync(new CategoryView(category));

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}