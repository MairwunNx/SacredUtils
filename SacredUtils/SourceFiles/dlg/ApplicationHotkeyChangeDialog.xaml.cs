using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

// ReSharper disable PrivateFieldCanBeConvertedToLocalVariable
namespace SacredUtils.resources.dlg
{
    public partial class ApplicationHotkeyChangeDialog
    {
        private static string[] _gameKeys;
        private static string[] _systemKeys;
        private static string[] _hotkeyKeys;
        private static string _oldSystemText;

        public ApplicationHotkeyChangeDialog()
        {
            InitializeComponent();

            if (AppSettings.ApplicationSettings.UseSimplifiedHotKeySettings)
            {
                NewHotkeyCmbBox.IsEnabled = false;

                NewHotkeyCmbBox.Margin = new Thickness(241, 63, 0, 0);
                OriginalHotkey.Margin = new Thickness(20, 63, 0, 0);

                _gameKeys = File.ReadAllLines("$SacredUtils\\conf\\hk.orsf.txt");
                _systemKeys = File.ReadAllLines("$SacredUtils\\conf\\hk.kesf.txt");
                _hotkeyKeys = File.ReadAllLines("$SacredUtils\\conf\\hk.setg.txt", Encoding.UTF8);

                OriginalHotkey.ItemsSource = _gameKeys;
                NewHotkeyCmbBox.ItemsSource = _systemKeys;

                BaseLabel.Content = "=";

                OriginalHotkey.SelectionChanged += GetHotKeySetting;

                NewHotkeyCmbBox.SelectionChanged += SaveHotKey;
            }
            else
            {
                OriginalHotkey.ItemsSource = File.ReadAllLines("$SacredUtils\\conf\\hk.orig.txt");
                NewHotkeyCmbBox.ItemsSource = File.ReadAllLines("$SacredUtils\\conf\\hk.keyb.txt");

                NewHotkeyCmbBox.SelectionChanged += (s, e) => GetSelection();
            }
        }

        #region SimplifiedHotKeySettingsCode 

        private void GetHotKeySetting(object sender, SelectionChangedEventArgs e)
        {
            NewHotkeyCmbBox.IsEnabled = true;

            string key = (sender as ComboBox)?.SelectedItem as string;

            string prefix = $"{key} = ";

            string line = _hotkeyKeys.FirstOrDefault(x => x.StartsWith(prefix))?.Substring(prefix.Length);

            NewHotkeyCmbBox.Text = line;
        }

        private void SaveHotKey(object sender, SelectionChangedEventArgs e)
        {
            _oldSystemText = NewHotkeyCmbBox.Text;

            if (OriginalHotkey.Text != "")
            {
                //string[] text = File.ReadAllLines("$SacredUtils\\conf\\hk.setg.txt", Encoding.UTF8);

                string hotKey = OriginalHotkey.SelectedItem as string;

                string key = (sender as ComboBox)?.SelectedItem as string;

                bool exists = false;

                for (int i = 0; i < _hotkeyKeys.Length; i++)
                {
                    if (_hotkeyKeys[i].Contains($" = {key}"))
                    {
                        if (hotKey != null && !_hotkeyKeys[i].Contains(hotKey))
                        {
                            exists = true;

                            NewHotkeyCmbBox.SelectedItem = _oldSystemText;
                        }
                    }
                }

                for (int i = 0; i < _hotkeyKeys.Length; i++)
                {
                    if (exists == false)
                    {
                        if (_hotkeyKeys[i].Contains($"{hotKey} = "))
                        {
                            _hotkeyKeys[i] = $"{hotKey} = {key}";

                            File.WriteAllLines("$SacredUtils\\conf\\hk.setg.txt", _hotkeyKeys);

                            break;
                        }
                    }
                }
            }
        }

        #endregion

        #region DefaultHotKeySettingsCode

        private void SetHotkeyValue(object sender, SelectionChangedEventArgs e)
        {
            if (NewHotkeyCmbBox.SelectedValue.ToString() == "Q")
            {
                HotkeySettings.GameHotkeySettings.KeyQ = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "W")
            {
                HotkeySettings.GameHotkeySettings.KeyW = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "E")
            {
                HotkeySettings.GameHotkeySettings.KeyE = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "R")
            {
                HotkeySettings.GameHotkeySettings.KeyR = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "T")
            {
                HotkeySettings.GameHotkeySettings.KeyT = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "Y")
            {
                HotkeySettings.GameHotkeySettings.KeyY = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "U")
            {
                HotkeySettings.GameHotkeySettings.KeyU = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "I")
            {
                HotkeySettings.GameHotkeySettings.KeyI = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "O")
            {
                HotkeySettings.GameHotkeySettings.KeyO = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "P")
            {
                HotkeySettings.GameHotkeySettings.KeyP = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "A")
            {
                HotkeySettings.GameHotkeySettings.KeyA = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "S")
            {
                HotkeySettings.GameHotkeySettings.KeyS = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "D")
            {
                HotkeySettings.GameHotkeySettings.KeyD = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "F")
            {
                HotkeySettings.GameHotkeySettings.KeyF = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "G")
            {
                HotkeySettings.GameHotkeySettings.KeyG = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "H")
            {
                HotkeySettings.GameHotkeySettings.KeyH = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "J")
            {
                HotkeySettings.GameHotkeySettings.KeyJ = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "K")
            {
                HotkeySettings.GameHotkeySettings.KeyK = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "L")
            {
                HotkeySettings.GameHotkeySettings.KeyL = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "Z")
            {
                HotkeySettings.GameHotkeySettings.KeyZ = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "X")
            {
                HotkeySettings.GameHotkeySettings.KeyX = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "C")
            {
                HotkeySettings.GameHotkeySettings.KeyC = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "V")
            {
                HotkeySettings.GameHotkeySettings.KeyV = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "B")
            {
                HotkeySettings.GameHotkeySettings.KeyB = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "N")
            {
                HotkeySettings.GameHotkeySettings.KeyN = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "M")
            {
                HotkeySettings.GameHotkeySettings.KeyM = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "L")
            {
                HotkeySettings.GameHotkeySettings.KeyL = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "Space")
            {
                HotkeySettings.GameHotkeySettings.KeySpace = OriginalHotkey.SelectedValue.ToString();
            }

            if (NewHotkeyCmbBox.SelectedValue.ToString() == "None")
            {
                HotkeySettings.GameHotkeySettings.KeySpace = OriginalHotkey.SelectedValue.ToString();
            }
        }

        private void GetSelection()
        {
            switch (NewHotkeyCmbBox.SelectedItem)
            {
                case "Q":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyQ;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "W":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyW;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "E":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyE;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "R":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyR;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "T":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyT;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "Y":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyY;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "U":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyU;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "I":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyI;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "O":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyO;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "P":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyP;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "A":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyA;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "S":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyS;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "D":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyD;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "F":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyF;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "G":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyG;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "H":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyH;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "J":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyJ;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "K":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyK;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "L":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyL;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "Z":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyZ;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "X":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyX;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "C":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyC;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "V":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyV;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "B":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyB;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "N":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyN;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "M":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeyM;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                case "Space":
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    OriginalHotkey.SelectedItem = HotkeySettings.GameHotkeySettings.KeySpace;
                    OriginalHotkey.SelectionChanged += SetHotkeyValue;
                    break;
                default:
                    OriginalHotkey.SelectionChanged -= SetHotkeyValue;
                    break;
            }
        }

        #endregion
    }
}
