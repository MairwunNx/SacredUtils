#pragma checksum "..\..\App.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "23C5C87FC2A8EBA30AD8C1C004C69ED2FCA9D16C"

using System;
using log4net;
using System.Windows;
using System.Diagnostics;
using System.Windows.Ink;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shell;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Navigation;
using System.Windows.Automation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.Animation;
using System.Windows.Controls.Primitives;
using System.Windows.Media.TextFormatting;

namespace SacredUtils
{
    public partial class App : System.Windows.Application
    {
        private static readonly ILog Log = LogManager.GetLogger("LOGGER");

        private bool _contentLoaded;
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            SacredUtils.Resources.Logger.Logger.InitLogger();

            Log.Info("Инициализируем компоненты приложения SacredUtils.");

            if (_contentLoaded) { return; } _contentLoaded = true;

            Log.Info("Компоненты SacredUtils были загружены без ошибок.");
            
            Log.Info("Задаем программе новую точку входа SacredUtils (MainWindow.xaml).");

            #line 4 "..\..\App.xaml"
            this.StartupUri = new System.Uri("MainWindow.xaml", System.UriKind.Relative);

            Log.Info("Новая точка входа в программу была установлена без ошибок.");

            Log.Info("Инициализируем компоненты из app.xaml (Стили, шрифты и т.д).");
            
            #line default
            #line hidden
            System.Uri resourceLocater = new System.Uri("/SacredUtils;component/app.xaml", System.UriKind.Relative);

            Log.Info("Инициализация компонентов из app.xaml завершена без ошибок.");

            Log.Info("Загружаем компоненты из app.xaml (Стили, шрифты и т.д)");
            
            #line 1 "..\..\App.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

            Log.Info("Загрузка компонентов из app.xaml завершена без ошибок.");
            
            #line default
            #line hidden
        }
        
        [System.STAThreadAttribute()]
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public static void Main()
        {
            Log.Info("Подготавливаем приложение к загрузке компонентов.");

            SacredUtils.App app = new SacredUtils.App();

            Log.Info("Подготовление приложения к загрузке завершена без ошибок.");

            Log.Info("Запускаем метод инициализации компонентов SacredUtils.");

            app.InitializeComponent();

            Log.Info("Запускаем Windows Presentation Foundation SacredUtils.");

            app.Run();
        }
    }
}

