using BloodSugarSimulator.Simulator.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodSugarSimulator.Simulator.Business
{
    public class GlycationCalculator
    {
        const int THRESHOLD = 150;

        /// <summary>
        /// Get glycation histograms for bloodSugars
        /// </summary>
        /// <param name="bloodSugars"></param>
        /// <returns></returns>
        public List<List<Glycation>> GetGlycation(List<List<BloodSugar>> bloodSugars)
        {
            List<List<Glycation>> glycations = new List<List<Glycation>>();
            foreach (var bloodSugar in bloodSugars)
            {
                glycations.Add(GetGlycationPerDay(bloodSugar));
            }
            return glycations;
        }

        /// <summary>
        /// Get glycation histogram for one day
        /// </summary>
        /// <param name="bloodSugars"></param>
        /// <returns></returns>
        public List<Glycation> GetGlycationPerDay(List<BloodSugar> bloodSugars)
        {
            int glycation = 0;
            List<Glycation> glycations = new List<Glycation>();
            foreach (var bloodSugar in bloodSugars)
            {
                if (bloodSugar.Level > THRESHOLD)
                {
                    glycation++;
                }
                glycations.Add(new Glycation(glycation, bloodSugar.Timestamp));
            }
            return glycations;
        }
    }
}