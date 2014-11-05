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
    public partial class Post : Form
    {
        FacebookClient fb = new FacebookClient();
        List<Group> Groups = new List<Group>();
        List<Page> Pages = new List<Page>();
        string access_token="";
        public class Group
        {
            public string Groupname { get; set; }
            public string GroupID { get; set; }
        }
        public class Page
        {
            public string Pagename { get; set; }
            public string PageID { get; set; }
            public string Pageaccess { get; set; }
        }
        public Post(string access)
        {
            access_token = access;
            InitializeComponent();
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            cbPrivacy.SelectedIndex = 0;
            fb.AccessToken = access_token;
            toolStripStatusLabel1.Text = "Getting Groups";
            dynamic groups = await fb.GetTaskAsync("/me/groups"); //Get the user groups
            for (int i = 0; i < (int)groups.data.Count; i++)
            {
                //Add the user groups the Groups List
                Groups.Add(new Group
                {
                    GroupID = groups.data[i].id,
                    Groupname = groups.data[i].name
                });
                //Add the user groups the CheckBox List
                GroupCb.Items.Add(groups.data[i].name);
            }
           
            toolStripStatusLabel1.Text = "Getting Your Pages";
            dynamic pages = await fb.GetTaskAsync("/me/accounts"); //Get the user Pages
            for (int i = 0; i < (int)pages.data.Count; i++)
            {
                //Add the user pages to the Pages List
                Pages.Add(new Page
                {
                    PageID = pages.data[i].id,
                    Pagename = pages.data[i].name,
                    Pageaccess = pages.data[i].access_token
                });
                //Add the user pages to the CheckBox List
                PageCb.Items.Add(pages.data[i].name);
            }
           
            toolStripStatusLabel1.Text = "Ready";
        }

        private void cbWall_CheckedChanged(object sender, EventArgs e)
        {
            if (cbWall.Checked)
            {
                label5.Show();
                cbPrivacy.Show();
            }
            else
            {
                label5.Hide();
                cbPrivacy.Hide();
            }
        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            //Set the post arguments for more info check the facebook graph documentation https://developers.facebook.com/docs/
            Dictionary<string, object> args = new Dictionary<string, object>();
            args["message"] = tbMessage.Text;
            args["link"] = tbLink.Text;
            //If the user chosed to post on his wall so we'll set the privacy value to the value chosen from the Privacy ComboBox
            switch (cbPrivacy.SelectedIndex)
            {
                case 0:
                    args["privacy"] = new { value = "EVERYONE" };
                    break;
                case 1:
                    args["privacy"] = new { value = "ALL_FRIENDS" };
                    break;
                case 2:
                    args["privacy"] = new { value = "SELF" };
                    break;
            }
            //Post to user's wall if he chosed that
            if (cbWall.Checked)
            {
                toolStripStatusLabel1.Text = "Posting To Your Wall";
                var id = await fb.PostTaskAsync("/me/feed", args);
            }
            //Remove the privacy Key becasue posting to Groups and Pages doesn't require this Key
            args.Remove("privacy");
            //Posting to the user selected Groups
            for (int i = 0; i < GroupCb.Items.Count; i++)
            {
                if (GroupCb.GetItemChecked(i))
                {
                    toolStripStatusLabel1.Text = "Posting To Group " + Groups[i].Groupname;
                    await fb.PostTaskAsync("/" + Groups[i].GroupID + "/feed", args);
                }
            }
            //Posting to the user selected Pages
            for (int i = 0; i < PageCb.Items.Count; i++)
            {
                if (PageCb.GetItemChecked(i))
                {
                    args["access_token"] = Pages[i].Pageaccess;
                    toolStripStatusLabel1.Text = "Posting To Page " + Pages[i].Pagename;
                    await fb.PostTaskAsync("/" + Pages[i].PageID + "/feed", args);
                }
            }
            toolStripStatusLabel1.Text = "Ready";
        }

    }
}
