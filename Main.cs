/*
 * Social Me Project
 * Developed By : Abdelrhman Shawky
 * fb.com/shawkyz1
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facebook;

namespace SocialMe
{
    public partial class Main : Form
    {
        string accesstoken = "";
        public Main(string access)
        {
            InitializeComponent();
            accesstoken = access;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Post f = new Post(accesstoken);
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Delete an = new Delete(accesstoken);
            an.Show();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item is MdiClient)
                {
                    item.BackColor = Color.White;
                    break;
                }
            }
            Point point = new Point(0, 0);
            Post p = new Post(accesstoken);
            p.Location = point;
            p.MdiParent = this;
            PostTab.Controls.Add(p);
            p.Show();
            Delete an = new Delete(accesstoken);
            an.Location = point;
            an.MdiParent = this;
            DeleteTab.Controls.Add(an);
            an.Show();
        }

        private void postToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PostInstructions pi = new PostInstructions();
            pi.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteInstructions di = new DeleteInstructions();
            di.Show();
        }

        private void developerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About d = new About();
            d.Show();
        }

        private void sourceCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ShawkyZ/Social-Me");
        }
    }
}
