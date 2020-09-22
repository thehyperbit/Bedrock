using CmlLib;
using CmlLib.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bedrock
{
    sealed class DataMinecraft
    {
        public void Initialize()
        {

        }

        public void Start(string IP, int Port)
        {
            string PathMinecraft = Directory.GetCurrentDirectory() + @"\Minecraft";

            Minecraft Game = new Minecraft(PathMinecraft);

            CMLauncher Launcher = new CMLauncher(Game);

            // launcher.UpdateProfiles();

            var launchOption = new MLaunchOption
            {
                MaximumRamMb = 2048,
                Session = MSession.GetOfflineSession("ALIBI"),

                JavaPath = "javaw.exe",
                JVMArguments = new string[] { },

                ServerIp = IP,
                ServerPort = Port,

                ScreenWidth = 1920,
                ScreenHeight = 1080,

                VersionType = "BedrockLauncher",
                GameLauncherName = "BedrockLauncher",
            };

            Process MinecraftProcess = Launcher.CreateProcess("1.15", launchOption);

            MinecraftProcess.Start();
        }
    }
}
