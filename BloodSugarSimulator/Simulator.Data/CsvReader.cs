using BloodSugarSimulator.Simulator.Type;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BloodSugarSimulator.Simulator.Data
{
    public class CsvReader
    {
        public List<Input> GetInputList()
        {
            CsvParser parser = new CsvParser();
            string inputFileLocation = ConfigurationManager.AppSettings["inputFileLocation"];
            var list = parser.ReadFile(inputFileLocation);

            var listout = new List<Input>();
            for (int i = 1; i < list.Count; i++)
            {
                var cols = list[i];
                InputType inputType = (InputType)Enum.Parse(typeof(InputType), (cols[0]));
                int id = Convert.ToInt32(cols[1]);
                long timeStamp = Convert.ToInt64(cols[2]);
                listout.Add(new Input(inputType, id, timeStamp));
            }

            return listout;
        }

        public Dictionary<int, Food> GetFoodDictionary()
        {
            CsvParser parser = new CsvParser();
            string foodDbFileLocation = ConfigurationManager.AppSettings["foodDbFileLocation"];
            var list = parser.ReadFile(foodDbFileLocation);

            var dict = new Dictionary<int, Food>();
            for (int i = 1; i < list.Count; i++)
            {
                var cols = list[i];
                int id = Convert.ToInt32(cols[0]);
                string name = cols[1];
                int glycemicIndex = Convert.ToInt32(cols[2]);
                dict[id] = new Food(id, name, glycemicIndex);
            }

            return dict;
        }

        public Dictionary<int, Exercise> GetExerciseDictionary()
        {
            CsvParser parser = new CsvParser();
            string exerciseDbFileLocation = ConfigurationManager.AppSettings["exerciseDbFileLocation"];
            var list = parser.ReadFile(exerciseDbFileLocation);

            var dict = new Dictionary<int, Exercise>();
            for (int i = 1; i < list.Count; i++)
            {
                var cols = list[i];
                int id = Convert.ToInt32(cols[0]);
                string name = cols[1];
                int exerciseIndex = Convert.ToInt32(cols[2]);
                dict[id] = new Exercise(id, name, exerciseIndex);
            }

            return dict;
        }
    }
}