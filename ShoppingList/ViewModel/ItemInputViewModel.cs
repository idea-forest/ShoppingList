﻿using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ShoppingList.ViewModels;

[QueryProperty("UserList", "UserList")]
public partial class ItemInputViewModel : BaseViewModel
{
    readonly ItemService _itemService;

    [ObservableProperty]
    UserList userList;

    [ObservableProperty]
    public string itemName;

    [ObservableProperty]
    public string itemDescription;
    
    [ObservableProperty]
    public string itemCategory;

    [ObservableProperty]
    public string itemAisle;

    [ObservableProperty]
    public decimal itemEstimatedPrice; 

    [ObservableProperty]
    public int itemParentId; 


    public ItemInputViewModel()
    {
        _itemService = new();
    }


    [ICommand]
    public async void OnItemEntryCompleted()
    {
        if (IsBusy)
           return;

        //string name = "Test Name";// ((Entry)sender).Text;
        //userList = new(); 

        Item newItem = new()
        {
            Name = ItemName,
            Description = ItemDescription,
            Category = ItemCategory,    
            Aisle = ItemAisle,
            EstimatedPrice = ItemEstimatedPrice,
            ParentId = UserList.Id
        }; 


        newItem = _itemService.CreateItem(newItem);

        UserList.Items.Add(newItem);

        /*await Shell.Current.GoToAsync("..?id=" + newItem.Id + "&createflag=true", true, 
            new Dictionary<string, object>
            {
                {"UserList", UserList}
            }); 
        */

        await Shell.Current.GoToAsync($"{nameof(UserListDetails)}?", true,
            new Dictionary<string, object>
            {
                {"UserList", userList}
            }); 
        //await Shell.Current.DisplayAlert("Test alert", "Information recieved :" + UlName + ", " + UlTargetStore, "Ok");

    }

    [ICommand]
    public async void OnCancelButtonPressed()
    {

        await Shell.Current.GoToAsync($"{nameof(UserListDetails)}?", true,
            new Dictionary<string, object>
            {
                {"UserList", userList}
            }); 
    }
}