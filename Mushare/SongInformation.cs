using System;
using System.IO;
using Vlc.DotNet.Core;
using Vlc.DotNet.Core.Interops;
using Vlc.DotNet.Forms;

namespace Mushare
{
    public class SongInformation : IEquatable<SongInformation>, IEquatable<string>
    {
        // vlc control used to get the track information
        // TODO there must be a better way to do this...
        static readonly VlcControl vlcControl = new VlcControl();

        static SongInformation()
        {
            vlcControl.BeginInit();
            vlcControl.VlcLibDirectory = Utils.GetVlcLibDirectory();
            vlcControl.EndInit();
        }

        public string Title { get; set; }
        public string Artist { get; set; }
        public TimeSpan Duration { get; set; }
        public string Path { get; set; }

        public long FileSize { get; set; }

        public SongInformation(string file)
        {
            var media = GetMedia(file);

            Title = media.Title;
            Artist = media.Artist;
            Duration = media.Duration;
            Path = file;
            FileSize = new FileInfo(file).Length;
        }

        static readonly object locker = new object();

        static VlcMedia GetMedia(string file)
        {
            lock (locker)
            {
                // play and stop to analyse the media
                vlcControl.SetMedia(new FileInfo(file));
                vlcControl.Play();
                vlcControl.Stop();

                return vlcControl.GetCurrentMedia();
            }
        }

        public bool Equals(SongInformation other)
        {
            if (Path == null && other.Path != null)
                return false;

            return Path.Equals(other.Path) && FileSize.Equals(other.FileSize);
        }

        public bool Equals(string other)
        {
            if (Path == null && other != null)
                return false;

            if (!Path.Equals(other))
                return false;

            var otherInfo = new FileInfo(other);
            return otherInfo.Exists && otherInfo.Length == FileSize;
        }
    }
}
