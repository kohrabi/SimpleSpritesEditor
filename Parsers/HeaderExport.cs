using WinFormsApp1.Data;

namespace WinFormsApp1.Parsers;

public static class HeaderExport
{
    
    public struct HeaderExportParams
    {
        public string FilePath;
        public string ObjectName;
        public int StartId = 0;
        public List<Animation> Animations;
        public Dictionary<string, int> TextureIds;

        public HeaderExportParams()
        {
            FilePath = null;
            ObjectName = null;
            Animations = null;
            TextureIds = null;
        }
    }
    
    public static void Export(HeaderExportParams param)
    {
        if (File.Exists(param.FilePath))
            File.Delete(param.FilePath);
        using (StreamWriter streamWriter = new StreamWriter(param.FilePath))
        {
            streamWriter.WriteLine("#pragma once");
            streamWriter.WriteLine();
            
            streamWriter.WriteLine("#define " + param.ObjectName.ToUpper() + "_ID " + param.StartId);
            streamWriter.WriteLine();
            
            int id = param.StartId + 1;
            foreach (var animation in param.Animations)
            {
                int frameIndex = 0;
                foreach (var frame in animation.Frames)
                {
                    string outputSprites = "#define " + param.ObjectName.ToUpper() + "_ID_SPRITES_";
                    if (animation.Name != Animation.SpriteOnlyAnimationName)
                        outputSprites += animation.Name.ToUpper() + "_FRAME_" + frameIndex;
                    else
                        outputSprites += frame.Name.ToUpper().Replace(" ", "_");
                    outputSprites += " " + id;
                    streamWriter.WriteLine(outputSprites);
                    frameIndex++;
                    id++;
                }

                
            }
            streamWriter.WriteLine();

            foreach (var animation in param.Animations)
            {
                if (animation.Name == Animation.SpriteOnlyAnimationName)
                    continue;
                string outputAnimation = "#define " + param.ObjectName.ToUpper() + "_ID_ANIMATION_";
                outputAnimation += animation.Name.ToUpper();
                outputAnimation += " " + id;
                streamWriter.WriteLine(outputAnimation);
            }
        }
    }
}