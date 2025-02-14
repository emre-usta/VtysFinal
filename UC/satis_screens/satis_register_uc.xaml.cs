﻿using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WpfApp1.UC
{
    /// <summary>
    /// satis_register_uc.xaml etkileşim mantığı
    /// </summary>
    public partial class satis_register_uc : UserControl
    {
        private Context db;
        private Grid x;
        private satis uc;
        public satis_register_uc(Context datab,Grid x,satis uc)
        {
            InitializeComponent();
            this.db = datab;
            this.x = x;
            this.uc = uc;
        }

        private void satisuc_login_username_tb_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            register_page_user.Text = "";
            register_page_user.Foreground = new SolidColorBrush(Colors.Black);
            register_page_user.TextAlignment = TextAlignment.Left;
            register_page_user.FontSize = 18;
            register_page_user.Height = 35;
        }

        private void satisuc_login_username_tb_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (register_page_user.Text == "" || register_page_user.Text == "Bu Alan Boş Bırakılamaz")

            {
                register_page_user.Text = "Kullanıcı Adı...";
                register_page_user.Foreground = new SolidColorBrush(Colors.LightGray);
                register_page_user.TextAlignment = TextAlignment.Center;
                register_page_user.FontSize = 18;
            }

        }
        private void satisuc_login_pass_tb_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            register_page_pass.Text = "";
            register_page_pass.Foreground = new SolidColorBrush(Colors.Black);
            register_page_pass.TextAlignment = TextAlignment.Left;
            register_page_pass.FontSize = 18;
            register_page_pass.Height = 35;
        }
        private void satisuc_login_pass_tb_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (register_page_pass.Text == "" || register_page_pass.Text == "Bu Alan Boş Bırakılamaz")
            {
                register_page_pass.Text = "Şifre...";
                register_page_pass.Foreground = new SolidColorBrush(Colors.LightGray);
                register_page_pass.TextAlignment = TextAlignment.Center;
                register_page_pass.FontSize = 18;

            }
        }

        private void register_btn_Click(object sender, RoutedEventArgs e)
        {
            if(register_page_user.Text == "" || register_page_user.Text == "Kullanıcı Adı..." || register_page_user.Text == "Bu Alan Boş Bırakılamaz" || register_page_pass.Text == "" ||register_page_pass.Text=="Şifre..."||register_page_pass.Text== "Bu Alan Boş Bırakılamaz")
            {
                if (register_page_pass.Text == "" || register_page_pass.Text == "Şifre...") { register_page_pass.Height = 55; register_page_pass.Text = "Bu Alan Boş Bırakılamaz"; register_page_pass.Foreground = new SolidColorBrush(Colors.Red); }
                if (register_page_user.Text == "" || register_page_user.Text == "Kullanıcı Adı..."){register_page_user.Height= 55; register_page_user.Text = "Bu Alan Boş Bırakılamaz";register_page_user.Foreground = new SolidColorBrush(Colors.Red);}
            }
            else {
                Kullanıcılar kullanici = new Kullanıcılar
                {
                    KullaniciAdi = register_page_user.Text,
                    pass = register_page_pass.Text
                };
                db.Kullanıcılar.Add(kullanici);
                db.SaveChanges();

                MessageBox.Show("Kayıt Oluşturuldu");

                Class1.uc_ekle(x, new satis_login_uc(db,x,uc));

            }
        }
    }
}
