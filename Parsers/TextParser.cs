using System.Text;
using Microsoft.Xna.Framework.Graphics;
using WinFormsApp1.Data;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace WinFormsApp1.Parsers;


public static class TextParser
{
    private const string TEXTURES_PREFIX = "[TEXTURES]";
    private const string SPRITES_PREFIX = "[SPRITES]";
    private const string ANIMATIONS_PREFIX = "[ANIMATIONS]";
    
    public struct TextParseSaveParams
    {
        public string RootPath;
        public string FileName;
        public int StartID = 0;
        public List<Animation> Animations;
        public List<Tuple<string, Texture2D>> Textures;
        public Dictionary<string, int> TextureIds; // Texture Id mapping
        public EditorSetting EditorSetting = new EditorSetting();

        public TextParseSaveParams()
        {
            RootPath = null;
            FileName = null;
            Animations = null;
            Textures = null;
            TextureIds = null;
        }
    }

    public struct TextParseLoadResult
    {
        public string RootPath;
        public string Path;
        public Dictionary<string, int> TextureIds; // Texture Id mapping
        public List<Animation> Animations;
        public List<AnimationFrame> Frames;

        public TextParseLoadResult()
        {
            RootPath = "";
            Path = "";
            Animations = new();
            TextureIds = new();
            Frames = new();
        }
    }
    
    public static void Save(TextParseSaveParams param)
    {
        if (File.Exists(param.FileName))
            File.Delete(param.FileName);
        using (StreamWriter streamWriter = new StreamWriter(param.FileName))
        {
            streamWriter.WriteLine("# EDITOR ");
            streamWriter.WriteLine("# EDITOR rootPath " + param.RootPath);
            
            streamWriter.WriteLine(TEXTURES_PREFIX);
            foreach (var texture in param.Textures)
            {
                string path = texture.Item1.Remove(0, param.RootPath.Length);
                streamWriter.WriteLine(path + param.EditorSetting.Delimeter + texture.Item2);
            }
            streamWriter.WriteLine();
            
            streamWriter.WriteLine(SPRITES_PREFIX);
            int id = 0;
            foreach (var animation in param.Animations)
            {
                foreach (var frame in animation.Frames)
                {
                    streamWriter.WriteLine((param.StartID + id) + param.EditorSetting.Delimeter + 
                                           frame.Rect.Left + param.EditorSetting.Delimeter +
                                           frame.Rect.Top + param.EditorSetting.Delimeter +
                                           frame.Rect.Right + param.EditorSetting.Delimeter +
                                           frame.Rect.Bottom + param.EditorSetting.Delimeter +
                                           frame.TextureId);
                    frame.Id = id;
                    id++;
                }
            }
            streamWriter.WriteLine();

            streamWriter.WriteLine(ANIMATIONS_PREFIX);
            foreach (var animation in param.Animations)
            {
                if (animation.Name == Animation.SpriteOnlyAnimationName)
                    continue;
                string output = "" + id + param.EditorSetting.Delimeter;
                foreach (var frame in animation.Frames)
                {
                    output += frame.Id + param.EditorSetting.Delimeter + frame.FrameTime + param.EditorSetting.Delimeter;
                }
                streamWriter.WriteLine(output);
            }
        }

    }

    public static TextParseLoadResult? Load(string path, EditorSetting editorSetting)
    {
        
        const int UNKNOWN_SECTION = 0;
        const int TEXTURES_SECTION = 1;
        const int SPRITES_SECTION = 2;
        const int ANIMATIONS_SECTION = 3;
        const int EDITOR_SECTION = 100;
        using (StreamReader streamReader = new StreamReader(path))
        {
            
            try
            {
                
                TextParseLoadResult result = new TextParseLoadResult();
                result.Path = path;
                int section = 0;
                Dictionary<int, AnimationFrame> frames = new();
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine() ?? "";
                    line = line.Trim();
                    if (line.Length == 0)
                        continue;
                    if (line.StartsWith("#"))
                    {
                        if (line.Contains("EDITOR"))
                            section = EDITOR_SECTION;
                        else
                            continue;
                    }
                    if (line == TEXTURES_PREFIX)
                    {
                        section = TEXTURES_SECTION;
                        continue;
                    }
                    else if (line == SPRITES_PREFIX)
                    {
                        section = SPRITES_SECTION;
                        continue;
                    }
                    else if (line == ANIMATIONS_PREFIX)
                    {
                        section = ANIMATIONS_SECTION;
                        continue;
                    }
                    else if (line.StartsWith('['))
                    {
                        section = UNKNOWN_SECTION;
                        continue;
                    }
                    
                    switch (section)
                    {
                        case TEXTURES_SECTION:
                        {
                            string[] tokens = line.Split(editorSetting.Delimeter);
                            if (tokens.Length != 2)
                                throw new FormatException("[ERROR]: Wrong format for TEXTURES");
                            result.TextureIds.Add(tokens[0], int.Parse(tokens[1]));
                        }
                            break;
                        case SPRITES_SECTION:
                        {
                            string[] tokens = line.Split(editorSetting.Delimeter);
                            if (tokens.Length != 6)
                                throw new FormatException("[ERROR]: Wrong format for SPRITES");
                            int id = int.Parse(tokens[0]);
                            int left = int.Parse(tokens[1]);
                            int top = int.Parse(tokens[2]);
                            int right = int.Parse(tokens[3]);
                            int bottom = int.Parse(tokens[4]);
                            int textureId = int.Parse(tokens[5]);
                            AnimationFrame frame = new AnimationFrame(textureId);
                            frame.SetRect(new Rectangle(left, top, right - left,  bottom - top));
                            frames.Add(id, frame);
                        }
                            break;
                        case ANIMATIONS_SECTION:
                        {
                            string[] tokens = line.Split(editorSetting.Delimeter);
                            if (tokens.Length % 2 == 0 || tokens.Length < 3)
                                throw new FormatException("[ERROR]: Wrong format for ANIMATIONS");
                            Animation animation = new Animation();
                            for (int i = 1; i < tokens.Length; i += 2)
                            {
                                int frameId = int.Parse(tokens[i]);
                                int frameTime = int.Parse(tokens[i + 1]);
                                frames[frameId].SetFrameTime(frameTime);
                                animation.AddFrame(frames[frameId]);

                                frames.Remove(frameId);
                            }
                        }
                            break;
                        case EDITOR_SECTION:
                        {
                            line = line.Split("# EDITOR").Last().Trim();
                            string[] tokens = line.Split(' ');
                            if (tokens[0] == "rootPath")
                                result.RootPath = tokens[1];
                        }
                            break;
                    }
                    
                    
                }

                if (frames.Count > 0)
                {
                    Animation anim = new Animation();
                    anim.SetName(Animation.SpriteOnlyAnimationName);
                    anim.Frames.AddRange(frames.Values.ToList());
                    result.Animations.Insert(0, anim);
                }

                if (result.Animations.Count == 0)
                    return null;
                return result;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        return null;
    }
}