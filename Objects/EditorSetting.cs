using System.ComponentModel;
using System.Runtime.CompilerServices;
using Point = Microsoft.Xna.Framework.Point;

namespace Editor.Objects;

public class EditorSetting : INotifyPropertyChanged
{
    private string _delimeter = " ";
    private Point _gridSize = new Point(16);
    private int _startID = 0;

    public event PropertyChangedEventHandler? PropertyChanged;

    [Browsable(false)]
    public string Delimeter
    {
        get => _delimeter;
        set
        {
            _delimeter = value;
            NotifyPropertyChanged(nameof(Delimeter));
        }
    }

    [Browsable(false)]
    public Point GridSize
    {
        get => _gridSize;
        set
        {
            _gridSize = value;
            NotifyPropertyChanged(nameof(GridSize));
        }
    }

    public int StartID
    {
        get => _startID;
        set
        {
            _startID = value;
            NotifyPropertyChanged(nameof(StartID));
        }
    }

    // Editor Property Grid Export
    public string EditorDelimeter
    {
        get => "\"" + _delimeter + "\"";
        set
        {
            _delimeter = value.Replace("\"", "");
            NotifyPropertyChanged(nameof(Delimeter));
        }
    }

    public Size EditorGridSize
    {
        get => new Size(_gridSize.X, _gridSize.Y);
        set
        {
            _gridSize.X = value.Width;
            _gridSize.Y = value.Height;
            NotifyPropertyChanged(nameof(GridSize));
        }
    }



    public EditorSetting()
    { }

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}