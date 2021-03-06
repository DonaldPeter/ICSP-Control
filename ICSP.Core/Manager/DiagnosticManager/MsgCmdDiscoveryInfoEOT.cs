﻿
using ICSP.Core.Constants;

namespace ICSP.Core.Manager.DiagnosticManager
{
  /// <summary>
  /// Unknown: (Probably IP Device Discovery -> EOT)
  /// </summary>
  [MsgCmd(DiagnosticManagerCmd.DiscoveryInfoEOT)]
  public class MsgCmdDiscoveryInfoEOT : ICSPMsg
  {
    public const int MsgCmd = DiagnosticManagerCmd.DiscoveryInfoEOT;

    private MsgCmdDiscoveryInfoEOT()
    {
    }

    public MsgCmdDiscoveryInfoEOT(byte[] buffer) : base(buffer)
    {
    }

    public override ICSPMsg FromData(byte[] bytes)
    {
      return new MsgCmdDiscoveryInfoEOT(bytes);
    }

    public static ICSPMsg CreateRequest(AmxDevice dest, AmxDevice source)
    {
      var lRequest = new MsgCmdDiscoveryInfoEOT();
      
      return lRequest.Serialize(dest, source, MsgCmd, null);
    }
    
    protected override void WriteLogExtended()
    {
    }
  }
}