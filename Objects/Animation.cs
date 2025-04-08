namespace WinFormsApp1.Data;

public class Animation
{
    public static readonly string SpriteOnlyAnimationName = "<Only Sprites>";
    private string _name = "New Animation";
    private List<AnimationFrame> frames = new List<AnimationFrame>();

    public string Name => _name;
    public List<AnimationFrame> Frames => frames;
    
    public void AddFrame(AnimationFrame frame)
    {
        frame.SetName("Frame " + frames.Count);
        frames.Add(frame);
    }

    public void RemoveFrame(AnimationFrame frame)
    {
        frames.Remove(frame);
    }
    
    
    public void SetName(string name)
    {
        _name = name;
    }
    
}