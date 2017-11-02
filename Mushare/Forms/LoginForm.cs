using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace Mushare
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            new SongInformation("D:\\Música\\Calvin Harris ft. Rihanna - This Is What You Came For.mp3");
        }

        private void OnVlcControlNeedLibDirectory(object sender, VlcLibDirectoryNeededEventArgs e)
        {
            e.VlcLibDirectory = Utils.GetVlcLibDirectory();
        }

        void hostNameTextBox_TextChanged(object sender, EventArgs e)
        {
            hostButton.Enabled = hostNameTextBox.Text.Length > 0;
        }

        void loginTextBox_TextChanged(object sender, EventArgs e)
        {
            checkLoginButton();
        }

        void connectComboBox_TextChanged(object sender, EventArgs e)
        {
            checkLoginButton();
        }
        void checkLoginButton()
        {
            bool nameOk = loginTextBox.Text.Length > 0;
            bool connectOk = Regex.IsMatch(hostComboBox.Text, @"\d{1,3}.\d{1,3}.\d{1,3}.\d{1,3}");

            connectButton.Enabled = nameOk && connectOk;
        }

        void connectButton_Click(object sender, EventArgs e)
        {
            // TODO MAYBE LOGOUT SHOWS THIS AGAIN
            LaunchMain(new ClientForm(loginTextBox.Text, hostComboBox.Text));
        }

        void hostButton_Click(object sender, EventArgs e)
        {
            LaunchMain(new ServerForm(hostNameTextBox.Text));
        }

        void LaunchMain(Form form)
        {
            Hide();
            form.Closed += (s, e) => Close();
            form.Show();
        }

        //private void OnButtonStopClicked(object sender, EventArgs e)
        //{
        //    vlcControl.Stop();
        //}

        //private void OnButtonPauseClicked(object sender, EventArgs e)
        //{
        //    vlcControl.Pause();
        //}

        //private void OnVlcMediaLengthChanged(object sender, VlcMediaPlayerLengthChangedEventArgs e)
        //{
        //    //myLblMediaLength.InvokeIfRequired(l => l.Text = new DateTime(new TimeSpan((long)e.NewLength).Ticks).ToString("T"));
        //}

        //private void OnVlcPositionChanged(object sender, VlcMediaPlayerPositionChangedEventArgs e)
        //{
        //    var position = vlcControl.GetCurrentMedia().Duration.Ticks * e.NewPosition;
        //    //myLblVlcPosition.InvokeIfRequired(l => l.Text = new DateTime((long)position).ToString("T"));
        //}

        //private void OnVlcPaused(object sender, VlcMediaPlayerPausedEventArgs e)
        //{
        //    //myLblState.InvokeIfRequired(l => l.Text = "Paused");
        //}

        //private void OnVlcStopped(object sender, VlcMediaPlayerStoppedEventArgs e)
        //{
        //    //myLblState.InvokeIfRequired(l => l.Text = "Stopped");

        //    //myCbxAspectRatio.InvokeIfRequired(c =>
        //    //{
        //    //    c.Text = string.Empty;
        //    //    c.Enabled = false;
        //    //});
        //    //myLblAudioCodec.Text = "Codec: ";
        //    //myLblAudioChannels.Text = "Channels: ";
        //    //myLblAudioRate.Text = "Rate: ";
        //    //myLblVideoCodec.Text = "Codec: ";
        //    //myLblVideoHeight.Text = "Height: ";
        //    //myLblVideoWidth.Text = "Width: ";
        //}

        //private void OnVlcPlaying(object sender, VlcMediaPlayerPlayingEventArgs e)
        //{
        //    //myLblState.InvokeIfRequired(l => l.Text = "Playing");

        //    //myLblAudioCodec.InvokeIfRequired(l => l.Text = "Codec: ");
        //    //myLblAudioChannels.InvokeIfRequired(l => l.Text = "Channels: ");
        //    //myLblAudioRate.InvokeIfRequired(l => l.Text = "Rate: ");
        //    //myLblVideoCodec.InvokeIfRequired(l => l.Text = "Codec: ");
        //    //myLblVideoHeight.InvokeIfRequired(l => l.Text = "Height: ");
        //    //myLblVideoWidth.InvokeIfRequired(l => l.Text = "Width: ");

        //    var mediaInformations = vlcControl.GetCurrentMedia().TracksInformations;
        //    foreach (var mediaInformation in mediaInformations)
        //    {
        //        if (mediaInformation.Type == MediaTrackTypes.Audio)
        //        {
        //            //myLblAudioCodec.InvokeIfRequired(l => l.Text += mediaInformation.CodecName);
        //            //myLblAudioChannels.InvokeIfRequired(l => l.Text += mediaInformation.Audio.Channels);
        //            //myLblAudioRate.InvokeIfRequired(l => l.Text += mediaInformation.Audio.Rate);
        //        }
        //        else if (mediaInformation.Type == MediaTrackTypes.Video)
        //        {
        //            //myLblVideoCodec.InvokeIfRequired(l => l.Text += mediaInformation.CodecName);
        //            //myLblVideoHeight.InvokeIfRequired(l => l.Text += mediaInformation.Video.Height);
        //            //myLblVideoWidth.InvokeIfRequired(l => l.Text += mediaInformation.Video.Width);
        //        }
        //    }

        //    //myCbxAspectRatio.InvokeIfRequired(c =>
        //    //{
        //    //    c.Text = vlcControl.Video.AspectRatio;
        //    //    c.Enabled = true;
        //    //});
        //}

        //private void myCbxAspectRatio_TextChanged(object sender, EventArgs e)
        //{
        //    //vlcControl.Video.AspectRatio = myCbxAspectRatio.Text;
        //    ResizeVlcControl();
        //}

        //private void Sample_SizeChanged(object sender, EventArgs e)
        //{
        //    ResizeVlcControl();
        //}

        //void ResizeVlcControl()
        //{
        //    //if (!string.IsNullOrEmpty(myCbxAspectRatio.Text))
        //    //{
        //    //    var ratio = myCbxAspectRatio.Text.Split(':');
        //    //    int width, height;
        //    //    if (ratio.Length == 2 && int.TryParse(ratio[0], out width) && int.TryParse(ratio[1], out height))
        //    //        vlcControl.Width = vlcControl.Height * width / height;
        //    //}
        //}
    }
}
