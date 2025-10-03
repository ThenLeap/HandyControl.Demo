using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HandyControl.Demo.Views;
using HandyControl.Controls;
using HandyControl.Data;
using MessageBox = HandyControl.Controls.MessageBox;
using Window = System.Windows.Window;

namespace HandyControl.Demo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
    {
        private bool isFullScreen = false;
        private WindowState lastWindowState;
        private WindowStyle lastWindowStyle;

        public MainWindow()
        {
            InitializeComponent();
            LoadPage("Dashboard");
        }

        private void SideMenu_SelectionChanged(object? sender, FunctionEventArgs<object> functionEventArgs)
        {
            var sideMenuItem = functionEventArgs.Info as SideMenuItem;
            if (sideMenuItem?.Tag != null)
            {
                LoadPage(sideMenuItem.Tag.ToString());
            }
        }

        private void LoadPage(string? pageTag)
        {
            UserControl page = pageTag switch
            {
                "Dashboard" => new DashboardPage(),
                "Users" => new UsersPage(),
                "Analytics" => new AnalyticsPage(),
                "Reports" => new ReportsPage(),
                "Settings" => new SettingsPage(),
                "BasicSettings" => new BasicSettingsPage(),
                "Permissions" => new PermissionsPage(),
                "Logs" => new LogsPage(),
                _ => new DashboardPage()
            };

            ContentContainer.Content = page;
        }

        private void FullScreen_Click(object sender, RoutedEventArgs e)
        {
            if (!isFullScreen)
            {
                lastWindowState = WindowState;
                lastWindowStyle = WindowStyle;
                
                WindowState = WindowState.Normal;
                WindowStyle = WindowStyle.None;
                WindowState = WindowState.Maximized;
                
                isFullScreen = true;
                Growl.Info("已进入全屏模式，按 ESC 退出");
            }
            else
            {
                ExitFullScreen();
            }
        }

        private void ExitFullScreen()
        {
            WindowStyle = lastWindowStyle;
            WindowState = lastWindowState;
            isFullScreen = false;
        }

        protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Key == System.Windows.Input.Key.Escape && isFullScreen)
            {
                ExitFullScreen();
            }
        }
    }