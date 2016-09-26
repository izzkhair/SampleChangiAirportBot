using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Dialogs;
using System.Collections.Generic;

namespace FirstBotApplication
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {

                
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                // calculate something for us to return



                if (activity.Text == "Show images of terminal 1")
                {
                    Activity replyToConversation = activity.CreateReply("Here are the images for Terminal 1");
                    replyToConversation.Recipient = activity.From;
                    replyToConversation.Type = "message";
                    replyToConversation.Attachments = new List<Attachment>();              
                    replyToConversation.Attachments.Add(new Attachment()
                    {
                        ContentUrl = "http://static.asiawebdirect.com/m/phuket/portals/www-singapore-com/homepage/practical-info/changi-airport/allParagraphs/01/image/changi-airport-departure-1200.jpg",
                        ContentType = "image/jpg",
                        Name = "Airport Internal Gates"
                    });
                    replyToConversation.Attachments.Add(new Attachment()
                    {
                        ContentUrl = "https://adlibmagazine.files.wordpress.com/2012/04/cag_fareast_t1_immigration_bulkhead_1_mar12-28_feb13.jpg",
                        ContentType = "image/jpg",
                        Name = "Arrival Immigration"
                    });
                    replyToConversation.Attachments.Add(new Attachment()
                    {
                        ContentUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSL2LR-gyOUTSHg06LP6NbOHwHyfJghY1crjsWYu8oKFQCH_AZYZA",
                        ContentType = "image/jpg",
                        Name = "Check-in Counter"
                    });
                    replyToConversation.Attachments.Add(new Attachment()
                    {
                        ContentUrl = "http://www.changiairport.com/content/dam/cag/5-airport-experience/3-services-facilities/kinetic_rain_900.jpg",
                        ContentType = "image/jpg",
                        Name = "Kinectic Rain"
                    });
                    replyToConversation.Attachments.Add(new Attachment()
                    {
                        ContentUrl = "http://www.straitstimes.com/sites/straitstimes.com/files/changiairport21e.jpg",
                        ContentType = "image/jpg",
                        Name = "Departure"
                    });
                    var replyall2 = await connector.Conversations.SendToConversationAsync(replyToConversation);
                }


            
                else
                {
                    int length = (activity.Text ?? string.Empty).Length;

                    // return our reply to the user
                    Activity reply = activity.CreateReply($"You sent {activity.Text} which was {length} characters");

                    await Conversation.SendAsync(activity, () => new AllTheBot());

                    if (AllTheBot.results == "BaggageStorage")
                    {

                        Activity replyToConversation = activity.CreateReply("If you would like to know more,");
                        replyToConversation.Recipient = activity.From;
                        replyToConversation.Type = "message";
                        replyToConversation.Attachments = new List<Attachment>();
                        List<CardImage> cardImages = new List<CardImage>();
                        cardImages.Add(new CardImage(url: "https://i.ytimg.com/vi/B4DyO5xWR1o/maxresdefault.jpg"));
                        cardImages.Add(new CardImage(url: "https://i.ytimg.com/vi/B4DyO5xWR1o/maxresdefault.jpg"));
                        List<CardAction> cardButtons = new List<CardAction>();
                        CardAction plButton = new CardAction()
                        {
                            Value = "http://www.changiairport.com/en/airport-experience/attractions-and-services/baggage-storage.html",
                            Type = "openUrl",
                            Title = "More Details"
                        };
                     
                        cardButtons.Add(plButton);
                
                        ThumbnailCard plCard = new ThumbnailCard()
                        {
                            Title = "Baggage Storage",
                            Subtitle = "",
                            Images = cardImages,
                            Buttons = cardButtons
                        };
                        Attachment plAttachment = plCard.ToAttachment();
                        replyToConversation.Attachments.Add(plAttachment);
                        var replyall = await connector.Conversations.SendToConversationAsync(replyToConversation);
                        AllTheBot.results = "";

                    }
                   else if (AllTheBot.results == "ParkingCharges")
                    {

                        Activity replyToConversation = activity.CreateReply("If you would like to know more,");
                        replyToConversation.Recipient = activity.From;
                        replyToConversation.Type = "message";
                        replyToConversation.Attachments = new List<Attachment>();
                        List<CardImage> cardImages = new List<CardImage>();
                        cardImages.Add(new CardImage(url: "http://www.changiairport.com/content/dam/cag/3-transports/3.0_transport-icon-big-7.png"));
                        cardImages.Add(new CardImage(url: "http://www.changiairport.com/content/dam/cag/3-transports/3.0_transport-icon-big-7.png"));
                        List<CardAction> cardButtons = new List<CardAction>();
                        CardAction plButton = new CardAction()
                        {
                            Value = "http://www.changiairport.com/en/transport/airport-parking.html",
                            Type = "openUrl",
                            Title = "View the parking charges"
                        };

                        cardButtons.Add(plButton);

                        ThumbnailCard plCard = new ThumbnailCard()
                        {
                            Title = "Parking Charges at Changi Airport",
                            Subtitle = "",
                            Images = cardImages,
                            Buttons = cardButtons
                        };
                        Attachment plAttachment = plCard.ToAttachment();
                        replyToConversation.Attachments.Add(plAttachment);
                        var replyall = await connector.Conversations.SendToConversationAsync(replyToConversation);
                        AllTheBot.results = "";

                    }
                    else if (AllTheBot.results == "MapTerminal1")
                    {

                        Activity replyToConversation = activity.CreateReply("If you would like to know more,");
                        replyToConversation.Recipient = activity.From;
                        replyToConversation.Type = "message";
                        replyToConversation.Attachments = new List<Attachment>();
                        List<CardImage> cardImages = new List<CardImage>();
                        cardImages.Add(new CardImage(url: "http://www.changiairport.com/content/dam/cag/5-airport-experience/5.0_experience-T1.png"));
                        List<CardAction> cardButtons = new List<CardAction>();
                        CardAction plButton = new CardAction()
                        {
                            Value = "http://www.changiairport.com/en/maps.html#map/T1L1/",
                            Type = "openUrl",
                            Title = "Terminal 1 Map"
                        };

                        cardButtons.Add(plButton);

                        ThumbnailCard plCard = new ThumbnailCard()
                        {
                            Title = "Map of terminal 1",
                            Subtitle = "",
                            Images = cardImages,
                            Buttons = cardButtons
                        };
                        Attachment plAttachment = plCard.ToAttachment();
                        replyToConversation.Attachments.Add(plAttachment);
                        var replyall = await connector.Conversations.SendToConversationAsync(replyToConversation);
                        AllTheBot.results = "";

                    }

                    else if (AllTheBot.results == "MapTerminal2")
                    {

                        Activity replyToConversation = activity.CreateReply("If you would like to know more,");
                        replyToConversation.Recipient = activity.From;
                        replyToConversation.Type = "message";
                        replyToConversation.Attachments = new List<Attachment>();
                        List<CardImage> cardImages = new List<CardImage>();
                        cardImages.Add(new CardImage(url: "http://www.changiairport.com/content/dam/cag/5-airport-experience/5.0_experience-T2.png"));
                        List<CardAction> cardButtons = new List<CardAction>();
                        CardAction plButton = new CardAction()
                        {
                            Value = "http://www.changiairport.com/en/maps.html#map/T2L1/",
                            Type = "openUrl",
                            Title = "Terminal 2 Map"
                        };

                        cardButtons.Add(plButton);

                        ThumbnailCard plCard = new ThumbnailCard()
                        {
                            Title = "Map of terminal 2",
                            Subtitle = "",
                            Images = cardImages,
                            Buttons = cardButtons
                        };
                        Attachment plAttachment = plCard.ToAttachment();
                        replyToConversation.Attachments.Add(plAttachment);
                        var replyall = await connector.Conversations.SendToConversationAsync(replyToConversation);
                        AllTheBot.results = "";

                    }

                    else if (AllTheBot.results == "MapTerminal3")
                    {
                        Activity replyToConversation = activity.CreateReply("If you would like to know more,");
                        replyToConversation.Recipient = activity.From;
                        replyToConversation.Type = "message";
                        replyToConversation.Attachments = new List<Attachment>();
                        List<CardImage> cardImages = new List<CardImage>();
                        cardImages.Add(new CardImage(url: "http://www.changiairport.com/content/dam/cag/5-airport-experience/5.0_experience-T3.png"));
                        List<CardAction> cardButtons = new List<CardAction>();
                        CardAction plButton = new CardAction()
                        {
                            Value = "http://www.changiairport.com/en/maps.html#map/T3L1/",
                            Type = "openUrl",
                            Title = "Terminal 3 Map"
                        };

                        cardButtons.Add(plButton);

                        ThumbnailCard plCard = new ThumbnailCard()
                        {
                            Title = "Map of terminal 3",
                            Subtitle = "",
                            Images = cardImages,
                            Buttons = cardButtons
                        };
                        Attachment plAttachment = plCard.ToAttachment();
                        replyToConversation.Attachments.Add(plAttachment);
                        var replyall = await connector.Conversations.SendToConversationAsync(replyToConversation);
                        AllTheBot.results = "";

                    }

                    else if (AllTheBot.results == "VisaTour")
                    {
                        Activity replyToConversation = activity.CreateReply("For More Information, Please Visit the ICA Website");
                        replyToConversation.Recipient = activity.From;
                        replyToConversation.Type = "message";
                        replyToConversation.Attachments = new List<Attachment>();
                        List<CardImage> cardImages = new List<CardImage>();
                        cardImages.Add(new CardImage(url: "https://upload.wikimedia.org/wikipedia/en/e/e2/Immigration_and_Checkpoints_Authority_logo.png"));
                        List<CardAction> cardButtons = new List<CardAction>();
                        CardAction plButton = new CardAction()
                        {
                            Value = "https://www.ica.gov.sg/",
                            Type = "openUrl",
                            Title = "ICA Website"
                        };

                        cardButtons.Add(plButton);

                        ThumbnailCard plCard = new ThumbnailCard()
                        {
                            Title = "Click to Visit ICA Website",
                            Subtitle = "",
                            Images = cardImages,
                            Buttons = cardButtons
                        };
                        Attachment plAttachment = plCard.ToAttachment();
                        replyToConversation.Attachments.Add(plAttachment);
                        var replyall = await connector.Conversations.SendToConversationAsync(replyToConversation);
                        AllTheBot.results = "";

                    }
                    else if (AllTheBot.results == "ImagesTerminal1")
                    {
                        Activity replyToConversation = activity.CreateReply("Here are the images for Terminal 1");
                        replyToConversation.Recipient = activity.From;
                        replyToConversation.Type = "message";
                        replyToConversation.Attachments = new List<Attachment>();
                        replyToConversation.Attachments.Add(new Attachment()
                        {
                            ContentUrl = "http://static.asiawebdirect.com/m/phuket/portals/www-singapore-com/homepage/practical-info/changi-airport/allParagraphs/01/image/changi-airport-departure-1200.jpg",
                            ContentType = "image/jpg",
                            Name = "Airport Internal Gates"
                        });
                        replyToConversation.Attachments.Add(new Attachment()
                        {
                            ContentUrl = "https://adlibmagazine.files.wordpress.com/2012/04/cag_fareast_t1_immigration_bulkhead_1_mar12-28_feb13.jpg",
                            ContentType = "image/jpg",
                            Name = "Arrival Immigration"
                        });
                        replyToConversation.Attachments.Add(new Attachment()
                        {
                            ContentUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSL2LR-gyOUTSHg06LP6NbOHwHyfJghY1crjsWYu8oKFQCH_AZYZA",
                            ContentType = "image/jpg",
                            Name = "Check-in Counter"
                        });
                        replyToConversation.Attachments.Add(new Attachment()
                        {
                            ContentUrl = "http://www.changiairport.com/content/dam/cag/5-airport-experience/3-services-facilities/kinetic_rain_900.jpg",
                            ContentType = "image/jpg",
                            Name = "Kinectic Rain"
                        });
                        replyToConversation.Attachments.Add(new Attachment()
                        {
                            ContentUrl = "http://www.straitstimes.com/sites/straitstimes.com/files/changiairport21e.jpg",
                            ContentType = "image/jpg",
                            Name = "Departure"
                        });
                        var replyall2 = await connector.Conversations.SendToConversationAsync(replyToConversation);
                        AllTheBot.results = "";
                    }
                    else if (AllTheBot.results == "ImagesTerminal2")
                    {
                        Activity replyToConversation = activity.CreateReply("Here are the images for Terminal 2");
                        replyToConversation.Recipient = activity.From;
                        replyToConversation.Type = "message";
                        replyToConversation.Attachments = new List<Attachment>();
                        replyToConversation.Attachments.Add(new Attachment()
                        {
                            ContentUrl = "http://www.bca.gov.sg/data/imgCont/building/changi%20airport%20T2%20land.JPG",
                            ContentType = "image/jpg",
                            Name = "Depature Drop-Off Point"
                        });
                        replyToConversation.Attachments.Add(new Attachment()
                        {
                            ContentUrl = "http://www.changiairport.com/content/dam/cag/5-airport-experience/3-services-facilities/shillabeautylounge/xshilla-content-pod2.jpg.pagespeed.ic.JrSo3kysX6.jpg",
                            ContentType = "image/jpg",
                            Name = "Airport Internal Shops"
                        });
                        replyToConversation.Attachments.Add(new Attachment()
                        {
                            ContentUrl = "http://www.yoursingapore.com/travel-guide-tips/travelling-to-singapore/changi-airport-singapore/_jcr_content/par-carousel/carousel_detailpage/carousel/item_1.thumbnail.carousel-img.740.416.jpg",
                            ContentType = "image/jpg",
                            Name = "External Structure"
                        });
                        replyToConversation.Attachments.Add(new Attachment()
                        {
                            ContentUrl = "https://s.yimg.com/bt/api/res/1.2/g.bBN_Lb6ocv2qbTkE03ZQ--/YXBwaWQ9eW5ld3NfbGVnbztjaD00MDA7Y3I9MTtjdz02MzA7ZHg9MDtkeT0wO2ZpPXVsY3JvcDtoPTQwMDtpbD1wbGFuZTtxPTc1O3c9NjMw/http://l.yimg.com/os/publish-images/news/2014-02-14/61568060-952e-11e3-bc6e-b9fcd59c442b_630GETTY_changiairportT2.jpg",
                            ContentType = "image/jpg",
                            Name = "Departure Counters"
                        });
                        replyToConversation.Attachments.Add(new Attachment()
                        {
                            ContentUrl = "https://i.ytimg.com/vi/agIdoFW0Sb4/maxresdefault.jpg",
                            ContentType = "image/jpg",
                            Name = "Arrival Immigration"
                        });
                        var replyall2 = await connector.Conversations.SendToConversationAsync(replyToConversation);
                        AllTheBot.results = "";
                    }

                    else if (AllTheBot.results == "ImagesTerminal3")
                    {
                        Activity replyToConversation = activity.CreateReply("Here are the images for Terminal 3");
                        replyToConversation.Recipient = activity.From;
                        replyToConversation.Type = "message";
                        replyToConversation.Attachments = new List<Attachment>();
                        replyToConversation.Attachments.Add(new Attachment()
                        {
                            ContentUrl = "http://www.cpgcorp.com.sg/CPGC/Content/Projects/1122/ChangiT3_06.jpg",
                            ContentType = "image/jpg",
                            Name = "Airport Internal"
                        });
                        replyToConversation.Attachments.Add(new Attachment()
                        {
                            ContentUrl = "http://www.filasolutions.com/assets/images/fotogallery/Terminal%203%20Changi%20Internation%20Airport2.jpg",
                            ContentType = "image/jpg",
                            Name = "Departure Entrance"
                        });
                        replyToConversation.Attachments.Add(new Attachment()
                        {
                            ContentUrl = "http://1.bp.blogspot.com/-HCWjXUWS1g8/Vn5H8K4Ac7I/AAAAAAABCkY/IFe7Ymo_uxA/s1600/DSCN9214.JPG",
                            ContentType = "image/jpg",
                            Name = "Departure Drop-Off"
                        });
                        replyToConversation.Attachments.Add(new Attachment()
                        {
                            ContentUrl = "http://www.greenroofs.com/projects/changi_terminal3_greenwall/changi_terminal3_greenwall7.jpg",
                            ContentType = "image/jpg",
                            Name = "Architechtural Design"
                        });
                        replyToConversation.Attachments.Add(new Attachment()
                        {
                            ContentUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRnSikBMnm6bhwWiVK5ALzLnLD0MXTZrr27a9fO9efXVM-OT9LNQg",
                            ContentType = "image/jpg",
                            Name = "Shops"
                        });
                        var replyall2 = await connector.Conversations.SendToConversationAsync(replyToConversation);
                        AllTheBot.results = "";
                    }
                    else if (AllTheBot.results == "HotelNearAirport")
                    {

                        Activity replyToConversation = activity.CreateReply("If you would like to know more,");
                        replyToConversation.Recipient = activity.From;
                        replyToConversation.Type = "message";
                        replyToConversation.Attachments = new List<Attachment>();
                        List<CardImage> cardImages = new List<CardImage>();
                        cardImages.Add(new CardImage(url: "https://d30y9cdsu7xlg0.cloudfront.net/png/4398-200.png"));
                        List<CardAction> cardButtons = new List<CardAction>();
                        CardAction plButton = new CardAction()
                        {
                            Value = "http://www.changiairport.com/en/airport-experience/attractions-and-services/transit-hotels.html",
                            Type = "openUrl",
                            Title = "Transit Hotels"
                        };

                        cardButtons.Add(plButton);

                        ThumbnailCard plCard = new ThumbnailCard()
                        {
                            Title = "Transit Hotels Details",
                            Subtitle = "For Transit Passengers",
                            Images = cardImages,
                            Buttons = cardButtons
                        };
                        Attachment plAttachment = plCard.ToAttachment();
                        replyToConversation.Attachments.Add(plAttachment);
                        var replyall = await connector.Conversations.SendToConversationAsync(replyToConversation);
                        AllTheBot.results = "";

                    }

                    else if (AllTheBot.results == "AllFlightInfo")
                    {

                        Activity replyToConversation = activity.CreateReply("If you would like to know more,");
                        replyToConversation.Recipient = activity.From;
                        replyToConversation.Type = "message";
                        replyToConversation.Attachments = new List<Attachment>();
                        List<CardImage> cardImages = new List<CardImage>();
                        cardImages.Add(new CardImage(url: "http://www.manchesterairportarrivals.com/wp-content/uploads/2012/09/fidepartures.png"));
                        List<CardAction> cardButtons = new List<CardAction>();
                        CardAction plButton = new CardAction()
                        {
                            Value = "http://www.changiairport.com/en/flight/departures.html",
                            Type = "openUrl",
                            Title = "All Flights"
                        };

                        cardButtons.Add(plButton);

                        ThumbnailCard plCard = new ThumbnailCard()
                        {
                            Title = "View All Flight Departure",
                            Subtitle = "",
                            Images = cardImages,
                            Buttons = cardButtons
                        };
                        Attachment plAttachment = plCard.ToAttachment();
                        replyToConversation.Attachments.Add(plAttachment);
                        var replyall = await connector.Conversations.SendToConversationAsync(replyToConversation);
                        AllTheBot.results = "";

                    }
                    else
                    {

                    }
                }
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}