using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CleaningApplication
{
    public partial class WebForm23 : System.Web.UI.Page
    {
        DataAccessLayer dao = new DataAccessLayer();
       

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            

            int storyid = dao.addStory(txtheading.Text, txtdescription.Text);
            Session["storyid"] = storyid.ToString();

            lblmessage.Text = "the story has been added, add the images ";

            //addBeforeImages();
            
            
            //addAfterImages();
            
           
           
            //lblmessage.Text = "The story was added successfully";

        }

        public void addBeforeImages()
        {
            int storyid = Convert.ToInt32(Session["storyid"]);
            if (fpBefore.HasFiles)
            {
                string filePath = Server.MapPath("~/images/stories/");
                HttpFileCollection beforeImages = Request.Files;
                for (int i = 0; i < beforeImages.Count; i++)
                {
                    HttpPostedFile userPostedFile = beforeImages[i];
                    try
                    {
                        if (userPostedFile.ContentLength > 0)
                        {
                            userPostedFile.SaveAs(filePath + Path.GetFileName(userPostedFile.FileName));
                            string imgPath = "/images/stories/" + userPostedFile.FileName;
                            string imgName = userPostedFile.FileName;

                            dao.addBeforeImages(imgPath, storyid);


                        }
                    }
                    catch (Exception ex)
                    {
                        lblmessage.Text = "Exception:" + ex.Message.ToString();

                    }
                }
            }
        }

        public void addAfterImages()
        {
            int storyid = Convert.ToInt32(Session["storyid"]);
           
            if (fpAfter.HasFiles)
            {
                string filePath2 = Server.MapPath("~/images/stories/");
                HttpFileCollection afterImages = Request.Files;

                for (int i = 0; i < afterImages.Count; i++)
                {
                    HttpPostedFile userPosteddFile = afterImages[i];
                    try
                    {
                        if (userPosteddFile.ContentLength > 0)
                        {
                            userPosteddFile.SaveAs(filePath2 + Path.GetFileName(userPosteddFile.FileName));
                            string imgPath = "/images/stories/" + userPosteddFile.FileName;
                            string imgName = userPosteddFile.FileName;

                            if (i == afterImages.Count - 1)
                            {
                                dao.addAfterImages(imgPath, storyid, "Yes");
                            }
                            else
                            {
                                dao.addAfterImages(imgPath, storyid, "No");
                            }


                        }
                    }
                    catch (Exception ex)
                    {
                        lblmessage.Text = "Exception:" + ex.Message.ToString();

                    }
                }
            }
        }

        protected void btnbefore_Click(object sender, EventArgs e)
        {
            addBeforeImages();
            lblmessage.Text = "The before images have been added";
        }

        protected void btnafter_Click(object sender, EventArgs e)
        {
            addAfterImages();
            lblmessage.Text = "The after images have been added";
        }
    }
}