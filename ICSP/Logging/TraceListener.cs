﻿using Serilog;

namespace ICSP.Logging
{
  public class TraceListener : System.Diagnostics.TraceListener
  {
    public override void Write(string message)
    {
      Log.Verbose(message);
    }

    public override void WriteLine(string message)
    {
      Log.Verbose(message);
    }
  }
}