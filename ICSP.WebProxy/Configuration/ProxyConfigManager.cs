﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using Microsoft.AspNetCore.Http;

namespace ICSP.WebProxy.Configuration
{
  public static class ProxyConfigManager
  {
    private static readonly Regex RegexUrl = new Regex(@"^((?<scheme>[^:/?#]+):(?=//))?(//)?(((?<login>[^:]+)(?::(?<password>[^@]+)?)?@)?(?<host>[^@/?#:]*)(?::(?<port>\d+)?)?)?(?<path>[^?#]*)(\?(?<query>[^#]*))?(#(?<fragment>.*))?", RegexOptions.None);

    public static void Configure(this ProxyConfig config)
    {
      if(config == null)
        throw new ArgumentNullException(nameof(config));

      if(config.Connections == null)
        config.Connections = new Dictionary<string, ProxyConnectionConfig>();

      if(config.Connections.Count == 0)
      {
        //var lDefaultConfig = new ProxyConnectionConfig()
        //{
        //  RemoteHost = "localhost",
        //  RemotePort = ICSPClient.DefaultPort
        //};

        //config.Connections.Add(lDefaultConfig);
      }
    }

    public static void Save(this ProxyConfig config)
    {
      if(config == null)
        throw new ArgumentNullException(nameof(config));

      if(config.Connections == null)
        config.Connections = new Dictionary<string, ProxyConnectionConfig>();
    }

    public static ProxyConnectionConfig GetConfig(this ProxyConfig config, HttpContext context)
    {
      var lLocalScheme = context.Request.Scheme;
      var lLocalPort = context.Connection.LocalPort;

      foreach(var item in config.Connections.Values.Where(p => p.Enabled))
      {
        var lMatch = RegexUrl.Match(item.LocalHost);

        if(lMatch.Success)
        {
          var lScheme = lMatch.Groups["scheme"].Value;
          ushort.TryParse(lMatch.Groups["port"].Value, out var lPort);

          if(lPort == 0)
            lPort = 80;

          if(lLocalScheme.Equals(lScheme, StringComparison.OrdinalIgnoreCase) && lLocalPort == lPort)
            return item;
        }
      }

      // First Default ...
      return config.Connections["0"];
    }
  }
}
