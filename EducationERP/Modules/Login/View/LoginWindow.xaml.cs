﻿using System.Windows;
using System.Windows.Input;

namespace EducationERP.Modules.Login.View
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        void MoveWindow(object sender, RoutedEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed) DragMove();
        }
    }
}
