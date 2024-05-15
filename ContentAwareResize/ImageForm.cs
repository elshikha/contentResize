using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContentAwareResize
{
    public partial class ImageForm : Form
    {
        public ImageForm(Bitmap image)
        {
            InitializeComponent();
            int hMargin = 40 ;
            int vMargin = 80;
            
            pictureBox1.Image = image;
            this.Size = new Size(image.Width + hMargin, image.Height + vMargin);
        }

        private void ImageForm_Load(object sender, EventArgs e)
        {

        }
    }
}
