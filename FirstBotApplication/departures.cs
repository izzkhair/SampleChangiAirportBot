using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace FirstBotApplication
{
    public class getflights
    {
        public Carrier findFlight(String flightNumber)
        {
            WebClient wc = new WebClient();
            wc.Headers["User-Agent"] = "Mozilla/5.0 (iPhone; U; CPU iPhone OS 5_1_1 like Mac OS X; en) AppleWebKit/534.46.0 (KHTML, like Gecko) CriOS/19.0.1084.60 Mobile/9B206 Safari/7534.48.3";
            String raw = wc.DownloadString("http://www.changiairport.com/cag-web/flights/departures?date=today&lang=en_US&callback=JSON_CALLBACK");
            Departures tmp = Newtonsoft.Json.JsonConvert.DeserializeObject<Departures>(raw);
            return tmp.carriers.Find(x => x.flightNo.ToLower() == flightNumber.ToLower());
        }

    }

 

    public class Carrier
    {
        public string airportCode { get; set; }
        public string airlineCode { get; set; }
        public string airlineDesc { get; set; }
        public string scheduledTime { get; set; }
        public string estimatedTime { get; set; }
        public string flightNo { get; set; }
        public string terminal { get; set; }
        public string status { get; set; }
        public string statusCode { get; set; }
        public List<object> via { get; set; }
        public List<object> slaves { get; set; }
        public string estimatedDate { get; set; }
        public string scheduledDatetime { get; set; }
        public bool estimationDateFlag { get; set; }
        public bool estimationTimeFlag { get; set; }
        public bool terminalFlag { get; set; }
        public string scheduledTimeRange { get; set; }
        public string estimatedTimeRange { get; set; }
        public string to { get; set; }
        public string checkInRow { get; set; }
        public string gate { get; set; }
        public bool differentGate { get; set; }
    }


    public class Departures
    {
        public bool success { get; set; }
        public object errorCode { get; set; }
        public string dateTime { get; set; }
        public List<Carrier> carriers { get; set; }
    }

}