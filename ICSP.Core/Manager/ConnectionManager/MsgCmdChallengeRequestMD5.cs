﻿using System;

using ICSP.Core.Constants;
using ICSP.Core.Extensions;
using ICSP.Core.Logging;

namespace ICSP.Core.Manager.ConnectionManager
{
  [MsgCmd(ConnectionManagerCmd.ChallengeRequestMD5)] // MD5-Challenge
  public class MsgCmdChallengeRequestMD5 : ICSPMsg
  {
    public const int MsgCmd = ConnectionManagerCmd.ChallengeRequestMD5;

    protected MsgCmdChallengeRequestMD5()
    {
    }

    public MsgCmdChallengeRequestMD5(byte[] buffer) : base(buffer)
    {
      if(Data.Length > 0)
      {
        Challenge = Data.Range(0, 4);
      }
    }
    
    public override ICSPMsg FromData(byte[] bytes)
    {
      return new MsgCmdChallengeRequestMD5(bytes);
    }

    public static ICSPMsg CreateRequest(AmxDevice dest, AmxDevice source, byte[] challenge)
    {
      var lRequest = new MsgCmdChallengeRequestMD5
      {
        Challenge = challenge
      };

      return lRequest.Serialize(dest, source, MsgCmd, challenge);
    }
    
    public byte[] Challenge { get; private set; }

    protected override void WriteLogExtended()
    {
      Logger.LogDebug(false, "{0:l} ChallengeData: 0x: {1:l}", GetType().Name, BitConverter.ToString(Challenge).Replace("-", " "));
    }
  }
}
