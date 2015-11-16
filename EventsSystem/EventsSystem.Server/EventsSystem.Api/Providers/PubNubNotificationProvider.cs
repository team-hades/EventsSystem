namespace EventsSystem.Api.Providers
{
    using PubNubMessaging.Core;

    public class PubNubNotificationProvider : INotificationProvider
    {
        private const string Channel = "";
        private const string publishKey = "";
        private const string subscribekey = "";

        private static PubNubNotificationProvider instance;

        private static Pubnub pubnub;

        private PubNubNotificationProvider()
        {
            pubnub = new Pubnub(publishKey, subscribekey);
        }

        public static PubNubNotificationProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PubNubNotificationProvider();
                }

                return instance;
            }
        }

        public static string LastMessage { get; private set; }

        public static string LastError { get; private set; }

        public void Notify(string notification)
        {
            pubnub.Publish(Channel, notification, (x) => LastMessage = x.ToString(), (e) => LastError = e.ToString());
        }
    }
}