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

namespace BloodSugarSimulator
{
    public partial class TextOutput : Page
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

            List<BloodSugar> flattenedBloodSugars = new List<BloodSugar>();
            bloodSugars.ForEach(o => flattenedBloodSugars.AddRange(o));
            rptBloodSugar.DataSource = flattenedBloodSugars;
            rptBloodSugar.DataBind();


            // Calculate Glycation
            var glycationCalculator = new GlycationCalculator();
            List<List<Glycation>> glycations = glycationCalculator.GetGlycation(bloodSugars);

            List<Glycation> flattenedGlycations = new List<Glycation>();
            glycations.ForEach(o => flattenedGlycations.AddRange(o));
            rptGlycation.DataSource = flattenedGlycations;
            rptGlycation.DataBind();
        }

        protected void rptBloodSugar_OnItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            if (!(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem))
                return;

            var bloodSugar = e.Item.DataItem as BloodSugar;
            
            var ltlDateTime = e.Item.FindControl("ltlDateTime") as Literal;
            var ltlLevel = e.Item.FindControl("ltlLevel") as Literal;
            
            ltlDateTime.Text = bloodSugar.Timestamp.ToDateTime().ToString(CultureInfo.InvariantCulture);
            ltlLevel.Text = bloodSugar.Level.ToString("#.##");
            
        }

        protected void rptGlycation_OnItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            if (!(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem))
                return;

            var glycation = e.Item.DataItem as Glycation;

            var ltlLevel = e.Item.FindControl("ltlLevel") as Literal;

            ltlLevel.Text = glycation.Level.ToString();
        }
    }
}