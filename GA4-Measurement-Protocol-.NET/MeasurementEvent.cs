using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Keyoti.GA4
{
    public class MeasurementEvent
    {
        [JsonProperty("name")]
        public string Name { get; }

        //[JsonProperty("engagement_time_msec")]
        [JsonIgnore]
        public int EngagementTimeMSec { get; }
        //[JsonProperty("session_id")]
        [JsonIgnore]
        public string SessionId { get; }
        [JsonProperty("params")]
        public Dictionary<string, dynamic> Parameters { get => parameters; }
        
        Dictionary<string, dynamic> parameters = new Dictionary<string, dynamic>();
        

        //Unsure how to actually implement this in json payload
        //List<MeasurementUserProperty> userProperties = new List<MeasurementUserProperty>(25);
        private readonly int MAXIMUM_PARAMETERS = 25;
        private readonly int MAXIMUM_NAME_LENGTH = 40;

        public MeasurementEvent(string name) : this(name, 1, "1")
        {
        }

        public MeasurementEvent(string name, int engagementTimeMSec, string sessionId)
        {
            if (name.Length > MAXIMUM_NAME_LENGTH)
            {
                throw new ApplicationException($"Event name {name} is too long, maximum length per GA4 protocol is {MAXIMUM_NAME_LENGTH}.");
            }
            Name = name;
            EngagementTimeMSec = engagementTimeMSec;
            SessionId = sessionId;

            //If these are not added then the event will not appear in reports
            AddParameter("engagement_time_msec", engagementTimeMSec);
            AddParameter("session_id", sessionId);
        }

        public void AddParameter(string name, string value)
        {
            if (Parameters.Count > MAXIMUM_PARAMETERS)
            {
                throw new ApplicationException($"Too many parameters added to event, maximum number per GA4 protocol is {MAXIMUM_PARAMETERS}.");
            }
            Parameters.Add(name, value);
        }

        public void AddParameter(string name, int value)
        {
            if (Parameters.Count > MAXIMUM_PARAMETERS)
            {
                throw new ApplicationException($"Too many parameters added to event, maximum number per GA4 protocol is {MAXIMUM_PARAMETERS}.");
            }
            Parameters.Add(name, value);
        }

        public void AddParameter(string name, decimal value)
        {
            if (Parameters.Count > MAXIMUM_PARAMETERS)
            {
                throw new ApplicationException($"Too many parameters added to event, maximum number per GA4 protocol is {MAXIMUM_PARAMETERS}.");
            }
            Parameters.Add(name, value);
        }

        public void AddParameterItem(ParameterItem parameterItem)
        {
            List<ParameterItem> items;
            if (!Parameters.ContainsKey("items"))
            {
                items = new List<ParameterItem>();
                Parameters["items"] = items;
            }
            items = Parameters["items"];
            items.Add(parameterItem);
        }

    }
}