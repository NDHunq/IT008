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

namespace Instagram.Tinh_nang
{
    /// <summary>
    /// Interaction logic for Follow.xaml
    /// </summary>
    public partial class Follow : UserControl
    {
        public Follow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string a = "\n" + tb1.Text;
            Ds.Text += a;
        }
    }
}