using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;

namespace ConsumoPHP
{
    internal class SoapAuthHeader
    {
        public static void Create(string username, string password)
        {
            string auth = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password));

            HttpRequestMessageProperty requestMessageProperty = new HttpRequestMessageProperty();

            requestMessageProperty.Headers.Add("Authorization", auth);

            OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = requestMessageProperty;
        }
    }
}