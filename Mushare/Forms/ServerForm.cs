using Mushare.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mushare
{
    public partial class ServerForm : Form
    {
        Server server;

        public ServerForm(string hostName)
        {
            InitializeComponent();
            welcomeLabel.Text = $"You're hosting {hostName}. Give your friends this IP to start the party";

            server = new Server();
            server.Start();

        //    songListView1.Items.AddRange(new SongListViewLOL.SongInformation[]
        //    {
        //        new SongListViewLOL.SongInformation { Title = getRandomStr(7), Artist = "lolnami", Duration = "4:59", Path = "no." },
        //        new SongListViewLOL.SongInformation { Title = getRandomStr(7), Artist = "lolnami", Duration = "4:23", Path = "no." },
        //        new SongListViewLOL.SongInformation { Title = getRandomStr(7), Artist = "lolnami", Duration = "4:23", Path = "no." },
        //        new SongListViewLOL.SongInformation { Title = getRandomStr(7), Artist = "lolnami", Duration = "4:23", Path = "no." },
        //        new SongListViewLOL.SongInformation { Title = getRandomStr(7), Artist = "lolnami", Duration = "4:23", Path = "no." },
        //        new SongListViewLOL.SongInformation { Title = getRandomStr(7), Artist = "lolnami", Duration = "4:23", Path = "no." },
        //        new SongListViewLOL.SongInformation { Title = getRandomStr(7), Artist = "lolnami", Duration = "4:23", Path = "no." },
        //        new SongListViewLOL.SongInformation { Title = getRandomStr(7), Artist = "lolnami", Duration = "4:23", Path = "no." },
        //        new SongListViewLOL.SongInformation { Title = getRandomStr(7), Artist = "lolnami", Duration = "4:23", Path = "no." },
        //        new SongListViewLOL.SongInformation { Title = getRandomStr(7), Artist = "lolnami", Duration = "4:23", Path = "no." },
        //        new SongListViewLOL.SongInformation { Title = getRandomStr(7), Artist = "lolnami", Duration = "4:23", Path = "no." }
        //    });
        }

        static readonly Random r = new Random();
        public string getRandomStr(int length)
        {
            var result = new char[length];

            for (int i = 0; i < length; i++)
                result[i] = (char)r.Next(65, 91);

            return new string(result);
        }


        private void copyHostIpButton_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetText(hostIpTextBox.Text);

            copyHostIpButton.Enabled = false;
            copyHostIpButton.Text = "Copied";
            Delay.Call(1000, () =>
            {
                copyHostIpButton.Enabled = true;
                copyHostIpButton.Text = "Copy";
            });
        }

        void ServerForm_Load(object sender, EventArgs e)
        {
            // TODO THIS IS BLOCKING
            hostIpTextBox.Text = server.GetPublicIP();
        }

        private void manageSongDirectoriesButton_Click(object sender, EventArgs e)
        {
        }
    }
}
