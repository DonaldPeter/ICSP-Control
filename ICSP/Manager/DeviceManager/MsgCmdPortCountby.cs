﻿using System.Linq;

using ICSP.Constants;
using ICSP.Extensions;
using ICSP.Logging;

namespace ICSP.Manager.DeviceManager
{
  /// <summary>
  /// This message is the response from a master to the Request Port Count message above.
  /// It is sent by a device upon reporting if the device has more than one port.
  /// </summary>
  [MsgCmd(DeviceManagerCmd.PortCountBy)]
  public class MsgCmdPortCountBy : ICSPMsg
  {
    public const int MsgCmd = DeviceManagerCmd.PortCountBy;

    private MsgCmdPortCountBy()
    {
    }

    public MsgCmdPortCountBy(ICSPMsgData msg) : base(msg)
    {
      if(msg.Data.Length > 0)
      {
        Device = msg.Data.GetBigEndianInt16(0);

        System = msg.Data.GetBigEndianInt16(2);

        PortCount = msg.Data.GetBigEndianInt16(4);
      }
    }

    public static ICSPMsg CreateRequest(AmxDevice source, ushort device, ushort system, ushort portCount)
    {
      var lDest = new AmxDevice(0, 0, source.System);

      var lRequest = new MsgCmdPortCountBy();

      lRequest.Device = device;
      lRequest.System = system;
      lRequest.PortCount = portCount;

      Logger.LogDebug(false, "MsgCmdPortCountBy.CreateRequest: Device={0:l}, System={1}, PortCount={2}", lRequest.Device, lRequest.System, lRequest.PortCount);

      var lData = ArrayExtensions.Int16ToBigEndian(device)
        .Concat(ArrayExtensions.Int16ToBigEndian(system))
        .Concat(ArrayExtensions.Int16ToBigEndian(portCount)).ToArray();

      return lRequest.Serialize(lDest, source, MsgCmd, lData);
    }

    /// <summary>
    /// Unsigned 16-bit value.
    /// </summary>
    public ushort Device { get; private set; }

    /// <summary>
    /// Unsigned 16-bit value.
    /// </summary>
    public ushort System { get; private set; }

    /// <summary>
    /// Unsigned 16-bit value.
    /// </summary>
    public ushort PortCount { get; set; }

    protected override void WriteLogExtended()
    {
      Logger.LogDebug(false, "{0:l} Device   : {1:00000}", GetType().Name, Device);
      Logger.LogDebug(false, "{0:l} System   : {1}", GetType().Name, System);
      Logger.LogDebug(false, "{0:l} PortCount: {1}", GetType().Name, PortCount);
    }
  }
}
