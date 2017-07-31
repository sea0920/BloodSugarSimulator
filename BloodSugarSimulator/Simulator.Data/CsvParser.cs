using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace BloodSugarSimulator.Simulator.Data
{
    public class CsvParser
    {
        public List<List<string>> ReadFile(string filename)
        {
            List<List<string>> listout = new List<List<string>>();
            using (var reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = ParseLine(line);

                    listout.Add(values);
                }
            }

            return listout;
        }

        private List<string> ParseLine(string s)
        {
            List<string> result = new List<string>();
            if (s == null || s.Length == 0)
            {
                return result;
            }

            StringBuilder sb = new StringBuilder();
            bool inQuote = false;
            for (int i = 0; i < s.Length; i++)
            {
                if (inQuote)
                {
                    if (s[i] == '"')
                    {
                        if (i == s.Length - 1)
                        {
                            result.Add(sb.ToString().Trim());
                            return result;
                        }
                        else if (s[i + 1] == '"')
                        {
                            sb.Append('"');
                            i++;
                        }
                        else
                        {
                            result.Add(sb.ToString().Trim());
                            sb = new StringBuilder();
                            inQuote = false;
                            i++;
                        }
                    }
                    else
                    {
                        sb.Append(s[i]);
                    }
                }
                else
                {
                    if (s[i] == '"')
                    {
                        inQuote = true;
                    }
                    else if (s[i] == ',')
                    {

                        result.Add(sb.ToString());
                        sb = new StringBuilder();
                    }
                    else
                    {
                        sb.Append(s[i]);
                    }
                }
            }

            if (sb.Length > 0)
            {
                result.Add(sb.ToString().Trim());
            }

            return result;
        }
    }
}