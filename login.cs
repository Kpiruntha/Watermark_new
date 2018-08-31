
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StegWaterMark.Resource {
    public partial class Login : Form {
        private Home hm { get; set; }
        public Login() {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            try {
                var usn = txtUsername.Text;
                var psw = txtPassword.Text;
                if (string.IsNullOrWhiteSpace(usn)) {
                    MessageBox.Show(@"Please enter username"); return;
                }
                if (string.IsNullOrWhiteSpace(psw)) {
                    MessageBox.Show(@"Please enter password"); return;
                }

                var crd = TextFileHandler.ReadFile(@"Resource\Cred.txt");
                var credentials = crd.Split('░');
                var susn = credentials[0];
                var spsw = credentials[1];
                if (susn.Equals(usn) && spsw.Equals(psw)) {
                    if (hm == null || hm.IsDisposed) {
                        hm = new Home();
                    }
                    hm.Show();
                    this.Hide();
                }
                else {
                    MessageBox.Show(@"Incorrect username or password"); return;
                }
            }
            catch (Exception exception) {
                ErrorLogger.Log("Error occured in login", exception);
            }
        }
    }
}
