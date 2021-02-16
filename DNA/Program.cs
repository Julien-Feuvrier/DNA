using E.Deezer;
using E.Deezer.Api;
using System;
using System.Collections.Generic;

namespace DNA
{
    internal class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// Execute the user command line depending on the specified arguments.
        /// </summary>
        /// <param name="args">The command line arguments.</param>
        private static void Main(string[] args)
        {
            DisplayTop10Tracks();
            Console.ReadLine();
        }

        private static async void DisplayTop10Tracks()
        {
            Deezer deezer = DeezerSession.CreateNew();
            IEnumerable<ITrack> top10 = await deezer.Browse.Charts.GetTrackChart(aCount: 10);

            int trackId = 0;
            foreach (ITrack track in top10)
            {
                trackId++;
                Console.WriteLine($"{trackId}: {track.Title} - {track.AlbumName} - {track.ArtistName}");
            }
        }
    }
}