using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace Bedrock
{
    sealed class DataConnection
    {
        public static bool Connection { get; set; } = false;
        public static uint RemotePort { get; set; } = 25565;

        public void Initialize()
        {

        }

        public async void Start()
        {                  
           /* using (var Client = new SshClient("tech.hypergalaxy.net", "bedrock", "Verification8111"))
            {
                ForwardedPortRemote Port = new ForwardedPortRemote("localhost", RemotePort, "localhost", 48211);

                Client.Connect();
  
                Client.AddForwardedPort(Port);

                Port.Start();

                Connection = true;

                Port.Exception += delegate (object sender, ExceptionEventArgs e)
                {
                    Port.Stop();
                    Client.Disconnect();
                    Connection = false;
                };

                while (Connection == true) { }

                Port.Stop();
                Client.Disconnect();
            }*/
     
        }

        public void Finish()
        {

        }
    }
}
