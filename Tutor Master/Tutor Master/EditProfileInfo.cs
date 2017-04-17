using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tutor_Master
{
    public partial class EditProfileInfo : Form
    {
        private string first, last, user, pass;
        private bool isTutee, isTutor, isFaculty, isAdmin;

        List<string> tuteeCoursesList;
        List<string> tutorCoursesList;
        List<string> tutorCourseApprovedList;
        List<string> profileInfo;


        public EditProfileInfo()
        {
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;


        }

        public EditProfileInfo(string username)
        {
            InitializeComponent();
            this.Icon = Tutor_Master.Properties.Resources.favicon;

            user = username;
            initInfo(username);
        }

        private void initInfo(string username)
        {
            Database db = new Database();
            profileInfo = db.getProfileInfo(username);

            first = profileInfo[0];
            last = profileInfo[1];
            isTutor = bool.Parse(profileInfo[2]);
            isTutee = bool.Parse(profileInfo[3]);
            tuteeCoursesList = profileInfo.GetRange(4, 4);
            tutorCoursesList = profileInfo.GetRange(8, 4);
            tutorCourseApprovedList = profileInfo.GetRange(12, 4);
            isFaculty = bool.Parse(profileInfo[17]);
            isAdmin = bool.Parse(profileInfo[18]);
        }


    }
}
