﻿using System;
using IImage = Microsoft.Maui.Graphics.IImage;

namespace ShoppingList.Controls;

public class CircularButton : GraphicsView
{
	/// <summary>
	/// The Color passed to the drawable for the "Fill Color" of the Fill Circle method
	/// </summary>
	public Color ButtonColor
	{
        get => (Color)GetValue(ButtonColorProperty);
        set => SetValue(ButtonColorProperty, value);
    }

	/// <summary>
	/// A string containing the Image name (just the file name, not the directory)
	/// <br/> Expects the file to be in Resources/Images/
	/// </summary>
	public string Image
	{ 
        get => (string)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    
    }

	public new bool IsVisible
	{ 
        get => (bool)GetValue(IsVisibleProperty);
        set => SetValue(IsVisibleProperty, value);
    }

	public BindableProperty ButtonColorProperty = BindableProperty.Create(
		nameof(ButtonColor), typeof(Color), typeof(CircularButton), propertyChanged: OnButtonColorChanged);

	public BindableProperty ImageProperty = BindableProperty.Create(
		nameof(Image), typeof(string), typeof(CircularButton), propertyChanged: OnImageChanged); 

	public new BindableProperty IsVisibleProperty = BindableProperty.Create(
		nameof(IsVisible), typeof(bool), typeof(CircularButton), propertyChanged: OnIsVisibleChanged); 

	public CircularButton()
	{
		var drawable = new CircularButtonDrawable();
		Drawable = drawable;
	}

	static void OnButtonColorChanged(BindableObject bindable, object oldValue, object newValue)
	{
        var control = (CircularButton)bindable;
        var buttonColor = control.ButtonColor;
		var thisDrawable = control.Drawable as ShoppingList.Drawable.CircularButtonDrawable;
		thisDrawable.ButtonColor = buttonColor;
        control.Invalidate();
    }

	static void OnImageChanged(BindableObject bindable, object oldValue, object newValue) 
    {
		var control = (CircularButton)bindable;
		var image = control.Image;
		var thisDrawable = control.Drawable as ShoppingList.Drawable.CircularButtonDrawable;
		thisDrawable.Image = image;
		control.Invalidate(); 
    
    }

	static void OnIsVisibleChanged(BindableObject bindable, object oldValue, object newValue) 
    {
		var control = (CircularButton)bindable;

		//var newValueAsBool = (bool)newValue; 

	//	if ( == true)
	//	{
	//		control.FadeTo(1, 2000); 
	//	} else 
	//	{
	//		control.FadeTo(0, 4000); 
	//	}

		var thisDrawable = control.Drawable as ShoppingList.Drawable.CircularButtonDrawable;
		//thisDrawable.SetInvisible = (bool)newValue;
		control.Invalidate(); 
    }

}