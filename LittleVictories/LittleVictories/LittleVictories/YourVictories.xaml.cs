﻿using LittleVictories.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;

namespace LittleVictories
{
    public partial class YourVictories : ContentPage
    {
        public YourVictories()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            VictoryListView.ItemsSource = await App.Database.GetVictoriesAsync();

            if (((List<TheVictory>)VictoryListView.ItemsSource).Any())
            {
                VictoryListView.IsVisible = false;
                EmptyMessage.IsVisible = true;
            }
            else
            {
                VictoryListView.IsVisible = true;
                EmptyMessage.IsVisible = false;
            }
        }
        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new ViewVictory()
                {
                    BindingContext = e.SelectedItem as TheVictory
                });
            }
        }

    }
}