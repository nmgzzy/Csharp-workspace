using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Receiving;
using MQTTnet.Extensions.ManagedClient;
using MQTTnet.Formatter;
using MQTTnet.Protocol;

namespace MqttMonitor
{
    public partial class Form1 : Form
    {
        public MyMqttMonitor Monitor = new MyMqttMonitor();
        public Form1()
        {
            InitializeComponent();
            this.comboBoxQos.SelectedIndex = 0;
        }
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (this.Monitor.Status["Connect"] == 0)
            {
                Monitor.SetMqttMonitor(textBoxHost.Text.Trim(),
                    int.Parse(textBoxPort.Text.Trim()),
                    textBoxUsername.Text.Trim(),
                    textBoxPassword.Text.Trim());
                labelStatus.Text = "Connecting";
                this.Monitor.Connect();
            }
            else
            {
                this.Monitor.Disconnect();
            }
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            if(this.Monitor.Status["Subscribe"] == 1)
            {
                this.Monitor.Unsubscribe();
            }
            else
            {
                this.Monitor.SubTopic = textBoxSubTopic.Text.Trim();
                this.Monitor.Subscribe();
            }
            this.textBoxMsg.Focus();
        }

        private void buttonPub_Click(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            this.Monitor.PubTopic = this.textBoxPubTopic.Text.Trim();
            this.Monitor.PubMessage = this.textBoxMsg.Text;
            this.Monitor.Publish();
            ((Button)sender).Enabled = true;
            this.textBoxMsg.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelStatus.Text = this.Monitor.StatusToString();
            if (this.Monitor.Status["Connect"] == 2)
            {
                this.buttonSub.Enabled = true;
                this.buttonPub.Enabled = true;
                this.buttonConnect.Enabled = false;
                this.buttonDisconnect.Enabled = true;
            }
            else if(this.Monitor.Status["Connect"] == 1)
            {
                this.buttonSub.Enabled = false;
                this.buttonPub.Enabled = false;
                this.buttonConnect.Enabled = false;
                this.buttonDisconnect.Enabled = true;
            }
            else
            {
                this.buttonSub.Enabled = false;
                this.buttonPub.Enabled = false;
                this.buttonConnect.Enabled = true;
                this.buttonDisconnect.Enabled = false;
            }
            if (this.Monitor.Status["Subscribe"] == 1)
            {
                this.buttonSub.Text = "Unsubscribe";
            }
            else
            {
                this.buttonSub.Text = "Subscribe";
            }
            if(this.Monitor.Status["ReceiveMsg"] == 1)
            {
                textBoxMsg.Text = this.Monitor.SubMessage;
                this.Monitor.Status["ReceiveMsg"] = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Monitor.Disconnect();
            this.Monitor.Status["Connect"] = 0;
        }

        private void comboBoxQos_SelectedIndexChanged(object sender, EventArgs e)
        {
            MqttQualityOfServiceLevel qos;
            switch (this.comboBoxQos.SelectedIndex)
            {
                case 0:
                    qos = MqttQualityOfServiceLevel.AtMostOnce;
                    break;
                case 1:
                    qos = MqttQualityOfServiceLevel.AtLeastOnce;
                    break;
                case 2:
                    qos = MqttQualityOfServiceLevel.ExactlyOnce;
                    break;
                default:
                    qos = MqttQualityOfServiceLevel.AtMostOnce;
                    break;
            }
            this.Monitor.Qos = qos;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (this.Monitor.Status["ReceiveMsg"] == 2)
            {
                this.pictureBox.Image = this.Monitor.image;
                this.Monitor.Status["ReceiveMsg"] = 0;
            }
        }
    }

    public class MyMqttMonitor
    {
        private Random rnd = new Random();
        public string Host;
        public int Port;
        public string Username;
        public string Password;
        public string PubTopic;
        public string SubTopic;
        public string SubMessage;
        public string PubMessage;
        public Image image;
        private IManagedMqttClient mqttClient;
        public MqttQualityOfServiceLevel Qos = 0;
        public Dictionary<string, short> Status = new Dictionary<string, short> {
            {"Connect", 0},//0断开，1连接中，2已连接
            {"Subscribe", 0},
            {"ReceiveMsg", 0}
        };
        static byte[] skey = new byte[] { 0xdb, 0x0f, 0x8c, 0x31, 0xed, 0x1d, 0xe2, 0xf8, 0x08, 0x55 };

