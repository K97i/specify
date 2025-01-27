﻿using System.Windows;
using System.Windows.Controls;
using System;
using System.Windows.Media;

namespace specify_client;

/// <summary>
/// Interaction logic for StartButtons.xaml
/// </summary>
public partial class StartButtons : Page
{
    public StartButtons()
    {
        InitializeComponent();
    }

    private void SettingsOn(object sender, RoutedEventArgs e)
    {
        MainText.Visibility = Visibility.Hidden;
        SettingsToggles.Visibility = Visibility.Visible;
    }

    private void SettingsOff(object sender, RoutedEventArgs e)
    {
        SettingsToggles.Visibility = Visibility.Hidden;
        MainText.Visibility = Visibility.Visible;
    }

    private void UploadOff(object sender, RoutedEventArgs e)
    {
        Settings.DontUpload = true;
        WarningTextBlock.Visibility = Visibility.Visible;
    }

    private void UploadOn(object sender, RoutedEventArgs e)
    {
        Settings.DontUpload = false;
        WarningTextBlock.Visibility = Visibility.Hidden;
    }

    private void UsernameOn(object sender, RoutedEventArgs e)
    {
        Settings.RedactUsername = true;
        Settings.RedactOneDriveCommercial = true;
    }

    private void UsernameOff(object sender, RoutedEventArgs e)
    {
        Settings.RedactUsername = false;
        Settings.RedactOneDriveCommercial = false;
    }

    private void SerialNumberOn(object sender, RoutedEventArgs e)
    {
        Settings.RedactSerialNumber = true;
    }

    private void SerialNumberOff(object sender, RoutedEventArgs e)
    {
        Settings.RedactSerialNumber = false;
    }

    private void DebugLogToggleOn(object sender, RoutedEventArgs e)
    {
        Settings.EnableDebug = true;
    }

    private void DebugLogToggleOff(object sender, RoutedEventArgs e)
    {
        Settings.EnableDebug = false;
    }

    private void UnlockUploadOn(object sender, RoutedEventArgs e)
    {
        DontUploadCheckbox.IsEnabled = true;
        DontUploadCheckbox.Foreground = new SolidColorBrush(Colors.White);
        WarningTextBlock.Visibility = Visibility.Visible;
    }
    private void UnlockUploadOff(object sender, RoutedEventArgs e)
    {
        DontUploadCheckbox.IsEnabled = false;
        DontUploadCheckbox.Foreground = new SolidColorBrush(Colors.Gray);
        WarningTextBlock.Visibility = Visibility.Hidden;
    }
    private async void StartAction(object sender, RoutedEventArgs e)
    {
        try
        {
            var main = App.Current.MainWindow as Landing;
            await main.RunApp();
        }
        catch (Exception ex)
        {
            System.IO.File.WriteAllText(@"specify_hardfail.log", $"{ex}");
            System.Environment.Exit(-1);
        }
    }
}