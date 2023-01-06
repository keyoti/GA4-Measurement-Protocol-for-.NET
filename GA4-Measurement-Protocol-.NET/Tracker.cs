using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Keyoti.GA4
{
    public class Tracker
    {
        [JsonProperty("client_id")]
        public string ClientId { get; }
        [JsonProperty("user_id")]
        public string UserId { get; set; }
        [JsonIgnore]
        public string MeasurementId { get; }
        [JsonIgnore]
        public string ApiSecret { get; }
        [JsonIgnore]
        public Dictionary<string, string> UserProperties { get; }

        const int MAXIMUM_EVENTS = 25;

        List<MeasurementEvent> queuedEvents = new List<MeasurementEvent>(MAXIMUM_EVENTS);
        [JsonProperty("events")]
        public List<MeasurementEvent> Events { get { return queuedEvents; } }

        HttpEventSender eventSender;

        public Tracker(string clientId, string userId, string measurementId, 
                        string apiSecret, Dictionary<string, string> userProperties)
        {
            ClientId = clientId;
            UserId = userId;
            MeasurementId = measurementId;
            ApiSecret = apiSecret;
            UserProperties = userProperties;
            eventSender = new HttpEventSender();
        }

        public async Task AddEventAsync(MeasurementEvent measurementEvent) 
        {
            if (queuedEvents.Count == MAXIMUM_EVENTS)
            {
                await SendEventsAsync();
            }
            Events.Add(measurementEvent);
        }

        public async Task<bool> SendEventsAsync()
        {
            JObject o = JObject.FromObject(this);
            //string payload = o.ToString();
            string payload = JsonConvert.SerializeObject(o, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            await eventSender.SendAsync(MeasurementId, ApiSecret, payload);
            Events.Clear();
            return true;
        }
    }
}
