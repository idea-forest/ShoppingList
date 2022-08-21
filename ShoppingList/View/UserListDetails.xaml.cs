﻿//using Microsoft.Maui.Graphics.Platform;
using System.Reflection;
using ShoppingList.ViewModels;
using IImage = Microsoft.Maui.Graphics.IImage;
using SkiaSharp.Extended.UI.Controls;
using SkiaSharp.Views.Maui.Controls;
using ShoppingList.Controls;

namespace ShoppingList;

public partial class UserListDetails : ContentPage
{
	UserListDetailViewModel _ulvm;

	public UserListDetails(UserListDetailViewModel userListDetailViewModel)
	{
		InitializeComponent();
		BindingContext = userListDetailViewModel;

		_ulvm = userListDetailViewModel;
		_ulvm.HasUndo = false; 

    }

	public void OnCheckboxClicked(object sender, CheckedChangedEventArgs e)
	{

		CheckBox thisCheckbox = sender as CheckBox;

		Frame currentFrame = thisCheckbox.BindingContext as Frame;

		Item itemThatWasClicked = currentFrame.BindingContext as Item;


		if (thisCheckbox.IsChecked)
			currentFrame.FadeTo(.4, 1000);
		else
			currentFrame.FadeTo(1, 1000);

		itemThatWasClicked.IsCompleted = thisCheckbox.IsChecked;
		_ulvm.ItemWasChecked(itemThatWasClicked);

	}

	private async void NewItemButtonPressed(object sender, EventArgs e)
	{

		var circularButton = sender as CircularButton;
		await circularButton.BounceOnPressAsync();
		_ulvm.NewItemDialog(); 
	}

	private async void UndoButtonPressed(object sender, EventArgs e)
	{

		var circularButton = sender as CircularButton;
		await circularButton.BounceOnPressAsync();
		_ulvm.UndoButtonPressed(); 
	}
}
