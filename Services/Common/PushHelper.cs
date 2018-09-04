using PushSharp;
using PushSharp.Android;
using PushSharp.Apple;
using PushSharp.Core;
using PushSharp.WindowsPhone;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for PushHelper
/// </summary>
namespace PurcellComplianceServices.Common
{
    public class PushHelper : IDisposable
    {
        private PushBroker m_broker;

        public PushHelper()
        {
            InitializeBroker();
        }
        private void InitializeBroker()
        {
            m_broker = new PushBroker();

            //Wire up the events for all the services that the broker registers
            m_broker.OnNotificationSent += NotificationSent;
            m_broker.OnChannelException += ChannelException;
            m_broker.OnServiceException += ServiceException;
            m_broker.OnNotificationFailed += NotificationFailed;
            m_broker.OnDeviceSubscriptionExpired += DeviceSubscriptionExpired;
            m_broker.OnDeviceSubscriptionChanged += DeviceSubscriptionChanged;
            m_broker.OnChannelCreated += ChannelCreated;
            m_broker.OnChannelDestroyed += ChannelDestroyed;

            RegisterAndroidServices();

        }

        private void RegisterAndroidServices()
        {
            string googleConsoleAPIAccessKey = ConfigurationManager.AppSettings["GoogleConsoleAPIAccessKey"];
            //string googleConsoleAPIAccessKey = ConfigurationManager.AppSettings["GoogleConsoleAPIAccessKeyUser"];

            m_broker.RegisterGcmService(new GcmPushChannelSettings(googleConsoleAPIAccessKey));
        }


        public static bool SendPushMessage(PushNotificationData PushDetail)
        {
            return new PushHelper().SendPushMessageInternal(PushDetail);
        }

        private bool SendPushMessageInternal(PushNotificationData PushData)
        {
            switch (PushData.DeviceType)
            {
                case (DeviceType.Android):
                    {
                        SendPushToAndriod(PushData);
                    }
                    break;

                case (DeviceType.IPhone):
                    {
                        SendPushToIoS(PushData);
                    }
                    break;

                case (DeviceType.WindowsPhone):
                    {
                        //To Do Send Push To Window phone
                    }
                    break;
                default:
                    break;
            }
            return true;
        }

        /// <summary>
        /// sending push to Android
        /// </summary>
        /// <param name="deviceRegistrationId"></param>
        /// <param name="pushNotifyType"></param>
        /// <param name="pushInformation"></param>
        private void SendPushToAndriod(PushNotificationData pushData)
        {
            //string pushMessage = "{ \"payload\": {\"message\":\"" + pushData.Message + "\",\"badge\":1,\"sound\":\"default\",\"PushType\":\"" + "Instant" + "\"," +"" +"}}";//pushData.GetJsonFromCustomItems()
            //string pushMessage = "{\"payload\":\""+ pushData.Message + "\"}";//pushData.Message;
            //Fluent construction of an Android GCM Notification
            //IMPORTANT: For Android you MUST use your own RegistrationId here that gets generated within your Android app itself!            
            //m_broker.QueueNotification(new GcmNotification().ForDeviceRegistrationId(pushData.DevicePushToken).WithJson(pushMessage));

            var value = pushData.Message;
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            tRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            tRequest.Headers.Add(string.Format("Authorization: key={0}", ConfigurationManager.AppSettings["FirebaseServerAPIKey"]));
            tRequest.Headers.Add(string.Format("Sender: id={0}", ConfigurationManager.AppSettings["FirebaseSenderKey"]));
            string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message=" + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + pushData.DevicePushToken + "";

            Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            tRequest.ContentLength = byteArray.Length;

            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);

                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            String sResponseFromServer = tReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// sending push to IoS
        /// </summary>
        /// <param name="deviceRegistrationId"></param>
        /// <param name="pushNotifyType"></param>
        /// <param name="pushInformation"></param>
        private void SendPushToIoS(PushNotificationData pushData)
        {
            var appleCert = File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Certificates/Certificates.p12"));
            m_broker.RegisterAppleService(new ApplePushChannelSettings(false, appleCert, ""));
            m_broker.QueueNotification(new AppleNotification().ForDeviceToken(pushData.DevicePushToken).WithAlert(pushData.Message).WithBadge(1));
        }



        private void DeviceSubscriptionChanged(object sender, string oldSubscriptionId, string newSubscriptionId, INotification notification)
        {

        }

        private void NotificationSent(object sender, INotification notification)
        {

        }

        private void NotificationFailed(object sender, INotification notification, Exception notificationFailureException)
        {


        }

        private void ChannelException(object sender, IPushChannel channel, Exception exception)
        {

        }

        private void ServiceException(object sender, Exception exception)
        {

        }

        private void DeviceSubscriptionExpired(object sender, string expiredDeviceSubscriptionId, DateTime timestamp, INotification notification)
        {

        }

        private void ChannelDestroyed(object sender)
        {

        }

        private void ChannelCreated(object sender, IPushChannel pushChannel)
        {

        }

        public void Dispose()
        {
            m_broker.StopAllServices();
        }
    }

}