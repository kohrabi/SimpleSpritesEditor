using System.ComponentModel;
using Editor.Controls;
using Microsoft.Xna.Framework.Graphics;
using WinFormsApp1.Data;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openFileDialog;

        private const int INPUT_TEXT_ANIMATION = 1;
        private const int INPUT_TEXT_FRAME = 2;
        private int inputTextIndex = 0;
        
        public Form1()
        {
            
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.png|*.png";
            
            InitializeComponent();
            var animationsBinding = new BindingList<Animation>(sampleControl.Animations);
            animationsList.DataSource = animationsBinding;
            animationsList.DisplayMember = "Name";
            
            var animationFramesBinding = new BindingList<AnimationFrame>();
            animationFramesList.DataSource = animationFramesBinding;
            animationFramesList.DisplayMember = "Name";
            
            var texturesBinding = new BindingList<Tuple<string, Texture2D>>(sampleControl.Textures);
            texturesList.DataSource = texturesBinding;
            texturesList.DisplayMember = "Item1";
            
            inputTextBox.Hide();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        #region  Animation
        
        private void addAnimation_Click(object sender, EventArgs e)
        {
            if (texturesList.SelectedIndex < 0 || texturesList.SelectedIndex > sampleControl.Textures.Count - 1) return;
            (animationsList.DataSource as BindingList<Animation>)?.Add(new Animation());
            animationsList.SelectedIndex = (animationsList.DataSource as BindingList<Animation>).Count - 1;
            sampleControl.SelectedAnimationIndex = animationsList.SelectedIndex;
        }

        private void removeAnimation_Click(object sender, EventArgs e)
        {
            if (animationsList.SelectedIndex < 0 || animationsList.SelectedIndex > sampleControl.Animations.Count - 1) return;
            (animationsList.DataSource as BindingList<AnimationFrame>).RemoveAt(sampleControl.SelectedFrameIndex);
        }
        
        private void animationsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            sampleControl.SelectedAnimationIndex = animationsList.SelectedIndex;
            
            var animationFramesBinding = new BindingList<AnimationFrame>(sampleControl.Animations[animationsList.SelectedIndex].Frames);
            animationFramesList.DataSource = animationFramesBinding;
            animationFramesList.DisplayMember = "Name";
        }

        private void animationsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            inputTextBox.Show();
            inputTextIndex = INPUT_TEXT_ANIMATION;
            inputTextBox.Location = new Point(animationsList.Location.X, animationsList.Location.Y + animationsList.SelectedIndex * animationsList.ItemHeight);
            inputTextBox.Size = new Size(animationsList.Width - (animationsList.Padding.Horizontal) - 5, animationsList.ItemHeight);
        }
        
        #endregion

        #region  Animation Frame
        
        private void addAnimationFrame_Click(object sender, EventArgs e)
        {
            if (animationsList.SelectedIndex < 0 || animationsList.SelectedIndex > sampleControl.Animations.Count - 1) return;
            sampleControl.AddNewFrame();
            
            animationFramesList.SelectedIndex = (animationFramesList.DataSource as BindingList<AnimationFrame>).Count - 1;
            sampleControl.SelectedFrameIndex = animationFramesList.SelectedIndex;
            (animationFramesList.DataSource as BindingList<AnimationFrame>).ResetBindings();
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
        }
        
        private void animationFramesList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            inputTextBox.Show();
            inputTextIndex = INPUT_TEXT_FRAME;
            inputTextBox.Location = new Point(animationFramesList.Location.X, animationFramesList.Location.Y + animationFramesList.SelectedIndex * animationFramesList.ItemHeight);
            inputTextBox.Size = new Size(animationFramesList.Width - (animationFramesList.Padding.Horizontal) - 5, animationFramesList.ItemHeight);
        }
        
        #endregion  

        #region Texture
        
        private void addTexture_Click(object sender, EventArgs e)
        {
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
            if (inputTextBox.Visible)
                inputTextBox.Text = "";
        }
        #endregion

    }
}