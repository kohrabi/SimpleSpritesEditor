using Editor.Controls;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private OpenFileDialog openFileDialog;
        
        
        
        public Form1()
        {
            
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.png|*.png";
            
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sampleControl.LoadTexture(openFileDialog.FileName);
            }
            
        }
    }
}