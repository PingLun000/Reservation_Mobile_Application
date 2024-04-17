﻿using System;
using System.Collections.Generic;
using System.Linq;
using ReservationMobileApp.Model;
using Plugin.SharedTransitions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReservationMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsView : ContentPage
    {
        public ProductsView()
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


        async void CV_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var selectedProduct = e.CurrentSelection.FirstOrDefault() as ProvideItem;
            if (selectedProduct == null)
                return;
            await Navigation.PushModalAsync(new ProductDetailsView(selectedProduct));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
