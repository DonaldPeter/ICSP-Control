﻿using System.Linq;

using ICSP.Core.Constants;
using ICSP.Core.Extensions;
using ICSP.Core.Logging;

namespace ICSP.Core.Manager.DeviceManager
{
  /// <summary>
  /// This message is the response from a master to the Request Output Channel Count message.
  /// It is sent by a device/port upon reporting if the device has more than 256 channels.
  /// </summary>
  [MsgCmd(DeviceManagerCmd.OutputChannelCount)]
  public class MsgCmdOutputChannelCount : ICSPMsg
  {
    public const int MsgCmd = DeviceManagerCmd.OutputChannelCount;

    private MsgCmdOutputChannelCount()
    {
    }

    public MsgCmdOutputChannelCount(byte[] buffer) : base(buffer)
    {
      if(Data.Length > 0)
      {
        Device = AmxDevice.FromDPS(Data.Range(0, 6));

        Count = Data.GetBigEndianInt16(6);
      }
    }

    public override ICSPMsg FromData(byte[] bytes)
    {
      return new MsgCmdOutputChannelCount(bytes);
    }

    public static ICSPMsg CreateRequest(AmxDevice dest, AmxDevice source, ushort count)
    {
      var lRequest = new MsgCmdOutputChannelCount
      {
        Device = source,
        Count = count
      };

      var lData = source.GetBytesDPS().Concat(ArrayExtensions.Int16ToBigEndian(count)).ToArray();

      return lRequest.Serialize(dest, source, MsgCmd, lData);
    }

    public AmxDevice Device { get; set; }

    public ushort Count { get; set; }

    protected override void WriteLogExtended()
    {
      Logger.LogDebug(false, "{0:l} Device: {1:l}", GetType().Name, Device);
      Logger.LogDebug(false, "{0:l} Count : {1}", GetType().Name, Count);
    }
  }
}
