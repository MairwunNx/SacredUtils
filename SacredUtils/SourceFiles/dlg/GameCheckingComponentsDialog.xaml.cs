using SacredUtils.resources.arr;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using static SacredUtils.Logger;

namespace SacredUtils.resources.dlg
{
    public partial class GameCheckingComponentsDialog
    {
        public List<string> FindedFilesList = new List<string>();
        public List<string> LinksFilesList = new List<string>();
        public List<string> DownloadNeedFilesList = new List<string>();
        public List<string> HashesFilesList = new List<string>();
        public List<string> BreakedFilesList = new List<string>();
        public List<string> RepairedFilesList = new List<string>();
        public List<string> WholeFilesList = new List<string>();

        public GameCheckingComponentsDialog() => InitializeComponent();

        public void CheckComponents()
        {
            Task.Run(() =>
            {
                Log.Info("=============== LOADED VERIFIABLE COMPONENTS ===============");

                foreach (string s in ArraySacredGameComponentFiles.Files)
                {
                    Log.Info($"Component name \\ patch: {s.Remove(s.IndexOf(' '))}");
                }

                Log.Info("=================== LOADED CHECKING FILES ==================");

                foreach (string s in ArraySacredGameComponentFiles.Files)
                {
                    if (File.Exists(s.Remove(s.IndexOf(' '))))
                    {
                        string[] link = s.Split('|');

                        Log.Info($"Component found \\ exists: {s.Remove(s.IndexOf(' '))}");

                        FindedFilesList.Add(s.Remove(s.IndexOf(' ')));
                        LinksFilesList.Add(link[1].Replace(" ", ""));
                    }
                    else
                    {
                        Log.Info($"Component not found: {s.Remove(s.IndexOf(' '))}");
                    }
                }

                if (FindedFilesList.Count != 0)
                {
                    Log.Info("=================== CALCULATING MD5 FILES ==================");

                    foreach (string s in FindedFilesList.ToArray())
                    {
                        using (MD5 md5 = MD5.Create())
                        {
                            using (FileStream stream = File.OpenRead(s))
                            {
                                byte[] hash = md5.ComputeHash(stream);

                                string md5Hash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();

                                Log.Info($"Component name \\ md5: {s} \\ {md5Hash}");

                                HashesFilesList.Add(md5Hash);
                            }
                        }
                    }

                    Log.Info("===================== COMPARE MD5 FILES ====================");

                    WebClient wc = new WebClient();

                    string sw =
                        wc.DownloadString(
                            "https://drive.google.com/uc?export=download&id=1k1DUXNHcnRqh03IJGCYfQ4zP6EbgyPAh");

                    for (int i = 0; i < HashesFilesList.Count; i++)
                    {
                        if (!sw.Substring(sw.IndexOf("\n", StringComparison.Ordinal)).Contains(HashesFilesList[i]))
                        {
                            Log.Warn($"Component {FindedFilesList.ToArray()[i]} has different md5 ({HashesFilesList[i]}) hash!");

                            BreakedFilesList.Add(FindedFilesList.ToArray()[i]);

                            DownloadNeedFilesList.Add(LinksFilesList.ToArray()[i]);
                        }
                        else
                        {
                            Log.Info($"Component {FindedFilesList.ToArray()[i]} has normal md5 hash!");

                            WholeFilesList.Add(FindedFilesList.ToArray()[i]);
                        }
                    }
                }

                if (BreakedFilesList.Count != 0)
                {
                    Log.Info("=================== GETTED BREAKED FILES ===================");

                    foreach (string component in BreakedFilesList.ToArray())
                    {
                        Log.Info($"Breaked component: {component}");
                    }
                }

                if (WholeFilesList.Count != 0)
                {
                    Log.Info("==================== GETTED NORMAL FILES ===================");

                    foreach (string component in WholeFilesList.ToArray())
                    {
                        Log.Info($"Not breaked component: {component}");
                    }
                }

                if (BreakedFilesList.Count == 0)
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Send, new ThreadStart(() =>
                    {
                        CheckingComponents.Visibility = Visibility.Hidden;
                        NotFoundErrors.Visibility = Visibility.Visible;

                        BaseDialog.CloseOnClickAway = true;
                    }));
                }
                else
                {
                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Send, new ThreadStart(() =>
                    {
                        CheckingComponents.Visibility = Visibility.Hidden;
                        RestoringComponents.Visibility = Visibility.Visible;
                    }));

                    WebClient wc = new WebClient();

                    int num = 0;

                    foreach (string ss in BreakedFilesList)
                    {
                        Log.Info($"Downloading file {ss} from {DownloadNeedFilesList[num]} ...");

                        wc.DownloadFileTaskAsync(DownloadNeedFilesList[num], ss).Wait();

                        RepairedFilesList.Add(ss);

                        num++;
                    }

                    Application.Current.Dispatcher.Invoke(DispatcherPriority.Send, new ThreadStart(() =>
                    {
                        RestoringComponents.Visibility = Visibility.Hidden;
                        RepairSuccess.Visibility = Visibility.Visible;

                        BaseDialog.CloseOnClickAway = true;
                    }));
                }

                Log.Info("======================= REPAIRED FILES =====================");

                foreach (string s in RepairedFilesList)
                {
                    Log.Info($"Repaired component: {s}");
                }

                Log.Info("=================== REPAIR COMPONENTS DONE =================");
            });
        }
    }
}
