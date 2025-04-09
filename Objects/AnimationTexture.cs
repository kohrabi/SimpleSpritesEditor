namespace WinFormsApp1.Objects;

using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

public class AnimationTexture : INotifyPropertyChanged, IDisposable
{
    private int _textureId = 0;
    private string _filePath = "";
    private string _rootPath = "";
    private Texture2D _texture;

    public string FilePath
    {
        get => _filePath;
        set
        {
            _filePath = value;
            NotifyPropertyChanged(nameof(FilePath));
        }
    }

    [Browsable(false)]
    public Texture2D Texture => _texture;
    public int TextureId => _textureId;

    public AnimationTexture(string path, Texture2D texture, int textureId)
    {
        _filePath = path;
        _texture = texture;
        _textureId = textureId;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Dispose()
    {
        _texture.Dispose();
    }
}

