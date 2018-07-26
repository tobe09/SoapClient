using NameInquiryTest.IntegrationService;
using Newtonsoft.Json.Linq;
using System;

namespace NameInquiryTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IntegrationSoap port = new IntegrationSoapClient();         //port needed for transaction with soap web service

            nameInquiryRequestData requestData = new nameInquiryRequestData    //encapsulates request data
            {
                accountNumber = "1000111111",
                channelCode = "9"
            };
            nameInquirySubmitRequest requestObj = new nameInquirySubmitRequest(requestData);  //proxy object for passing request

            nameInquirySubmitResponse responseObj = port.nameInquirySubmit(requestObj);        //proxy object holding response

            neSingleResponse responseData = responseObj.@return;                    //response data from soap web service

            JObject responseJson = JObject.FromObject(responseData);                //formatting response data to json object
                
            Console.WriteLine(responseJson);                                        //display response data as json string

            Console.WriteLine("Response code: "+responseData.responseCode);         //display only response code

            Console.ReadKey();      //wait for key press before dismiss
        }
    }
}
