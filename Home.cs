using System;
using System.Windows.Forms;

namespace StegWaterMark
{
    public partial class Home : Form
    {
        private EmbedWaterMrkForm Wmk { get; set; }
        private AddWatermark AddWmk { get; set; }
        private ExtractWaterMrkForm ExtractWmk { get; set; }

        public Home()
        {
            InitializeComponent();
        }

        private void btnEmbed_Click(object sender, EventArgs e)
        {
            if (Wmk == null || Wmk.IsDisposed)
            {
                Wmk = new EmbedWaterMrkForm();
            }
            Wmk.Show();
        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            if (ExtractWmk == null || ExtractWmk.IsDisposed)
            {
                ExtractWmk = new ExtractWaterMrkForm();
            }
            ExtractWmk.Show();
        }

        private void btnAddWaterMrk_Click(object sender, EventArgs e)
        {
            if (AddWmk == null || AddWmk.IsDisposed)
            {
                AddWmk = new AddWatermark();
            }
            AddWmk.Show();
        }

        private void btnForgeIdt_Click(object sender, EventArgs e)
        {

        }
    }
}
