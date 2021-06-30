using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanced.EventsAndDelegates
{
    public class MessageService
    {
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine("Message Service : Sending a text message ...." + args.Video.Title);
        }
    }
}
