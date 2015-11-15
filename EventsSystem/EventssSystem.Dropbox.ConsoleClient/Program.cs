namespace EventssSystem.Dropbox.ConsoleClient
{
    using System;
    using EventsSystem.Data.Dropbox;

    public class Program
    {
        static void Main()
        {
            DropboxHelper dh = new DropboxHelper();

            // check if it is Up & Running 
            // Lists all files in profiles folder
            dh.Run().Wait();

            // download file with specific name from profiles folder
            // saves it in bin/debug 
            dh.Download("pesho.bmp").Wait();

            try
            {
                dh.Download("jm.bmp").Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // upload file with specific name from
            // bin/debug 
            dh.UploadProfilePicture("gosho.bmp").Wait();
        }
    }
}
