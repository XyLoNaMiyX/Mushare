using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mushare
{
    public static class SongScanner
    {
        static bool scanning;
        static readonly Stack<string> pendingScans = new Stack<string>();

        public static void ScanSongs(params string[] songPaths)
        {
            foreach (var song in songPaths)
                pendingScans.Push(song);
        }

        public static SongInformation GetSongInformation(string path)
        {
            var songs = SerializerXML.Deserialize<List<SongInformation>>(path);
            foreach (var song in songs)
            {
            }

            return null;
        }

        // begin scan thread if it hasn't started yet
        static void BeginScanThread()
        {
            if (!scanning)
                return;

            scanning = true;
            new Thread(ScanThread)
            {
                IsBackground = true,
                Priority = ThreadPriority.Lowest
            }.Start();
        }

        static void ScanThread()
        {
            while (pendingScans.Count > 0)
            {
                var song = pendingScans.Pop();
            }
            scanning = false;
        }
    }
}
