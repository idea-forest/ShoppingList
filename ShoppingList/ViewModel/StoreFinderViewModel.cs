﻿using ShoppingList.Model.Api;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ShoppingList.ViewModels;

[QueryProperty("UserList", "UserList")]
public partial class StoreFinderViewModel : BaseViewModel
{
    KrogerAPIService _kapis;

    [ObservableProperty]
    Dictionary<string, string> locations;


    public ObservableCollection<string> StoreNames { get; } = new();

    [ObservableProperty]
    string zipSearched; 


    public StoreFinderViewModel()
    {
        _kapis = new KrogerAPIService();
    }

    [ICommand]
    public async void GoBackToMain()
    {
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}"); 
    }

    [ICommand]
    public async void DoSearchQuery(string zipcode)
    {
        ApiConfig apiconfig = await _kapis.GetStartupConfig();
        var done = await _kapis.SetAuthTokens(apiconfig);

        try
        {
            var locations = await _kapis.GetLocationNearZip(zipcode, apiconfig);

            if (StoreNames.Count > 0)
                StoreNames.Clear();

            foreach (var location in locations.Values.ToList<string>())
            {
                StoreNames.Add(location); 
            }
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlert("None Found", e.Message, "Ok");
            return; 
        }



    }
}