﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace Instagram.Tinh_nang
{
    public class Tinhnangnuoiclone
    {
        public string thoigian;
        public string noidung;
        public bool hoanthanh;
        
        public Tinhnangnuoiclone(string thoigian, string noidung)
        {
            this.thoigian = thoigian;
            this.noidung = noidung;
            this.hoanthanh = false;
        }
        
        
        
    }
}