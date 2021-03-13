using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GCFixer
{
    // Yoinked from Mod Assistant which was yoinked from my original mod installer
    public class Utils
    {
        public static string GetInstallDir() {

            string InstallDir = "";

            if (!string.IsNullOrEmpty(InstallDir)
                && Directory.Exists(InstallDir)
                && Directory.Exists(Path.Combine(InstallDir, "Beat Saber_Data", "Plugins"))
                && File.Exists(Path.Combine(InstallDir, "Beat Saber.exe"))) {
                return InstallDir;
            }

            try {
                InstallDir = GetSteamDir();
            } catch { }
            if (!string.IsNullOrEmpty(InstallDir)) {
                return InstallDir;
            }

            try {
                InstallDir = GetOculusDir();
            } catch { }
            if (!string.IsNullOrEmpty(InstallDir)) {
                return InstallDir;
            }

            MessageBox.Show("Could not find install folder");

            InstallDir = GetManualDir();
            if (!string.IsNullOrEmpty(InstallDir)) {
                return InstallDir;
            }

            return null;
        }

        public static string GetSteamDir() {

            string SteamInstall = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)?.OpenSubKey("SOFTWARE")?.OpenSubKey("WOW6432Node")?.OpenSubKey("Valve")?.OpenSubKey("Steam")?.GetValue("InstallPath").ToString();
            if (string.IsNullOrEmpty(SteamInstall)) {
                SteamInstall = Registry.LocalMachine.OpenSubKey("SOFTWARE")?.OpenSubKey("WOW6432Node")?.OpenSubKey("Valve")?.OpenSubKey("Steam")?.GetValue("InstallPath").ToString();
            }

            if (string.IsNullOrEmpty(SteamInstall)) return null;

            string vdf = Path.Combine(SteamInstall, @"steamapps\libraryfolders.vdf");
            if (!File.Exists(@vdf)) return null;

            Regex regex = new Regex("\\s\"\\d\"\\s+\"(.+)\"");
            List<string> SteamPaths = new List<string>
            {
                Path.Combine(SteamInstall, @"steamapps")
            };

            using (StreamReader reader = new StreamReader(@vdf)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    Match match = regex.Match(line);
                    if (match.Success) {
                        SteamPaths.Add(Path.Combine(match.Groups[1].Value.Replace(@"\\", @"\"), @"steamapps"));
                    }
                }
            }

            regex = new Regex("\\s\"installdir\"\\s+\"(.+)\"");
            foreach (string path in SteamPaths) {
                if (File.Exists(Path.Combine(@path, @"appmanifest_620980.acf"))) {
                    using (StreamReader reader = new StreamReader(Path.Combine(@path, @"appmanifest_620980.acf"))) {
                        string line;
                        while ((line = reader.ReadLine()) != null) {
                            Match match = regex.Match(line);
                            if (match.Success) {
                                if (File.Exists(Path.Combine(@path, @"common", match.Groups[1].Value, "Beat Saber.exe"))) {
                                    return Path.Combine(@path, @"common", match.Groups[1].Value);
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        public static string GetOculusDir() {
            try {
                string OculusInstall = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)?.OpenSubKey("SOFTWARE")?.OpenSubKey("Wow6432Node")?.OpenSubKey("Oculus VR, LLC")?.OpenSubKey("Oculus")?.OpenSubKey("Config")?.GetValue("InitialAppLibrary").ToString();
                if (string.IsNullOrEmpty(OculusInstall)) return null;

                if (!string.IsNullOrEmpty(OculusInstall)) {
                    if (File.Exists(Path.Combine(OculusInstall, "Software", "hyperbolic-magnetism-beat-saber", "Beat Saber.exe"))) {
                        return Path.Combine(OculusInstall, "Software", "hyperbolic-magnetism-beat-saber");
                    }
                }

                // Yoinked this code from Umbranox's Mod Manager. Lot's of thanks and love for Umbra <3
                using (RegistryKey librariesKey = Registry.CurrentUser.OpenSubKey("Software")?.OpenSubKey("Oculus VR, LLC")?.OpenSubKey("Oculus")?.OpenSubKey("Libraries")) {
                    // Oculus libraries uses GUID volume paths like this "\\?\Volume{0fea75bf-8ad6-457c-9c24-cbe2396f1096}\Games\Oculus Apps", we need to transform these to "D:\Game"\Oculus Apps"
                    WqlObjectQuery wqlQuery = new WqlObjectQuery("SELECT * FROM Win32_Volume");
                    using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(wqlQuery)) {
                        Dictionary<string, string> guidLetterVolumes = new Dictionary<string, string>();

                        foreach (ManagementBaseObject disk in searcher.Get()) {
                            var diskId = ((string)disk.GetPropertyValue("DeviceID")).Substring(11, 36);
                            var diskLetter = ((string)disk.GetPropertyValue("DriveLetter")) + @"\";

                            if (!string.IsNullOrWhiteSpace(diskLetter)) {
                                guidLetterVolumes.Add(diskId, diskLetter);
                            }
                        }

                        // Search among the library folders
                        foreach (string libraryKeyName in librariesKey.GetSubKeyNames()) {
                            using (RegistryKey libraryKey = librariesKey.OpenSubKey(libraryKeyName)) {
                                string libraryPath = (string)libraryKey.GetValue("Path");
                                // Yoinked this code from Megalon's fix. <3
                                string GUIDLetter = guidLetterVolumes.FirstOrDefault(x => libraryPath.Contains(x.Key)).Value;
                                if (!string.IsNullOrEmpty(GUIDLetter)) {
                                    string finalPath = Path.Combine(GUIDLetter, libraryPath.Substring(49), @"Software\hyperbolic-magnetism-beat-saber");
                                    if (File.Exists(Path.Combine(finalPath, "Beat Saber.exe"))) {
                                        return finalPath;
                                    }
                                }
                            }
                        }
                    }
                }

                return null;
            } catch (Exception) {
                return null;
            }
        
        }

        public static string GetManualDir() {
            var dialog = new SaveFileDialog() {
                Title = "Select your Beat Saber Directory",
                Filter = "Directory|*.this.directory",
                FileName = "select"
            };

            if (dialog.ShowDialog() == DialogResult.OK) {
                string path = dialog.FileName;
                path = path.Replace("\\select.this.directory", "");
                path = path.Replace(".this.directory", "");
                path = path.Replace("\\select.directory", "");
                if (File.Exists(Path.Combine(path, "Beat Saber.exe"))) {
                    return path;
                }
            }
            return null;
        }

        public static string GetManualFile(string filter = "", string title = "Open File") {
            var dialog = new OpenFileDialog() {
                Title = title,
                Filter = filter,
                Multiselect = false,
            };

            if (dialog.ShowDialog() == DialogResult.OK) {
                return dialog.FileName;
            }
            return null;
        }
    }
   
}
