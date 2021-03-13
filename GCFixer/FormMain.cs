using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GCFixer
{
    public partial class FormMain : Form
    {
        private const string GC_TIME_MAX_SLICE = "gc-max-time-slice";
        private const string GC_TIME_MAX_SLICE_WITH_VALUE = "gc-max-time-slice=3";

        private string _installDir;
        private string _bootConfigPath;

        public FormMain() {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e) {
            _installDir = Utils.GetInstallDir();
            _bootConfigPath = Path.Combine(_installDir, "Beat Saber_Data", "boot.config");
            textBoxInstallDir.Text = _installDir;
        }

        private void ButtonFix_Click(object sender, EventArgs e) {
            try {
                if (SetIncrementalMode(true)) {
                    MessageBox.Show("Sucessfully fixed Beat Sabers GC", "GC Fixer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                } else {
                    MessageBox.Show("Beat Sabers GC is already fixed", "GC Fixer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch (Exception) {
                MessageBox.Show("Failed to fix Beat Sabers GC", "GC Fixer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonUnfix_Click(object sender, EventArgs e) {
            try {
                if (SetIncrementalMode(false)) {
                    MessageBox.Show("Sucessfully unfixed Beat Sabers GC", "GC Fixer", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                } else {
                    MessageBox.Show("Beat Sabers GC is already unfixed", "GC Fixer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch (Exception) {
                MessageBox.Show("Failed to unfix Beat Sabers GC", "GC Fixer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonChange_Click(object sender, EventArgs e) {
            _installDir = Utils.GetManualDir();
            textBoxInstallDir.Text = _installDir;
        }

        private void LinkLabelUmbranox_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://twitter.com/Umbranoxus");
        }

        private void LinkLabelAuros_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://twitter.com/AurosVR");
        }

        private bool SetIncrementalMode(bool value) {
            List<string> bootConfigFileText = File.ReadAllLines(_bootConfigPath).ToList();
            bool modified = false;
            if (bootConfigFileText.Any(l => l.StartsWith(GC_TIME_MAX_SLICE))) {
                for (int i = 0; i < bootConfigFileText.Count; i++) {
                    string line = bootConfigFileText[i];
                    if (line.StartsWith(GC_TIME_MAX_SLICE)) {
                        if (!value) {
                            modified = true;
                            bootConfigFileText.Remove(line);
                            break;
                        }
                        if (line != GC_TIME_MAX_SLICE_WITH_VALUE) {
                            modified = true;
                            bootConfigFileText[i] = GC_TIME_MAX_SLICE_WITH_VALUE;
                            break;
                        }
                    }
                }
            } else if (value) {
                modified = true;
                bootConfigFileText.Add(GC_TIME_MAX_SLICE_WITH_VALUE);
            }

            if (modified) {
                File.WriteAllLines(_bootConfigPath, bootConfigFileText);
            }
            return modified;
        }
    }
}
