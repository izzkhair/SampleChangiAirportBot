using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FirstBotApplication
{
    [LuisModel("Please Enter Your LUIS Model ID", "Please Enter Your LUIS Subscription Key")]
    [Serializable]
    public class AllTheBot:LuisDialog<object>
    {
       
        public static string results="";
        [LuisIntent("BaggageStorage")]
        public async Task BaggageStorage(IDialogContext context, LuisResult result)
        {
            await context.PostAsync
            ("Yes, you can leave your baggage at the Left Baggage counters located in all terminals. This service is available 24 hours daily at:"
            + Environment.NewLine + "\n\n Terminal 1" +Environment.NewLine + " - Departure Transit Lounge West, Level 2" + Environment.NewLine + " - Level 3, Public Area"
            + Environment.NewLine + "\n\n Terminal 2" +Environment.NewLine + " - Departure Transit Lounge Central, Level 2" + Environment.NewLine + " - Arrival Hall North, Level 1, Public Area"
            + Environment.NewLine + "\n\n Terminal 3" + Environment.NewLine + " - Departure Transit Lounge North, Level 2" + Environment.NewLine + " - Departure Transit Lounge North, Level 2"
        

            );

            context.Wait(MessageReceived);
            results = "BaggageStorage";    
        }

        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Sorry I can't seem to understand your question. \n\n Please ask another one.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("FlightInformation")]
        public async Task FlightInformation(IDialogContext context, LuisResult result)
        {
            if (result.Entities[0].Entity != null)
            {
                
                String flightNo = result.Entities[0].Entity;
                getflights newgetflights = new getflights();
                Carrier carrierresults = newgetflights.findFlight(flightNo);
                if (carrierresults != null)
                {
                    String schleduletime = carrierresults.scheduledTime.ToString();
                    String terminal = carrierresults.terminal.ToString();
                    await context.PostAsync("Your Schleduled Flight time for flight " + flightNo.ToUpper() + " is " + schleduletime + " at Terminal " + terminal);
                    context.Wait(MessageReceived);
                    results = "AllFlightInfo";
                }
                else
                {
                    await context.PostAsync("Please try again and specify the main Flight Number");
                    context.Wait(MessageReceived);
                }
                
            }
            else
            {
                await context.PostAsync("Please try again and specify your flight number");
                context.Wait(MessageReceived);
            }
        }

        [LuisIntent("RestrictionsOfItem")]
        public async Task RestrictionsOfItem(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("The following is a list of items that you cannot bring on board: "
                + Environment.NewLine + " - Explosives including fireworks, flares, toy gun caps"
                + Environment.NewLine + " - Gases including compressed gas cylinders, tear gas, mace, pepper sprays, household aerosols Flammable materials including petrol, lighter fuel, paint, thinners, non-safety matches, fire lighters, flammable glue "
                + Environment.NewLine + " - Poisons including weed killers, pesticides, insecticides"
                + Environment.NewLine + " - Firearms of any type including replicas or toys"
                + Environment.NewLine + " - Corrosive substances including batteries, mercury, drain cleaners"
                 + Environment.NewLine + " - Other dangerous goods such as magnetised or radioactive material, toxic or infectious substances like laboratory diagnostic samples"
);
            context.Wait(MessageReceived);
        }

        [LuisIntent("SingaporeTour")]
        public async Task SingaporeTour(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Certain conditions apply subject to entry visa requirements stipulated by the Immigration & Checkpoints Authority.");
            context.Wait(MessageReceived);
            results = "VisaTour";
        }


        [LuisIntent("EnterSingapore")]
        public async Task EnterSingapore(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Yes, you are allowed to enter Singapore during your transit as long as you have the valid travel documents (passport, visa etc). Passengers are advised to find out the transfer details from their airline(s) before embarking on their journeys. Most passengers who are arriving on or connecting to budget airlines are required to seek immigration clearance and obtain their onward boarding passes in the respective Departure Check-in Hall. \n\n You may visit the https://www.ica.gov.sg/ for further information on entry requirements into Singapore.");
            context.Wait(MessageReceived);
        }


        [LuisIntent("CheckAirline")]
        public async Task CheckAirline(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Visit the link to get airline contact details: http://www.changiairport.com/en/flight/airlines.html ");
            context.Wait(MessageReceived);
        }


        [LuisIntent("GoOtherTerminal")]
        public async Task GoOtherTerminal(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("You can make your way between Terminals 1, 2 & 3 via either the Skytrain or travellators within the transit area. \n\nThe Skytrain runs from 5.00am to 2.30am (including Sundays and Public Holidays). \n\nIf the Skytrain is out of service, you can use the travellators. \n\n You can find Skytrain and travellator locations on our Inter-Terminal Transfer Map. \n\nIf you are connecting to Tiger Airways, Cebu Pacific Air or Firefly, you must clear Customs and Immigration to check-in at the Terminal 2. \n\n http://www.changiairport.com/en/transport/transfer-between-terminals.html");
            context.Wait(MessageReceived);
        }


        [LuisIntent("LostBelonging")]
        public async Task LostBelonging(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("For items lost at the Public or Transit area: \n\n Please approach any of our Information Counters. Our Customer Service Officers will be glad to assist you on your enquiry. Alternatively, you may call our Changi Contact Centre at (65) 6595 6868."
                + Environment.NewLine+ "\n\n For items lost in an aircraft: \n\n Please approach the respective airline or the ground handling agent (Dnata, SATS or ASIG) to check the status of your item."
                + Environment.NewLine+ "\n\n - Terminal 1: \n\n DNATA Singapore(65) 6511 0459 \n\n SATS(65) 6597 4500 \n\n ASIG 800 852 3632 "
                + Environment.NewLine + "\n\n - Terminal 2: \n\n DNATA Singapore (65) 6511 0459 \n\n SATS for Singapore Airlines 1800 2244 243(when calling within Singapore ONLY), \n\n (65) 6224 4243(for calling from outside Singapore) ; \n\n for other airlines (65) 6597 4500"
                + Environment.NewLine + "\n\n - Terminal 3: \n\n Dnata Singapore (65) 6247 5714  \n\n ATS for Singapore Airlines 1800 2244 243 (when calling within Singapore ONLY), \n\n (65) 6224 4243 (for calling from outside Singapore); \n\n for other airlines (65) 6597 4500"
                );
            context.Wait(MessageReceived);
        }


        [LuisIntent("HotelAirport")]
        public async Task HotelAirport(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Yes, we do. You can visit our transit hotel which is located on the 3rd level of the Departure transit areas in Terminals 1, 2 and 3. Our transit hotels are located at:"
                +Environment.NewLine+ "\n\n - Terminal 1 \n\n Near the Airline Lounge at Departure Transit Lounge East, Level 3."
                + Environment.NewLine + "\n\n - Terminal 2 \n\n Near The Ambassador Transit Lounge at Departure Transit Lounge South, Level 3."
                +Environment.NewLine+ "\n\n - Terminal 3 \n\n Near The Ambassador Transit Lounge at Departure Transit Lounge North, Level 3. "
                );
            context.Wait(MessageReceived);
            results = "HotelNearAirport";
        }


        [LuisIntent("BreastMilk")]
        public async Task BreastMilk(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("If your baby is not travelling with you, we would strongly advise you to store the expressed breast milk into containers not exceeding 100ml. The containers must fit comfortably in a 1-litre resealable plastic bag. The personal LAGs items will be discarded if it is not within the permissible capacity. Nonetheless, these personal LAGs items will be subjected to additional checks at the Pre-Board Security Screening Aea, prior to boarding the aircraft.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("ParkingCharges")]
        public async Task ParkingCharges(IDialogContext context, LuisResult result)
        {

            await context.PostAsync("The prevailing parking charges are listed below:"
                +Environment.NewLine+ "\n\n Main Terminal Car Parks " + Environment.NewLine+"\n\n - Motor cars, including vans - Charges Are S$0.04 per min \n\n - Motorcycles and scooters - Charges are S$1.30 per day"
                + Environment.NewLine + "\n\n New South Car Park(open space car park between Terminal 2 and JetQuay) " + Environment.NewLine + "\n\n - Motor cars, including vans - S$0.035 per min (capped at S$35 per 24 hours)"
                );
            context.Wait(MessageReceived);
            results = "ParkingCharges";



        }


        [LuisIntent("MapTerminal")]
        public async Task MapTerminal(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Visit the Link Below for map of " + result.Entities[0].Entity);
            context.Wait(MessageReceived);
            results = "ParkingCharges";

            if (result.Entities[0].Entity=="terminal 1")
            {
                results = "MapTerminal1";
            }
            else if (result.Entities[0].Entity == "terminal 2")
            {
                results = "MapTerminal2";
            }

            else if (result.Entities[0].Entity == "terminal 3")
            {
                results = "MapTerminal3";
            }

          
        }

        [LuisIntent("ImagesTerminal")]
        public async Task ImagesTerminal(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Here you go. Photos of " + result.Entities[0].Entity);
            context.Wait(MessageReceived);


            if (result.Entities[0].Entity == "terminal 1")
            {
                results = "ImagesTerminal1";
            }
            else if (result.Entities[0].Entity == "terminal 2")
            {
                results = "ImagesTerminal2";
            }

            else if (result.Entities[0].Entity == "terminal 3")
            {
                results = "ImagesTerminal3";
            }
        }


        }
}