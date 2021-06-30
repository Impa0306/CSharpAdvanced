using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanced.ExceptionHandling
{
    public class YoutubeApi
    {
        public List<Video> GetVideos(string user)
        {
            try
            {
                //Acess Youtube web service
                //Read the data
                //Create a list of Video objects

                //Manually trigerring the exception
                throw new Exception("OOPS!! Some low-level Youtube error");
            }
            catch (Exception e)
            {
                //Log

                throw new YoutubeException("Could not fetch the video from Youtube", e);
            }
        }
    }
}
