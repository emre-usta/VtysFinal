﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.UC;
using WpfApp1.Class;
using WpfApp1.Entity;
using Context = WpfApp1.Entity.Context;
using System.Security.Cryptography.X509Certificates;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Context db = new Context();
        private static satis uc;
        public MainWindow()
        {
            InitializeComponent();
            uc = new satis(db, panelDesktop);
        }

        private void btn_kapat_click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void btn_boyut_click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }
        private void btn_simgedrm_click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btn_satis_mainmenu_Click(object sender, RoutedEventArgs e)
        {
           WpfApp1.Class.Class1.uc_ekle(panelDesktop, new satis_login_uc(db,panelDesktop,uc));
        }

        private void btn_urunler_mainmenu_Click(object sender, RoutedEventArgs e)
        {
            WpfApp1.Class.Class1.uc_ekle(panelDesktop, new urunler(db,panelDesktop));
        }

        private void btn_raporlar_mainmenu_Click(object sender, RoutedEventArgs e)
        {
            WpfApp1.Class.Class1.uc_ekle(panelDesktop, new raporlar_uc(db,panelDesktop));
        }
        private void btn_musteriler_mainmenu_Click(object sender, RoutedEventArgs e)
        {
            WpfApp1.Class.Class1.uc_ekle(panelDesktop, new musteriler_uc(db,panelDesktop));
        }

        private void btn_firmalar_mainmenu_Click(object sender, RoutedEventArgs e)
        {
            WpfApp1.Class.Class1.uc_ekle(panelDesktop, new firmalar(db,panelDesktop));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {      
            Context a = new Context();
            a.Database.CreateIfNotExists();
        }
    
    }
}
