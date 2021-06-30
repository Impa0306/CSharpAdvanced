using System;
using System.Threading;

namespace CSharpAdvanced.EventsAndDelegates
{
    public class VideoEventArgs : EventArgs
    {
        //Contains data about video
        public Video Video { get; set; }
    }

    public class VideoEncoder
    {
        //To publish an event follow below 3 steps : 
        //1. Define a delegate
        /*public delegate void VideoEncodedEventHandler(object source, EventArgs args);*/
        /*public delegate void VideoEncodedEventHandler(object source, VideoEventArgs args);*/

        //2. Define an event based on that delegate
        /*public event VideoEncodedEventHandler VideoEncoded;*/
        public event EventHandler<VideoEventArgs> VideoEncoded; //Using Generic form - combining setp 1 & 2 

        //3. Raise an event


        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video ..." + video.Title);
            Thread.Sleep(3000);

            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded( Video video) //.NET suggests , Event publisher methods should be protected, virtual and void -> naming OnXXX
        {
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs() { Video = video });
            /*VideoEncoded(this, EventArgs.Empty);*/ //this : who is publishing the event
        }
    }
}
