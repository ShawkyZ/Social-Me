/*
 * Social Me Project
 * Developed By : Abdelrhman Shawky
 * fb.com/shawkyz1
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facebook;

namespace SocialMe
{
    public partial class Login : Form
    {
        FacebookClient fb = new FacebookClient();
        List<Group> Groups = new List<Group>();
        List<Page> Pages = new List<Page>();
        public class Group
        {
            public string Groupname { get; set; }
            public string GroupID { get; set; }
        }
        public class Page
        {
            public string Pagename { get; set; }
            public string PageID { get; set; }
        }
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
      

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //When the WebBrowser Control successfully navigate we'll take the access token from final URL and send it to the other Main Form
            if (e.Url.AbsoluteUri.Contains("access_token"))
            {
                webBrowser1.Hide();
                string raw_access_token = e.Url.AbsoluteUri.Substring(e.Url.AbsoluteUri.IndexOf("access_token="));
                string expiredate = e.Url.AbsoluteUri.Substring(e.Url.AbsoluteUri.IndexOf("&expires_in="));
                string access_token = raw_access_token.Replace(expiredate, "").Replace("access_token=","");
                Main form2 = new Main(access_token);
                this.Hide();
                form2.Show();
            }
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Show();
            //Creating Facebook Login URL
            var uri = fb.GetLoginUrl(new
            {
                client_id = "312241548925621",
                redirect_uri = "https://www.facebook.com/connect/login_success.html",
                response_type = "token",
                scope = "publish_stream,user_about_me,publish_actions,user_groups,manage_pages",
                display = "popup"
            });
            //Navigate To The Created URL
            webBrowser1.Navigate(uri.AbsoluteUri);
        }
    }
}
