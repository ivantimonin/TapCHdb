﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TAP_DB
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDEyNTgzQDMxMzgyZTM0MmUzMGhneHdlSUpWSUgwTjE2Z1NiNDNzbjRyUlhlbGpOeFZwa3RnYXJYaHoybkE9");
        }
    }
}