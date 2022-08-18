﻿using System;
using System.Reflection;
using Microsoft.Maui.Graphics.Platform;
using IImage = Microsoft.Maui.Graphics.IImage;

namespace ShoppingList.Drawable;

public class CircularButtonDrawable : IDrawable
{
    public Color StrokeColor { get; set; } = Colors.DarkGrey;

    public bool AreShadowsEnabled { get; set; } = true;

    /// <summary>
    /// A string containing the Image name.
    /// </summary>
    public string Image { get; set; }

    public int Width { get; set; } = 0;
    public int Height { get; set; } = 0;

    public Color ButtonColor { get; set; } = Colors.White;

    public bool SetInvisible { get; set; } = false; 

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        if (SetInvisible)
            return; 

        canvas.StrokeColor = StrokeColor;

        if (AreShadowsEnabled)
            canvas.EnableDefaultShadow();

        var width = Width != 0 ? Width : dirtyRect.Width;
        var height = Height != 0 ? Height : dirtyRect.Height;

        var limitingDim = width > height ? height : width;
        PointF centerOfCircle = new PointF(width / 2, height / 2);

#if !WINDOWS
        IImage image;
        Assembly assembly = GetType().GetTypeInfo().Assembly;
        using (Stream stream = assembly.GetManifestResourceStream("ShoppingList.Resources.Images." + Image))
        {
            image = PlatformImage.FromStream(stream);
            if (image is null)
                throw new FileNotFoundException("ShoppingList.Resources.Images." + Image); 
        }
        if (image != null)
        {
            canvas.FillColor = this.ButtonColor; 
            canvas.FillCircle(centerOfCircle, limitingDim / 2);
            canvas.DrawImage(image, dirtyRect.X + dirtyRect.Width / 4, dirtyRect.Y + dirtyRect.Height / 4, dirtyRect.Width / 2, dirtyRect.Height / 2); 
        }
#else
    
        canvas.FillColor = this.ButtonColor;
        canvas.FillCircle(centerOfCircle, limitingDim / 2);

#endif
    }
}

