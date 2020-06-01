﻿namespace ICSP.WebProxy.Configuration
{
  public class ProxyConnectionConfig
  {
    public string LocalHost { get; set; }

    public string RemoteHost { get; set; }

    public ushort RemotePort { get; set; }

    public ushort Device { get; set; }

    public ushort PortCount { get; set; } = 1;

    public string DeviceName { get; set; }

    public bool Enabled { get; set; } = true;

    public string Converter { get; set; }    
  }
}