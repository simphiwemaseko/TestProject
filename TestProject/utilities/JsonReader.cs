using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Driver_Automation_Assessment.utilities
{
    public class JsonReader
    {
        public JsonReader()
        {
        }

        public string extractData(String tokenName)
        {

            var myJsonString = File.ReadAllText("testdata/testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<string>();

        }

        public string[] extractDataArray(String tokenName)
        {

            var myJsonString = File.ReadAllText("testdata/testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            List<String> jobList = jsonObject.SelectTokens(tokenName).Values<string>().ToList();
            return jobList.ToArray();

        }


    }
}
