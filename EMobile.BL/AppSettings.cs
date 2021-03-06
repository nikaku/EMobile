﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EMobile.BL
{
    public class AppSettings
    {

        public string Secret { get; set; }
        public string SqlServerHostName { get; set; }
        public string SqlServerPost { get; set; }
        public string SqlServerCatalog { get; set; }
        public string SqlServerUser { get; set; }
        public string SqlServerPassword { get; set; }
        public bool EnableSSL { get; set; }
        public string AdminPassword { get; set; }
        public string MinioServerIp { get; set; }
        public string MinioServerPort { get; set; }
        public string MinioAccesKey { get; set; }
        public string MinioSecetKey { get; set; }
    }
}
