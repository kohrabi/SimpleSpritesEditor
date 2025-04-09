using System.ComponentModel;
using Editor.Controls;
using Editor.Objects;
using Microsoft.Xna.Framework.Graphics;
using WinFormsApp1.Objects;
using WinFormsApp1.Parsers;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        private SaveFileDialog exportFileDialog;

        private EditorSetting editorSetting = new EditorSetting();

        private const int INPUT_TEXT_ANIMATION = 1;
        private const int INPUT_TEXT_FRAME = 2;
        private int inputTextIndex = 0;


        public Form1()
        {

            openFileDialog = new OpenFileDialog();

            saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.Filter = "*.txt|*.txt";
            
            exportFileDialog = new SaveFileDialog();
            exportFileDialog.DefaultExt = ".h";
            exportFileDialog.Filter = "*.h|*.h";
            exportFileDialog.FileName = editorSetting.ObjectName.Replace(" ", "");

            InitializeComponent();
            animationsList.DataSource = mainControl.Animations;
            animationsList.DisplayMember = "Name";

            var animationFramesBinding = new BindingList<AnimationFrame>();
            animationFramesList.DataSource = animationFramesBinding;
            animationFramesList.DisplayMember = "Name";
            animationFramesList.SelectedIndexChanged += (o, e) =>
            {
                mainControl.Invalidate();
                animationControl.Invalidate();
            };

            texturesList.DataSource = mainControl.Textures;
            texturesList.DisplayMember = "FilePath";

            texturesList.SelectedIndexChanged += (o, e) =>
            {
                mainControl.Invalidate();
                animationControl.Invalidate();
            };
            
            
            animationControl.MainControl = mainControl;

            inputTextBox.Hide();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                TextParser.TextParseLoadResult? resultNull = TextParser.Load(openFileDialog.FileName, editorSetting);
                if (resultNull == null)
                {
                    return;
                }
                var result = (TextParser.TextParseLoadResult)resultNull;
                mainControl.SetLoad(result);
                editorSetting.FilePath = result.Path;
                editorSetting.ObjectName = result.ObjectName;
                editorSetting.StartID = result.StartId;
                if (result.RootPath != "")
                    editorSetting.RootPath = result.RootPath;
                else
                    editorSetting.RootPath = Path.GetDirectoryName(result.Path);
                    

                if (mainControl.Animations.Count > 0)
                {
                    var animationFramesBinding = new BindingList<AnimationFrame>(mainControl.Animations[0].Frames);
                    animationFramesList.DataSource = animationFramesBinding;
                    animationFramesList.DisplayMember = "Name";
                }

                animationsList.DataSource = mainControl.Animations;
                texturesList.DataSource = new BindingList<AnimationTexture>(mainControl.Textures);
                (animationFramesList.DataSource as BindingList<AnimationFrame>).ResetBindings();

            }
        }

        #region  Animation

        private void addAnimation_Click(object sender, EventArgs e)
        {
            if (texturesList.SelectedIndex < 0 || texturesList.SelectedIndex > mainControl.Textures.Count - 1) return;

            mainControl.Animations.Add(new Animation());
            animationsList.SelectedIndex = mainControl.Animations.Count - 1;
            mainControl.SelectedAnimationIndex = animationsList.SelectedIndex;

            animationFramesList.DataSource = mainControl.Animations[mainControl.SelectedAnimationIndex].Frames;
            animationFramesList.DisplayMember = "Name";
            
        }

        private void removeAnimation_Click(object sender, EventArgs e)
        {
            if (animationsList.SelectedIndex < 0 || animationsList.SelectedIndex > mainControl.Animations.Count - 1) return;
            mainControl.Animations.RemoveAt(mainControl.SelectedFrameIndex);
            mainControl.Invalidate();
            animationControl.Invalidate();
        }

        private void animationsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (animationsList.SelectedIndex < 0 || animationsList.SelectedIndex > mainControl.Animations.Count - 1) return;
            mainControl.SelectedAnimationIndex = animationsList.SelectedIndex;
            propertyGrid1.SelectedObject = mainControl.Animations[mainControl.SelectedAnimationIndex];


            animationFramesList.DataSource = mainControl.Animations[mainControl.SelectedAnimationIndex].Frames;
            animationFramesList.DisplayMember = "Name";

            animationControl.SelectAnimation();

        }

        private void animationsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (animationsList.SelectedItem == null || animationsList.SelectedIndex == 0) return;
        }

        #endregion

        #region  Animation Frame

        private void addAnimationFrame_Click(object sender, EventArgs e)
        {
            mainControl.AddNewFrame();
            var dataSource = animationFramesList.DataSource as BindingList<AnimationFrame>;
            dataSource.ResetBindings();

            animationFramesList.SelectedIndex = dataSource.Count - 1;
            mainControl.SelectedFrameIndex = animationFramesList.SelectedIndex;
            dataSource.ResetBindings();
        }

        private void removeAnimationFrame_Click(object sender, EventArgs e)
        {
            if (animationsList.SelectedIndex < 0 || animationsList.SelectedIndex > mainControl.Animations.Count - 1) return;
            if (animationFramesList.SelectedIndex < 0 || animationFramesList.SelectedIndex >
                mainControl.Animations[mainControl.SelectedAnimationIndex].Frames.Count - 1) return;
            (animationFramesList.DataSource as BindingList<AnimationFrame>).RemoveAt(mainControl.SelectedFrameIndex);
        }

        private void animationFramesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            mainControl.SelectedFrameIndex = animationFramesList.SelectedIndex;
            propertyGrid1.SelectedObject = animationFramesList.SelectedItem;
        }

        private void animationFramesList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (animationFramesList.SelectedItem == null) return;
        }

        #endregion

        #region Texture

        private void addTexture_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "*.png|*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                mainControl.LoadTexture(openFileDialog.FileName);
                (texturesList.DataSource as BindingList<AnimationTexture>).ResetBindings();
            }
        }

        private void removeTexture_Click(object sender, EventArgs e)
        {
            if (texturesList.SelectedIndex < 0 || texturesList.SelectedIndex > texturesList.Items.Count - 1) return;
            mainControl.UnloadTexture(texturesList.SelectedIndex);
            (texturesList.DataSource as BindingList<AnimationTexture>).ResetBindings();
        }

        private void texturesList_SelectedIndexChange(object sender, EventArgs e)
        {
            mainControl.SelectTexture(texturesList.SelectedIndex);
        }

        #endregion

        #region Input Text Box

        private void inputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                inputTextBox.Hide();
                if (inputTextIndex == INPUT_TEXT_FRAME)
                {
                    (animationFramesList.SelectedItem as AnimationFrame).SetName(inputTextBox.Text);
                    (animationFramesList.DataSource as BindingList<AnimationFrame>).ResetBindings();
                }
                else if (inputTextIndex == INPUT_TEXT_ANIMATION)
                {
                    (animationsList.SelectedItem as Animation).SetName(inputTextBox.Text);
                    (animationsList.DataSource as BindingList<Animation>).ResetBindings();
                }

                inputTextIndex = 0;
            }
        }

        private void inputTextBox_FocusLeave(object sender, EventArgs e)
        {
            inputTextBox.Hide();
        }

        private void inputTextBox_VisibleChanged(object sender, EventArgs e)
        {
        }
        #endregion

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // if (editorSetting.FilePath.Trim() == "") return;
            TextParser.TextParseSaveParams param = new TextParser.TextParseSaveParams();
            param.RootPath = editorSetting.RootPath;
            param.EditorSetting = editorSetting;
            param.StartId = editorSetting.StartID;
            param.TextureIds = mainControl.TextureIds;
            param.Animations = mainControl.Animations.ToList();
            param.Textures = mainControl.Textures.ToList();
            param.ObjectName = editorSetting.ObjectName;
            saveFileDialog.FileName = param.ObjectName.ToLower().Replace(" ", "_");
            if (editorSetting.FilePath == "")
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    param.FileName = saveFileDialog.FileName;
                }
                if (param.FileName == "")
                {
                    MessageBox.Show("ERROR", "Something went wrong when openning file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                param.FileName = editorSetting.FilePath;
            }

            if (param.FileName.Trim() != "")
            {
                editorSetting.FilePath = param.FileName.Trim();
                TextParser.Save(param);
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exportFileDialog.FileName = editorSetting.ObjectName.Replace(" ", "");
            if (exportFileDialog.ShowDialog() == DialogResult.OK)
            {
                HeaderExport.HeaderExportParams param = new HeaderExport.HeaderExportParams();
                param.FilePath = exportFileDialog.FileName;
                param.RootPath = editorSetting.RootPath;
                param.ContentFilePath = editorSetting.FilePath;
                param.StartId = editorSetting.StartID;
                param.Animations = mainControl.Animations.ToList();
                param.ObjectName = editorSetting.ObjectName;
                HeaderExport.Export(param);
            }
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            mainControl.Animations.ResetBindings();
            mainControl.Textures.ResetBindings();
            (animationFramesList.DataSource as BindingList<AnimationFrame>).ResetBindings();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = editorSetting;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = editorSetting.ObjectName.ToLower().Replace(" ", "");
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                TextParser.TextParseSaveParams param = new TextParser.TextParseSaveParams();
                editorSetting.FilePath = saveFileDialog.FileName; 
                param.FileName = saveFileDialog.FileName;
                
                
                param.RootPath = editorSetting.RootPath;
                param.EditorSetting = editorSetting;
                param.StartId = editorSetting.StartID;
                param.TextureIds = mainControl.TextureIds;
                param.Animations = mainControl.Animations.ToList();
                param.Textures = mainControl.Textures.ToList();
                param.ObjectName = editorSetting.ObjectName;
                
                if (editorSetting.FilePath.Trim() != "")    
                    TextParser.Save(param);
                
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editorSetting = new EditorSetting();
            mainControl.Reset();
            
            animationFramesList.DataSource = new BindingList<AnimationFrame>();
            texturesList.DataSource = mainControl.Textures;
        }
    }
}