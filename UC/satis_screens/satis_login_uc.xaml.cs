﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
using WpfApp1.Class;
using WpfApp1.Entity;
using WpfApp1.UC.urunler_uc_screens;

namespace WpfApp1.UC
{
    /// <summary>
    /// satis_login_uc.xaml etkileşim mantığı
    /// </summary>
    public partial class satis_login_uc : UserControl
    {
        private Context db;
        private Grid x;
        private satis uc;
        public satis_login_uc(Context datab, Grid x,satis satis)
        {
            InitializeComponent();
            this.db = datab;
            this.x = x;
            this.uc = satis;
        }

        private void satisuc_login_username_tb_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            login_page_user.Text = "";
            login_page_user.Foreground = new SolidColorBrush(Colors.Black);
            login_page_user.TextAlignment = TextAlignment.Left;
            login_page_user.FontSize = 18;
            login_page_user.Height = 35;
        }

        private void satisuc_login_username_tb_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (login_page_user.Text == "" || login_page_user.Text == "Kullanıcı Adı Veya Parola Hatalı")

            {
                login_page_user.Text = "Kullanıcı Adı...";
                login_page_user.Foreground = new SolidColorBrush(Colors.LightGray);
                login_page_user.TextAlignment = TextAlignment.Center;
                login_page_user.FontSize = 18;
            }
        }
        private void satisuc_login_pass_tb_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            login_page_pass.Text = "";
            login_page_pass.Foreground = new SolidColorBrush(Colors.Black);
            login_page_pass.TextAlignment = TextAlignment.Left;
            login_page_pass.FontSize = 18;
            login_page_pass.Height = 35;
        }
        private void satisuc_login_pass_tb_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (login_page_pass.Text == "" || login_page_pass.Text == "Kullanıcı Adı Veya Parola Hatalı")
            {
                login_page_pass.Text = "Şifre...";
                login_page_pass.Foreground = new SolidColorBrush(Colors.LightGray);
                login_page_pass.TextAlignment = TextAlignment.Center;
                login_page_pass.FontSize = 18;

            }
        }      
        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            var q = from p in db.Kullanıcılar where p.KullaniciAdi == login_page_user.Text && p.pass == login_page_pass.Text select p;           
            if (q.Any()){
                Kullanıcılar a = q.First();
                uc.kullanici = a;
                uc.uc = uc;
                Class1.uc_ekle(x,uc);

            }
            else{
             
                login_page_user.Text = "Kullanıcı Adı Veya Parola Hatalı";
                login_page_user.Foreground = new SolidColorBrush(Colors.Red);
                login_page_user.FontSize = 14;
                login_page_user.Height = 50;

                login_page_pass.Text = "Kullanıcı Adı Veya Parola Hatalı";
                login_page_pass.Foreground = new SolidColorBrush(Colors.Red);
                login_page_pass.FontSize = 14;
                login_page_pass.Height = 50;
                    
            }
                
        }
        private void register_btn_Click(object sender, RoutedEventArgs e)
        {
            Class1.uc_ekle(x, new satis_register_uc(db,x,uc));
        }
    }
}

