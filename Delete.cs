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
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facebook;
using Microsoft.VisualBasic.PowerPacks;

namespace SocialMe
{
    public partial class Delete : Form
    {
        bool isCanceled = false;
        FacebookClient fb = new FacebookClient();
        List<Group> Groups = new List<Group>();
        List<Post> Posts = new List<Post>();
        string access_token = "";
        public class Group
        {
            public string Groupname { get; set; }
            public string GroupID { get; set; }
        }
        public class Post
        {
            public string PostName { get; set; }
            public string PostID { get; set; }
            public string FkGroup { get; set; }
        }
        public Delete(string access)
        {
            InitializeComponent();
            access_token = access;
        }
        private void AntiSpam_Load(object sender, EventArgs e)
        {
            fb.AccessToken = access_token;
            
        }
        public bool HasArabicGlyphs(string text)
        {
            char[] glyphs = text.ToCharArray();
            foreach (char glyph in glyphs)
            {
                if (glyph >= 0x600 && glyph <= 0x6ff) return true;
                if (glyph >= 0x750 && glyph <= 0x77f) return true;
                if (glyph >= 0xfb50 && glyph <= 0xfc3f) return true;
                if (glyph >= 0xfe70 && glyph <= 0xfefc) return true;
            }
            return false;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            GroupCb.Items.Clear();
            label2.Hide();
            GroupCb.Hide();
            button2.Hide();
            button3.Show(); //Show the Stop Button
            dynamic groups = await fb.GetTaskAsync("/me/groups"); //Get All the user groups
            dynamic me = await fb.GetTaskAsync("/me"); //Get the user info
            for (int i = 0; i < (int)groups.data.Count; i++)
            {
                //Check if the user pressed stop button because if he did that we won't complete the search operation
                if (isCanceled)
                {
                    toolStripStatusLabel1.Text = "Canceled";
                    isCanceled = false;
                    break;
                }
                try
                {
                    //Create the query which will write into Facebook FQL to get the user's post in the selected group
                    string query = String.Format("SELECT message,post_id FROM stream WHERE source_id={0} and actor_id={1} and strpos(message,'{2}') >=0", groups.data[i].id, me.id, txtSpam.Text);
                    dynamic Parameters = new ExpandoObject();
                    Parameters.q = query;
                    dynamic allposts = await fb.GetTaskAsync("/fql", Parameters); //Get the user posts from the group


                    
                    toolStripStatusLabel1.Text = "Searching in Group: " + groups.data[i].name;
                    //Check if the user has posts on this group
                    if (allposts.data.Count > 0)
                    {
                        label2.Show();
                        GroupCb.Show(); //Show the CheckBox List for the Groups
                        txtSpam.RightToLeft = HasArabicGlyphs(allposts.data[0].message) ? RightToLeft.Yes : RightToLeft.No; //Check if the text is Arabic because if it's arabic we'll set the Right To Left Property Enabled
                        txtSpam.Text = allposts.data[0].message;
                        //Add the group which has the user posts to the Groups List
                        Groups.Add(new Group
                        {
                            GroupID = groups.data[i].id,
                            Groupname = groups.data[i].name
                        });
                        //Add the group the CheckBox List
                        GroupCb.Items.Add(groups.data[i].name, true);
                        for (int j = 0; j < (int)allposts.data.Count; j++)
                        {
                            //Add Post Info to the Posts List
                            Posts.Add(new Post
                            {
                                FkGroup = groups.data[i].id,
                                PostID = allposts.data[j].post_id,
                                PostName = allposts.data[j].message
                            });
                        }
                    }
                }
            catch{
                toolStripStatusLabel1.Text = "Canceled";
            }
            }
            if (GroupCb.Items.Count>0)
            {
                button2.Show();                
            }
            button3.Hide();
            toolStripStatusLabel1.Text = "Ready";
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Groups.Count; i++)
            {
                if (GroupCb.GetItemChecked(i))
                {
                    //Get the user posts from the selected group
                    var desired_posts=Posts.Where((p)=>p.FkGroup==Groups[i].GroupID).ToList();
                    //Delete the user posts
                    for (int j = 0; j < desired_posts.Count(); j++)
                    {
                        toolStripStatusLabel1.Text = "Deleting Post From Group: "+Groups[i].Groupname;
                        await fb.DeleteTaskAsync(desired_posts[i].PostID);
                    }
                }
            }
            toolStripStatusLabel1.Text = "Ready";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            isCanceled = true;
            button3.Hide();
        }



    }
}
