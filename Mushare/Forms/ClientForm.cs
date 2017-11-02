using Mushare.TCP;
using System.Windows.Forms;

namespace Mushare
{
    public partial class ClientForm : Form
    {
        MushareClient client;
        string host;

        public ClientForm(string name, string host)
        {
            InitializeComponent();

            this.host = host;
            welcomeLabel.Text = $"Welcome back to Mushare {name}!";

            client = new MushareClient();
            client.Connected += Client_ClientConnected;
            client.ConnectionFailed += Reconnect;
            client.Disconnected += Reconnect;
            client.MushageReceived += Client_MushageReceived; ;
        }

        private void Client_MushageReceived(Mushages.Mushage mushage)
        {
            throw new System.NotImplementedException();
        }

        void ClientForm_Load(object sender, System.EventArgs e)
        {
            Connect();
        }

        void Connect()
        {
            UpdateStatus("Connecting...");
            client.Connect(host);
        }

        private void Client_ClientConnected()
        {
            UpdateStatus("Connected");
        }
        
        // TODO make a bigger notification if wasConnected and now isn't
        void Reconnect()
        {
            UpdateStatus("Connection lost! Trying to reconnect...");
            client.Connect(host);
        }

        void Client_ClientDisconnected()
        {
            Reconnect();
        }

        void UpdateStatus(string status)
        {
            statusLabel.Text = status;
        }
    }
}
