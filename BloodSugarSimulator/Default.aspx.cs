using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BloodSugarSimulator
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string exerciseDbFileLocation = ConfigurationManager.AppSettings["exerciseDbFileLocation"];
            string foodDbFileLocation = ConfigurationManager.AppSettings["foodDbFileLocation"];
            string inputFileLocation = ConfigurationManager.AppSettings["inputFileLocation"];
            ltlExerciseDbFileLocation.Text = exerciseDbFileLocation;
            ltlFoodDbFileLocation.Text = foodDbFileLocation;
            ltlInputFileLocation.Text = inputFileLocation;
        }
    }
}