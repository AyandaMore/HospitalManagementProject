using ARHospitalProject.Authorization.Users;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ARHospitalProject.Services.Notifications
{
    public class Notification
    { 
        

        public static void SendMessage(string cell, string msg)
        {
            //API keys
            string accountId = "AC7494c06b5792b7909fad50ec90dc4592";
            string authToken = "8cd5c6e38f65aa6500edd7b9ed75d081";

            TwilioClient.Init(accountId, authToken);//initialise the service in the code
            
            
            var message = MessageResource.Create(
                body: msg,
                from: new Twilio.Types.PhoneNumber("+19706959566"),
                to: new Twilio.Types.PhoneNumber(cell)
            );
        }
    }
}
