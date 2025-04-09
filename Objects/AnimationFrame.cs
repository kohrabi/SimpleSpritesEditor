namespace WinFormsApp1.Objects;

using Microsoft.Xna.Framework;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

public class AnimationFrame : INotifyPropertyChanged
{
    public int Id = 0;
    private string _name = "New Frame";
    private Rectangle _rect = Rectangle.Empty;
    private string _texturePath = "";
    private int _textureId;
    private int _frameTime = 10;

    public event PropertyChangedEventHandler? PropertyChanged;

    public string Name { 
        get => _name;
        set
        {
            _name = value;
            NotifyPropertyChanged(nameof(Name));
        }
    }

    [Browsable(false)]
    public Rectangle Rect 
    { 
        get => _rect; 
        set
        {
            _rect = value;
            NotifyPropertyChanged(nameof(Rect));
        }
    }

    public Size RectSize
    {
        get => new Size(_rect.Width, _rect.Height);
        set
        {
            _rect.Width = value.Width;
            _rect.Height = value.Height;
            NotifyPropertyChanged(nameof(Rect));
        }
    }

    public System.Drawing.Point RectPosition
    {
        get => new System.Drawing.Point(_rect.X, _rect.Y);
        set
        {
            _rect.X = value.X;
            _rect.Y = value.Y;
            NotifyPropertyChanged(nameof(Rect));
        }
    }

    public int TextureId
    {
        get => _textureId;
        set
        {
            _textureId = value;
            NotifyPropertyChanged(nameof(TextureId));   
        }
    }
    public string TexturePath => _texturePath;
    public int FrameTime
    {
        get => _frameTime;
        set
        {
            _frameTime = value;
            NotifyPropertyChanged(nameof(FrameTime));
        }
    }

    public AnimationFrame(int textureId, string texturePath)
    {
        _textureId = textureId;
        _texturePath = texturePath;
    }
    public AnimationFrame(int textureId)
    {
        _textureId = textureId;
    }

    public void SetName(string name)
    {
        _name = name;
        NotifyPropertyChanged(nameof(Name));
    }

    public void SetRect(Rectangle rect)
    {
        _rect = rect;
        NotifyPropertyChanged(nameof(Rect));
    }

    public void SetFrameTime(int frameTime)
    {
        _frameTime = frameTime;
        NotifyPropertyChanged(nameof(FrameTime));
    }

    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void SetTexture(int textureId, string texturePath)
    {
        _textureId = textureId;
        _texturePath = texturePath;
    }

}

