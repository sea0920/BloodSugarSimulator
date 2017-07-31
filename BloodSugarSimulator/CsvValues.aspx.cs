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

namespace BloodSugarSimulator
{
    public partial class CsvValues : Page
    {

        private Dictionary<int, Exercise> ExerciseDictionary { get; set; }
        private Dictionary<int, Food> FoodDictionary { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CsvReader reader = new CsvReader();
            ExerciseDictionary = reader.GetExerciseDictionary();
            FoodDictionary = reader.GetFoodDictionary();

            rptExerciseDB.DataSource = ExerciseDictionary.Values;
            rptExerciseDB.DataBind();

            rptFoodDB.DataSource = FoodDictionary.Values;
            rptFoodDB.DataBind();

            rptInput.DataSource = reader.GetInputList();
            rptInput.DataBind();
        }

        protected void rptExerciseDB_OnItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            if (!(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem))
                return;

            var exercise = e.Item.DataItem as Exercise;

            var ltlID = e.Item.FindControl("ltlID") as Literal;
            var ltlExercise = e.Item.FindControl("ltlExercise") as Literal;
            var ltlExerciseIndex = e.Item.FindControl("ltlExerciseIndex") as Literal;

            ltlID.Text = exercise.Id.ToString();
            ltlExercise.Text = exercise.Name.ToString();
            ltlExerciseIndex.Text = exercise.ExerciseIndex.ToString();
        }

        protected void rptFoodDB_OnItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            if (!(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem))
                return;

            var food = e.Item.DataItem as Food;

            var ltlID = e.Item.FindControl("ltlID") as Literal;
            var ltlName = e.Item.FindControl("ltlName") as Literal;
            var ltlGlycemicIndex = e.Item.FindControl("ltlGlycemicIndex") as Literal;

            ltlID.Text = food.Id.ToString();
            ltlName.Text = food.Name.ToString();
            ltlGlycemicIndex.Text = food.GlycemicIndex.ToString();
        }

        protected void rptInput_OnItemDataBound(Object Sender, RepeaterItemEventArgs e)
        {
            if (!(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem))
                return;

            var input = e.Item.DataItem as Input;

            var ltlInputType = e.Item.FindControl("ltlInputType") as Literal;
            var ltlID = e.Item.FindControl("ltlID") as Literal;
            var ltlTimeStamp = e.Item.FindControl("ltlTimeStamp") as Literal;
            var ltlName = e.Item.FindControl("ltlName") as Literal;
            var ltlDateTime = e.Item.FindControl("ltlDateTime") as Literal;

            ltlInputType.Text = input.Type.ToString();
            ltlID.Text = input.Id.ToString();
            ltlTimeStamp.Text = input.TimeStamp.ToString();

            ltlName.Text = input.Type == InputType.Exercise ? ExerciseDictionary[input.Id].Name : FoodDictionary[input.Id].Name;
            ltlDateTime.Text = input.TimeStamp.ToDateTime().ToString(CultureInfo.InvariantCulture);
        }
    }
}