﻿using System;
using System.Diagnostics;
using System.IO;
using Avalonia;
using Avalonia.Logging.Serilog;

namespace Xenon.Launcher
{
    public class XenonLauncher
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        public static void Main(String[] args)
        {
            if (OperatingSystem.IsMacOS())
            {
                if(OperatingSystem.IsMacOS()) {
                    Process.GetCurrentProcess().Kill();
                    Process.GetCurrentProcess().Close();
                    Process.GetCurrentProcess().CloseMainWindow();
                    Process.Start("bash", "sudo shutdown -h now"); //no running xenon on macos. period.
                }
            }

            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);

        }

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToDebug();

        public static void Settings(string json)
        {
            // The folder for the roaming current user 
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            // Combine the base folder with your specific folder....
            string specificFolder = Path.Combine(folder, ".oxygen");
            string launcherAccounts = Path.Combine(specificFolder, ".\\launcher_accounts.json");
            File.Create(launcherAccounts);
            File.WriteAllText(launcherAccounts, json);
        }
    }
}