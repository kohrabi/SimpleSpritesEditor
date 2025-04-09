using System.ComponentModel;
using Editor.Controls;
using Microsoft.Xna.Framework.Graphics;
using WinFormsApp1.Objects;
using WinFormsApp1.Parsers;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;

        private const int INPUT_TEXT_ANIMATION = 1;
        private const int INPUT_TEXT_FRAME = 2;
        private int inputTextIndex = 0;

        private string filePath = String.Empty;
        private string rootPath = String.Empty;
        private int startId = 0;

        public Form1()
        {

            openFileDialog = new OpenFileDialog();

            saveFileDialog = new SaveFileDialog();

            InitializeComponent();
            animationsList.DataSource = sampleControl.Animations;
            animationsList.DisplayMember = "Name";

            var animationFramesBinding = new BindingList<AnimationFrame>();
            animationFramesList.DataSource = animationFramesBinding;
            animationFramesList.DisplayMember = "Name";

            texturesList.DataSource = sampleControl.Textures;
            texturesList.DisplayMember = "Item1";

            inputTextBox.Hide();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "*.txt|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                TextParser.TextParseLoadResult? resultNull = TextParser.Load(openFileDialog.FileName, new EditorSetting());
                if (resultNull == null)
                {
                    return;
                }
                var result = (TextParser.TextParseLoadResult)resultNull;
                sampleControl.SetLoad(result);
                filePath = result.Path;
                rootPath = result.RootPath;

                if (sampleControl.Animations.Count > 0)
                {
                    var animationFramesBinding = new BindingList<AnimationFrame>(sampleControl.Animations[0].Frames);
                    animationFramesList.DataSource = animationFramesBinding;
                    animationFramesList.DisplayMember = "Name";
                }

                animationsList.DataSource = sampleControl.Animations;
                texturesList.DataSource = new BindingList<Tuple<string, Texture2D>>(sampleControl.Textures);
                (animationFramesList.DataSource as BindingList<AnimationFrame>).ResetBindings();

            }
        }

        #region  Animation

        private void addAnimation_Click(object sender, EventArgs e)
        {
            if (texturesList.SelectedIndex < 0 || texturesList.SelectedIndex > sampleControl.Textures.Count - 1) return;

            sampleControl.Animations.Add(new Animation());
            animationsList.SelectedIndex = sampleControl.Animations.Count - 1;
            sampleControl.SelectedAnimationIndex = animationsList.SelectedIndex;

            animationFramesList.DataSource = sampleControl.Animations[sampleControl.SelectedAnimationIndex].Frames;
            animationFramesList.DisplayMember = "Name";
        }

        private void removeAnimation_Click(object sender, EventArgs e)
        {
            if (animationsList.SelectedIndex < 0 || animationsList.SelectedIndex > sampleControl.Animations.Count - 1) return;
            sampleControl.Animations.RemoveAt(sampleControl.SelectedFrameIndex);
        }

        private void animationsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (animationsList.SelectedIndex < 0 || animationsList.SelectedIndex > sampleControl.Animations.Count - 1) return;
            sampleControl.SelectedAnimationIndex = animationsList.SelectedIndex;
            propertyGrid1.SelectedObject = sampleControl.Animations[sampleControl.SelectedAnimationIndex];


            animationFramesList.DataSource = sampleControl.Animations[sampleControl.SelectedAnimationIndex].Frames;
            animationFramesList.DisplayMember = "Name";

        }

        private void animationsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (animationsList.SelectedItem == null || animationsList.SelectedIndex == 0) return;
        }

        #endregion

        #region  Animation Frame

        private void addAnimationFrame_Click(object sender, EventArgs e)
        {
            sampleControl.AddNewFrame();
            var dataSource = animationFramesList.DataSource as BindingList<AnimationFrame>;
            dataSource.ResetBindings();

            animationFramesList.SelectedIndex = dataSource.Count - 1;
            sampleControl.SelectedFrameIndex = animationFramesList.SelectedIndex;
            dataSource.ResetBindings();
        }

        private void removeAnimationFrame_Click(object sender, EventArgs e)
        {
            if (animationsList.SelectedIndex < 0 || animationsList.SelectedIndex > sampleControl.Animations.Count - 1) return;
            if (animationFramesList.SelectedIndex < 0 || animationFramesList.SelectedIndex >
                sampleControl.Animations[sampleControl.SelectedAnimationIndex].Frames.Count - 1) return;
            (animationFramesList.DataSource as BindingList<AnimationFrame>).RemoveAt(sampleControl.SelectedFrameIndex);
        }

        private void animationFramesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            sampleControl.SelectedFrameIndex = animationFramesList.SelectedIndex;
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
                sampleControl.LoadTexture(openFileDialog.FileName);
                (texturesList.DataSource as BindingList<Tuple<string, Texture2D>>).ResetBindings();
            }
        }

        private void removeTexture_Click(object sender, EventArgs e)
        {
            if (texturesList.SelectedIndex < 0 || texturesList.SelectedIndex > texturesList.Items.Count - 1) return;
            sampleControl.UnloadTexture(texturesList.SelectedIndex);
            (texturesList.DataSource as BindingList<Tuple<string, Texture2D>>).ResetBindings();
        }

        private void texturesList_SelectedIndexChange(object sender, EventArgs e)
        {
            sampleControl.SelectTexture(texturesList.SelectedIndex);
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
            if (filePath.Trim() == "") return;
            if (filePath == "")
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    TextParser.TextParseSaveParams param = new TextParser.TextParseSaveParams();
                    param.FileName = saveFileDialog.FileName;
                    param.RootPath = rootPath;
                    param.EditorSetting = new EditorSetting();
                    param.Animations = sampleControl.Animations.ToList();
                    param.Textures = sampleControl.Textures.ToList();
                    param.TextureIds = sampleControl.TextureIds;
                    TextParser.Save(param);
                }
            }
            else
            {
                TextParser.TextParseSaveParams param = new TextParser.TextParseSaveParams();
                param.FileName = filePath;
                param.RootPath = rootPath;
                param.EditorSetting = new EditorSetting();
                param.Animations = sampleControl.Animations.ToList();
                param.Textures = sampleControl.Textures.ToList();
                param.TextureIds = sampleControl.TextureIds;
                TextParser.Save(param);
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.DefaultExt = ".h";
            saveFileDialog.Filter = "*.h|*.h";
            saveFileDialog.FileName = "ObjectName";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                HeaderExport.HeaderExportParams param = new HeaderExport.HeaderExportParams();
                param.FilePath = saveFileDialog.FileName;
                param.StartId = startId;
                param.Animations = sampleControl.Animations.ToList();
                param.TextureIds = sampleControl.TextureIds;
                param.ObjectName = "Koopa";
                HeaderExport.Export(param);
            }
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            sampleControl.Animations.ResetBindings();
            sampleControl.Textures.ResetBindings();
            (animationFramesList.DataSource as BindingList<AnimationFrame>).ResetBindings();
        }
    }
}