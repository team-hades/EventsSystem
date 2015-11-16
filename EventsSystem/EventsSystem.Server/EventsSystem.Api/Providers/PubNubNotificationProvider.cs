namespace EventsSystem.Api.Providers
{
    using PubNubMessaging.Core;

    public static class PubNubNotificationProvider
    {
        private const string Channel = "TeamHadesEventsSystem";
        private const string publishKey = "pub-c-5bbf4fcf-dac7-4751-b2e1-6aa9c37c1a99";
        private const string subscribekey = "sub-c-00253d8c-894b-11e5-8b47-02ee2ddab7fe";

        private static Pubnub pubnub = new Pubnub(publishKey, subscribekey);
        
        public static string LastMessage { get; private set; }

        public static string LastError { get; private set; }

        public static void Notify(string notification)
        {
            pubnub.Publish(Channel, notification, (x) => LastMessage = x.ToString(), (e) => LastError = e.ToString());
        }
    }
}