using BloodSugarSimulator.Simulator.Data;
using BloodSugarSimulator.Simulator.Type;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BloodSugarSimulator.Simulator.Util;
using System.Globalization;
using BloodSugarSimulator.Simulator.Business;
using System.Text;

namespace BloodSugarSimulator
{
    public partial class GraphicOutput : Page
    {

        private Dictionary<int, Exercise> ExerciseDictionary { get; set; }
        private Dictionary<int, Food> FoodDictionary { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CsvReader reader = new CsvReader();
            var inputs = reader.GetInputList();
            var exerciseDictionary = reader.GetExerciseDictionary();
            var foodDictionary = reader.GetFoodDictionary();

            // Calculate Blood Level
            BloodSugarCalculator bloodSugarCalculator = new BloodSugarCalculator(exerciseDictionary, foodDictionary);
            List<List<BloodSugar>> bloodSugars = bloodSugarCalculator.GetBloodSugar(inputs);

            // Calculate Glycation
            var glycationCalculator = new GlycationCalculator();
            List<List<Glycation>> glycations = glycationCalculator.GetGlycation(bloodSugars);

            List<Tuple<List<BloodSugar>, List<Glycation>>> resultPerDay = new List<Tuple<List<BloodSugar>, List<Glycation>>>();
            for (int i = 0; i < bloodSugars.Count; i++)
            {
                resultPerDay.Add(new Tuple<List<BloodSugar>, List<Glycation>>(bloodSugars[i], glycations[i]));
            }

            rptDays.DataSource = resultPerDay;
            rptDays.DataBind();
        }

        protected void rptDays_OnItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            if (!(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem))
                return;

            var resultPerDay = e.Item.DataItem as Tuple<List<BloodSugar>, List<Glycation>>;
            var timestamp = resultPerDay.Item1[0].Timestamp;
            var day = resultPerDay.Item1[0].Timestamp.ToDateTime().ToString("yyyy/M/d");

            StringBuilder bloodSugarCsv = new StringBuilder();
            string delim = "";
            foreach(var bloodSugar in resultPerDay.Item1)
            {
                bloodSugarCsv.Append(delim);
                bloodSugarCsv.Append(bloodSugar.Level.ToString("#.##"));
                delim = ",";
            }

            StringBuilder glycationCsv = new StringBuilder();
            delim = "";
            foreach (var glycation in resultPerDay.Item2)
            {
                glycationCsv.Append(delim);
                glycationCsv.Append(glycation.Level);
                delim = ",";
            }
            
            var ltlContainerId = e.Item.FindControl("ltlContainerId") as Literal;
            var ltlContainerId2 = e.Item.FindControl("ltlContainerId2") as Literal;
            var ltlDay = e.Item.FindControl("ltlDay") as Literal;
            var ltlBloodSugarCsv = e.Item.FindControl("ltlBloodSugarCsv") as Literal;
            var ltlGlycationCsv = e.Item.FindControl("ltlGlycationCsv") as Literal;

            ltlContainerId.Text = timestamp.ToString();
            ltlContainerId2.Text = timestamp.ToString();
            ltlDay.Text = day;
            ltlBloodSugarCsv.Text = bloodSugarCsv.ToString();
            ltlGlycationCsv.Text = glycationCsv.ToString();
        }
    }
}