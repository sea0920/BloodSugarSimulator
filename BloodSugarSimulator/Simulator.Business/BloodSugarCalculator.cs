using BloodSugarSimulator.Simulator.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodSugarSimulator.Simulator.Business
{
    public class BloodSugarCalculator
    {
        const int DEFAULT_BLOOD_SUGAR = 80;
        const int MICROSECONDS_PER_DAY = 24 * 60 * 60 * 1000;
        const int MICROSECONDS_PER_HOUR = 60 * 60 * 1000;
        const int MICROSECONDS_PER_MINUTE = 60 * 1000;

        Dictionary<int, Exercise> ExerciseDictionary { get; set; }
        Dictionary<int, Food> FoodDictionary { get; set; }

        public BloodSugarCalculator(Dictionary<int, Exercise> exerciseDictionary, Dictionary<int, Food> foodDictionary)
        {
            ExerciseDictionary = exerciseDictionary;
            FoodDictionary = foodDictionary;
        }

        /// <summary>
        /// Get blood sugar histograms for days which has one or more input.
        /// </summary>
        /// <param name="inputs">list of exercise and food</param>
        /// <returns></returns>
        public List<List<BloodSugar>> GetBloodSugar(List<Input> inputs)
        {
            RangeCalculator rangeCalculator = new RangeCalculator();
            long start = rangeCalculator.GetStartDateTimeStamp(inputs);
            long end = rangeCalculator.GetEndDateTimeStamp(inputs);

            List<List<BloodSugar>> bloodSugars = new List<List<BloodSugar>>();
            for (long i = start; i < end; i += MICROSECONDS_PER_DAY)
            {
                List<Input> currentInputs = inputs.Where(o => o.TimeStamp >= i && o.TimeStamp < i + MICROSECONDS_PER_DAY).ToList();
                if (currentInputs.Count == 0)
                    continue;
                List<BloodSugar> bloodSugar = GetBloodSugarPerDay(currentInputs, i, i + MICROSECONDS_PER_DAY);
                bloodSugars.Add(bloodSugar);
            }

            return bloodSugars;
        }

        /// <summary>
        /// Get blood sugar histogram for one day
        /// </summary>
        /// <param name="inputs">list of exercise and food</param>
        /// <param name="start">Start of the day. Inclusive</param>
        /// <param name="end">End of the day. Exclusive. This is actually the next day.</param>
        /// <returns></returns>
        public List<BloodSugar> GetBloodSugarPerDay(List<Input> inputs, long start, long end)
        {
            decimal bloodSugar = DEFAULT_BLOOD_SUGAR;
            List<BloodSugar> res = new List<BloodSugar>();
            for (long i = start; i < end; i += MICROSECONDS_PER_MINUTE)
            {
                bool isAffected = false;
                foreach (var exercise in inputs.Where(o => o.Type == InputType.Exercise && o.TimeStamp <= i && o.TimeStamp >= i - MICROSECONDS_PER_HOUR))
                {
                    bloodSugar -= (decimal)ExerciseDictionary[exercise.Id].ExerciseIndex / 60;
                    isAffected = true;
                }

                foreach (var food in inputs.Where(o => o.Type == InputType.Food && o.TimeStamp <= i && o.TimeStamp >= i - 2 * MICROSECONDS_PER_HOUR))
                {
                    bloodSugar += (decimal)FoodDictionary[food.Id].GlycemicIndex / (2 * 60);
                    isAffected = true;
                }

                if (!isAffected)
                {
                    if (Math.Abs(bloodSugar - DEFAULT_BLOOD_SUGAR) < 1)
                        bloodSugar = DEFAULT_BLOOD_SUGAR;
                    else if (bloodSugar > DEFAULT_BLOOD_SUGAR)
                        bloodSugar--;
                    else if (bloodSugar < DEFAULT_BLOOD_SUGAR)
                        bloodSugar++;
                }

                res.Add(new BloodSugar(bloodSugar, i));
            }

            return res;
        }
    }
}