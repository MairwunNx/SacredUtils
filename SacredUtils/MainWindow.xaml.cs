using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Castle.Core.Logging;
using FluentFTP;
using NLog;
using NLog.Targets;
using SharpConfig;


namespace SacredUtils
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
