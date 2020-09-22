using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bedrock
{
    sealed class DataServer
    {
        private Process ProcessServer = new Process();
        private static bool WatchDogs = false;
        private int RAM = 8192;

        public async void Initialize(string Name, string Mode, string Difficult, string Slots)
        {
            try
            {
                string ServerProperties =
                    "#Minecraft server properties\n" +
                    "#Wed Aug 26 11:00:00 EEST 2020\n" +
                    "spawn-protection=0\n" +
                    "max-tick-time=60000\n" +
                    "query.port=48211\n" +
                    "generator-settings=\n" +
                    "sync-chunk-writes=true\n" +
                    "force-gamemode=false\n" +
                    "allow-nether=true\n" +
                    "enforce-whitelist=false\n" +
                    "gamemode=" + Mode + "\n" +
                    "broadcast-console-to-ops=true\n" +
                    "enable-query=true\n" +
                    "player-idle-timeout=0\n" +
                    "difficulty=" + Difficult + "\n" +
                    "broadcast-rcon-to-ops=true\n" +
                    "spawn-monsters=true\n" +
                    "op-permission-level=4\n" +
                    "pvp=true\n" +
                    "entity-broadcast-range-percentage=100\n" +
                    "snooper-enabled=true\n" +
                    "level-type=default\n" +
                    "enable-status=true\n" +
                    "hardcore=false\n" +
                    "enable-command-block=true\n" +
                    "max-players=" + Slots + "\n" +
                    "network-compression-threshold=256\n" +
                    "max-world-size=29999984\n" +
                    "resource-pack-sha1=\n" +
                    "function-permission-level=2\n" +
                    "rcon.port=\n" +
                    "server-port=48211\n" +
                    "server-ip=\n" +
                    "spawn-npcs=true\n" +
                    "allow-flight=false\n" +
                    "level-name=world\n" +
                    "view-distance=10\n" +
                    "resource-pack=\n" +
                    "spawn-animals = true\n" +
                    "white-list=false\n" +
                    "rcon.password=\n" +
                    "generate-structures=true\n" +
                    "online-mode=false\n" +
                    "max-build-height=256\n" +
                    "level-seed=\n" +
                    "prevent-proxy-connections=false\n" +
                    "use-native-transport=true\n" +
                    "enable-jmx-monitoring=false\n" +
                    "motd=" + Name + "\n" +
                    "enable-rcon=true\n";

                FileStream FileStream = new FileStream(Directory.GetCurrentDirectory() + @"\servers\1.15\server.properties", FileMode.Create);
                byte[] ArrayProperties = Encoding.Default.GetBytes(ServerProperties);
                FileStream.Write(ArrayProperties, 0, ArrayProperties.Length);
                FileStream.Close();    
            }
            catch
            {

            }

            try
            {
                if (File.Exists(@"C:\HyperGalaxy\Bedrock\Launcher(PC)\bin\Debug\Servers\1.15\banned-players.json"))
                {
                    File.Delete(@"C:\HyperGalaxy\Bedrock\Launcher(PC)\bin\Debug\Servers\1.15\banned-players.json");
                }
                if (File.Exists(@"C:\HyperGalaxy\Bedrock\Launcher(PC)\bin\Debug\Servers\1.15\banned-ips.json"))
                {
                    File.Delete(@"C:\HyperGalaxy\Bedrock\Launcher(PC)\bin\Debug\Servers\1.15\banned-ips.json");
                }
                if (File.Exists(@"C:\HyperGalaxy\Bedrock\Launcher(PC)\bin\Debug\Servers\1.15\usercache.json"))
                {
                    File.Delete(@"C:\HyperGalaxy\Bedrock\Launcher(PC)\bin\Debug\Servers\1.15\usercache.json");
                }
                if (File.Exists(@"C:\HyperGalaxy\Bedrock\Launcher(PC)\bin\Debug\Servers\1.15\ops.json"))
                {
                    File.Delete(@"C:\HyperGalaxy\Bedrock\Launcher(PC)\bin\Debug\Servers\1.15\ops.json");
                }
            }
            catch
            {

            }

            await Task.Run(() => Start());         
        }

        public async void Start()
        {
            try
            {
                ProcessServer.StartInfo.FileName = "java";
                ProcessServer.StartInfo.Arguments = $"-Xms1024M -Xmx1024M -jar Server(1.15).jar nogui";
                ProcessServer.StartInfo.UseShellExecute = false;
                ProcessServer.StartInfo.WorkingDirectory = @"C:\HyperGalaxy\Bedrock\Launcher(PC)\bin\Debug\servers\1.15";
                ProcessServer.StartInfo.RedirectStandardOutput = true;
                ProcessServer.StartInfo.RedirectStandardInput = true;
                ProcessServer.StartInfo.CreateNoWindow = true;
                ProcessServer.StartInfo.RedirectStandardError = false;
                ProcessServer.Start();

                await Task.Delay(5000);

                WatchDogs = true;

                while (WatchDogs = true)
                {
                    string OP = ProcessServer.StandardOutput.ReadLine();
                    if (OP != null)
                    {
                        if (OP.Contains("ALIBI joined the game"))
                        {
                            ProcessServer.StandardInput.WriteLine("op ALIBI");
                            WatchDogs = true;
                        }
                    }
                }
                                
            }
            catch
            {

            }
        }

        public void Finish()
        {
            ProcessServer.Kill();

            WatchDogs = false;
        }
    }
}
