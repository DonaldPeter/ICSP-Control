﻿using System.Linq;

using ICSP.Constants;
using ICSP.Extensions;
using ICSP.Logging;

namespace ICSP.Manager.DeviceManager
{
  /// <summary>
  /// The Request Level Value message is generated by the master to request the level value of a level.
  /// </summary>
  [MsgCmd(DeviceManagerCmd.RequestLevelValue)]
  public class MsgCmdRequestLevelValue : ICSPMsg
  {
    public const int MsgCmd = DeviceManagerCmd.RequestLevelValue;

    private MsgCmdRequestLevelValue()
    {
    }

    public MsgCmdRequestLevelValue(ICSPMsgData msg) : base(msg)
    {
      if(msg.Data.Length > 0)
      {
        Device = AmxDevice.FromDPS(msg.Data.Range(0, 6));

        Level = msg.Data.GetBigEndianInt16(6);
      }
    }

    public static ICSPMsg CreateRequest(AmxDevice source, AmxDevice device, ushort level)
    {
      var lRequest = new MsgCmdRequestLevelValue();

      lRequest.Device = device;
      lRequest.Level = level;

      var lData = device.GetBytesDPS().
        Concat(ArrayExtensions.Int16ToBigEndian(level)).
        ToArray();

      return lRequest.Serialize(device, source, MsgCmd, lData);
    }

    public AmxDevice Device { get; set; }

    public ushort Level { get; set; }

    protected override void WriteLogExtended()
    {
      Logger.LogDebug(false, "{0:l} Device: {1:l}", GetType().Name, Device);
      Logger.LogDebug(false, "{0:l} Level : {1}", GetType().Name, Level);
    }
  }
}