        public string StatusToString()
        {
            string s = "";
            if(Status["Connect"] == 2)
            {
                s += "Connected";
            }
            else if (Status["Connect"] == 1)
            {
                s += "Connecting...";
            }
            else
            {
                s += "Disconnected";
            }
            if (Status["Subscribe"] == 1)
            {
                s += " Subscribe";
            }
            return s;
        }
        public void SetMqttMonitor(string Host, int Port, string Username, string Password)
        {
            this.Host = Host;
            this.Port = Port;
            this.Username = Username;
            this.Password = Password;
        }
        public async void Connect()
        {
            this.Status["Connect"] = 1;
            var mqttFactory = new MqttFactory();
            var tlsOptions = new MqttClientTlsOptions
            {
                UseTls = false,
                IgnoreCertificateChainErrors = true,
                IgnoreCertificateRevocationErrors = true,
                AllowUntrustedCertificates = true
            };

            var options = new MqttClientOptions
            {
                ClientId = "WinClient"+ rnd.Next(999999),
                ProtocolVersion = MqttProtocolVersion.V311,
                ChannelOptions = new MqttClientTcpOptions
                {
                    Server = this.Host,
                    Port = this.Port,
                    TlsOptions = tlsOptions
                }
            };

            if (options.ChannelOptions == null)
            {
                throw new InvalidOperationException();
            }

            options.Credentials = new MqttClientCredentials
            {
                Username = this.Username,
                Password = Encoding.UTF8.GetBytes(this.Password)
            };
            options.CleanSession = true;
            options.KeepAlivePeriod = TimeSpan.FromSeconds(10);
            options.MaximumPacketSize = 20000;
            
            this.mqttClient = mqttFactory.CreateManagedMqttClient();
            this.mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(OnMqttConnected);
            this.mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(OnMqttDisconnected);
            this.mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(this.OnSubscriberMessageReceived);
            var managedMqttClientOptions = new ManagedMqttClientOptions
            {
                ClientOptions = options,
            };
            await this.mqttClient.StartAsync(managedMqttClientOptions);
        }
        private void OnMqttConnected(MqttClientConnectedEventArgs x)
        {
            this.Status["Connect"] = 2;
            //MessageBox.Show("Subscriber Connected", "ConnectHandler", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void OnMqttDisconnected(MqttClientDisconnectedEventArgs x)
        {
            //MessageBox.Show("Subscriber Disconnected", "ConnectHandler", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void OnSubscriberMessageReceived(MqttApplicationMessageReceivedEventArgs x)
        {
            if (x.ApplicationMessage.Topic == "mytopic")
            {
                //var item = $"Timestamp: {DateTime.Now:O} | Topic: {x.ApplicationMessage.Topic} | Payload: {x.ApplicationMessage.ConvertPayloadToString()} | QoS: {x.ApplicationMessage.QualityOfServiceLevel}";
                //MessageBox.Show(item);
                this.SubMessage = x.ApplicationMessage.ConvertPayloadToString();
                this.Status["ReceiveMsg"] = 1;
            }
            else if (x.ApplicationMessage.Topic == "mytopic/cam")
            {
                for (int i = 0, j = 0; i < x.ApplicationMessage.Payload.Length; i += 20, j++)
                {
                    if (j >= 10)
                    {
                        j = 0;
                    }
                    x.ApplicationMessage.Payload[i] = (byte)(x.ApplicationMessage.Payload[i] ^ skey[j]);
                }
                MemoryStream ms = new MemoryStream(x.ApplicationMessage.Payload);
                image = Image.FromStream(ms);
                //BinaryWriter fb;                
                //FileStream F = new FileStream("test.jpg", FileMode.Create, FileAccess.Write);
                //fb = new BinaryWriter(F);
                //fb.Write(x.ApplicationMessage.Payload);
                //fb.Close();
                this.Status["ReceiveMsg"] = 2;
            }
            else
            {
                //MessageBox.Show(x.ApplicationMessage.Payload.Length.ToString());
                string item;
                if (x.ApplicationMessage.ConvertPayloadToString().Length > 31)
                {
                    item = $"Timestamp: {DateTime.Now:O} | Topic: {x.ApplicationMessage.Topic} | Payload: {x.ApplicationMessage.ConvertPayloadToString().Substring(0, 30)} | Payloadlength: {x.ApplicationMessage.Payload.Length}| QoS: {x.ApplicationMessage.QualityOfServiceLevel}";
                }
                else
                {
                    item = $"Timestamp: {DateTime.Now:O} | Topic: {x.ApplicationMessage.Topic} | Payload: {x.ApplicationMessage.ConvertPayloadToString()} | QoS: {x.ApplicationMessage.QualityOfServiceLevel}";
                }
                MessageBox.Show(item);
            }
        }
        public async void Disconnect()
        {
            await this.mqttClient.StopAsync();
            this.mqttClient = null;
        }
        public async void Subscribe()
        {
            var topicFilter = new MqttTopicFilter { Topic = this.SubTopic };
            topicFilter.QualityOfServiceLevel = Qos;
            await this.mqttClient.SubscribeAsync(topicFilter);
            this.Status["Subscribe"] = 1;
        }
        public async void Unsubscribe()
        {
            await this.mqttClient.UnsubscribeAsync(this.SubTopic);
            this.Status["Subscribe"] = 0;
        }
        public async void Publish()
        {
            try
            {
                //QoS0，At most once，至多一次；
                //QoS1，At least once，至少一次；
                //QoS2，Exactly once，确保只有一次。

                var payload = Encoding.UTF8.GetBytes(this.PubMessage);
                var message = new MqttApplicationMessageBuilder().WithTopic(this.PubTopic).WithPayload(payload).WithQualityOfServiceLevel(this.Qos).WithRetainFlag().Build();

                if (this.mqttClient != null)
                {
                    await this.mqttClient.PublishAsync(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Occurs", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
