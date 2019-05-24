using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
    public class ParserXML
    {
        //Use: Converts a MiniSQL query of the client to a XML sentence to pass it
        //to the server
        public static string QuerytoQueryXML (string query)
        {
            return "<Query>" + query + "</Query>";
        }

        //Use: Translates the received XML to a MiniSQL Query
        //to run the query in the server
        public static string QueryXMLtoQuery(string XML)
        {
            string regExp = "<Query>(.*)</Query>";
            Match match = Regex.Match(XML, regExp);
            return match.Groups[1].Value;
        }

        //Use: After running the query, transforms the received data to XML
        //to send it to the client
        public static string Data2XML(Table table)
        {

            string answer = "<Answer>";

            answer += "{";
            for (int i = 0; i<table.Columns.Count; i++)
            {                
                answer += table.Columns[i].Name;               
            }
            answer += "}";

            int numTuples = table.Columns[0].GetNumValues();
            answer += "{";
            for (int tuple = 0; tuple < numTuples; tuple++)
            {
                for (int i = 1; i < table.Columns.Count; i++) answer += "," + table.Columns[i].GetValueAsString(tuple).Trim('\'');
            }
            answer += "}";
            answer += "</Answer>";

            return answer;
        }

        //Use: The client translates the XML to get the final result of the query
        public static string DataXML2Data(String XML)
        {

            string regExp = "<Answer>(.*)</Answer";
            Match match = Regex.Match(XML, regExp);
            return match.Groups[1].Value;            
        }

        public static string AddAnswer(string pData)
        {
            string res = "<Answer>";
            res += pData;
            res += "</Answer>";
            return res;
        }
    }
}
