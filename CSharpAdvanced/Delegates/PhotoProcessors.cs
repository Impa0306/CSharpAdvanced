using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAdvanced.Delegates
{
    class PhotoProcessors
    {
        //public delegate void PhotoFilterHandler(Photo photo); //Replcae custom delegate with generic built-in delegate

        public void Process(string path, Action<Photo> filterHandler)
        {
            //System.Action<>

            //System.Func<>

            //Loads the photo
            var photo = Photo.Load(path);

            //Applies filters
            /*var filters = new PhotoFilters();
            filters.ApplyBrightness(photo);
            filters.ApplyContrast(photo);
            filters.Resize(photo);*/
            filterHandler(photo); //this makes the method invoke more extensible & flexible 

            //Saves the photo
            photo.Save();
        }
    }
}
