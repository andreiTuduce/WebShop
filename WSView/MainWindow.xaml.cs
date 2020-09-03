﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using WebShop.Infrastructure;
using WebShop.Manager;

namespace WSView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TestClass testClass;

        public MainWindow()
        {
            InitializeComponent();
            testClass = new TestClass();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            testClass.TestMethod();
        }
    }
}