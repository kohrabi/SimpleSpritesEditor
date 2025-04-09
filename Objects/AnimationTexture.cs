namespace WinFormsApp1.Objects;

using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class AnimationTexture : INotifyPropertyChanged
{
    private string filePath = "";
    private string rootPath = "";
    private Texture2D texture;

    public string FilePath
    {
        get => filePath;
        set
        {
            filePath = value;
            NotifyPropertyChanged(nameof(FilePath));
        }
    }


    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}

