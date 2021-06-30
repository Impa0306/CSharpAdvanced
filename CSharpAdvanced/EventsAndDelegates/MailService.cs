using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanced.EventsAndDelegates
{
    public class MailService
    {
        public void OnVideoEncoded(object source, VideoEventArgs e)
        {
            Console.WriteLine("Mail Service: Sending an email ..." + e.Video.Title);
        }
    }
}
