using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WinFormsApp1.Objects;

public class Animation : INotifyPropertyChanged
{
    public static readonly string SpriteOnlyAnimationName = "<Only Sprites>";
    private string _name = "New Animation";
    private readonly BindingList<AnimationFrame> frames = new BindingList<AnimationFrame>();

    public string Name { 
        get => _name;
        set
        {
            if (_name == SpriteOnlyAnimationName)
                return;
            _name = value;
            NotifyPropertyChanged(nameof(Name));
        }
    }
    public BindingList<AnimationFrame> Frames => frames;

    public event PropertyChangedEventHandler? PropertyChanged;

    public void AddFrame(AnimationFrame frame)
    {
        frame.SetName("Frame " + frames.Count);
        frames.Add(frame);
        NotifyPropertyChanged(nameof(Frames));
    }

    public void RemoveFrame(AnimationFrame frame)
    {
        frames.Remove(frame);
        NotifyPropertyChanged(nameof(Frames));
    }
    
    
    public void SetName(string name)
    {
        _name = name;
        NotifyPropertyChanged(nameof(Name));
    }

    private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}