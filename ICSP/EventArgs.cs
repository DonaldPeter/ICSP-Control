﻿using System;
using System.Globalization;
using System.Net;
using System.Net.NetworkInformation;

using ICSP.Manager.ConnectionManager;
using ICSP.Manager.DeviceManager;

namespace ICSP
{
  public sealed class MessageReceivedEventArgs : EventArgs
  {
    public MessageReceivedEventArgs(ICSPMsg message)
    {
      Message = message;
    }

    public ICSPMsg Message { get; private set; }

    public bool Handled { get; set; }
  }

  public abstract class ICSPEventArgs : EventArgs
  {
    public ICSPEventArgs(ICSPMsg message)
    {
      if(message == null)
        throw new ArgumentNullException(nameof(message));

      Message = message;
    }

    public ICSPMsg Message { get; private set; }
  }

  public sealed class BlinkEventArgs : ICSPEventArgs
  {
    public BlinkEventArgs(MsgCmdBlinkMessage message) : base(message)
    {
      HeartbeatTiming = message.HeartbeatTiming;

      LED = message.LED;

      DateTime = message.DateTime;

      Month = (byte)DateTime.Month;
      Day = (byte)DateTime.Day;
      Year = (byte)DateTime.Year;
      Hour = (byte)DateTime.Hour;
      Minute = (byte)DateTime.Minute;
      Second = (byte)DateTime.Second;
      DayOfWeek = DateTime.DayOfWeek;

      OutsideTemperature = message.OutsideTemperature;

      // "Sunday, Aug 27, 2017"
      DateText = DateTime.ToString("dddd, MMM dd, yyyy", new CultureInfo("en-US"));
    }

    /// <summary>
    /// Tenths of seconds between heartbeats
    /// </summary>
    public byte HeartbeatTiming { get; private set; }

    /// <summary>
    /// State of Bus LED and other Status
    /// Bit 0 —Bus LED 0 = OFF, 1 = ON.
    /// Bits 1-6 Reserved.
    /// Bit 7 —Forced Device Unconfigure/Reset
    /// 
    /// The LED byte is a bit field. The LSB (bit 0) indicates the current status of the bus LED.
    /// The MSB(Bit 7) is set when the master initially powers-up/on-line. In response to bit 7 being set, 
    /// the receiving device should place itself in the off-line state, turn all channels off, 
    /// and set all levels to zero(or prepare itself to send status updates as necessary to the master).
    /// The master shall send 3 consecutive blink messages with bit 7 set.
    /// </summary>
    public byte LED { get; private set; }

    public DateTime DateTime { get; private set; }

    /// <summary>
    /// Current Date: Month 1-12 
    /// </summary>
    public byte Month { get; private set; }

    /// <summary>
    /// Current Date: Day 1-31
    /// </summary>
    public byte Day { get; private set; }

    /// <summary>
    /// Current Date: Year 1999-65535
    /// </summary>
    public ushort Year { get; private set; }

    /// <summary>
    /// Current Time: Hour 0-23 
    /// </summary>
    public byte Hour { get; private set; }

    /// <summary>
    /// Current Time: Minute 0-59
    /// </summary>
    public byte Minute { get; private set; }

    /// <summary>
    /// Current Time: Seconds 0-59
    /// </summary>
    public byte Second { get; private set; }

    /// <summary>
    /// Day of Week 0 = Mon, 1 = Tues, ...
    /// </summary>
    public DayOfWeek DayOfWeek { get; private set; }

    /// <summary>
    /// Outside Temperature (if available).
    /// Type: Temp signed 16-bit.
    /// If 0x8000, then temperature is not valid.
    /// </summary>
    public ushort OutsideTemperature { get; private set; }

    /// <summary>
    /// String Formatted as: “Thursday, Jun. 10, 1999”
    /// </summary>
    public string DateText { get; private set; }
  }

  public sealed class ChannelEventArgs : ICSPEventArgs
  {
    public ChannelEventArgs(MsgCmdOutputChannelOn message) : base(message)
    {
      Device = message.Device;

      Channel = message.Channel;

      Enabled = true;
    }

    public ChannelEventArgs(MsgCmdOutputChannelOff message) : base(message)
    {
      Device = message.Device;

      Channel = message.Channel;

      Enabled = false;
    }

    public AmxDevice Device { get; set; }

    public ushort Channel { get; set; }

    public bool Enabled { get; private set; }
  }

  public sealed class PingEventArgs : ICSPEventArgs
  {
    public PingEventArgs(MsgCmdPingRequest message) : base(message)
    {
      Device = message.Device;

      System = message.System;
    }
    
    /// <summary>
    /// Unsigned 16-bit value.
    /// </summary>
    public ushort Device { get; private set; }

    /// <summary>
    /// Unsigned 16-bit value.
    /// </summary>
    public ushort System { get; private set; }
  }
  
  public sealed class DeviceInfoEventArgs : ICSPEventArgs
  {
    public DeviceInfoEventArgs(MsgCmdDeviceInfo message) : base(message)
    {
      Device = message.Device;

      System = message.System;

      DataFlag = message.DataFlag;
      ObjectId = message.ObjectId;
      ParentId = message.ParentId;
      ManufactureId = message.ManufactureId;
      DeviceId = message.DeviceId;
      SerialNumber = message.SerialNumber;
      FirmwareId = message.FirmwareId;
      Version = message.Version;
      Name = message.Name;
      Manufacture = message.Manufacture;

      ExtAddressType = message.ExtAddressType;
      ExtAddressLength = message.ExtAddressLength;
      ExtAddress = message.ExtAddress;

      IPv4Address = message.IPv4Address;
      IpPort = message.IpPort;
      MacAddress = message.MacAddress;
      IPv6Address = message.IPv6Address;
    }
    
    /// <summary>
    /// Unsigned 16-bit value.
    /// </summary>
    public ushort Device { get; set; }

    /// <summary>
    /// Unsigned 16-bit value.
    /// </summary>
    public ushort System { get; set; }

    /// <summary>
    /// 16-bit bit field. 
    /// Bit 0 - If set, this message was generated in 
    /// response to a button press while Identify mode is active.
    /// </summary>
    public ushort DataFlag { get; set; }

    /// <summary>
    /// Unsigned 8-bit value.
    /// </summary>
    public byte ObjectId { get; set; }

    /// <summary>
    /// Unsigned 8-bit value.
    /// </summary>
    public byte ParentId { get; set; }

    /// <summary>
    /// Unsigned 16-bit value.
    /// The Manufacture ID as reported in the Device Info message for ParentID = 0 and ObjectID = 0
    /// </summary>
    public ushort ManufactureId { get; set; }

    /// <summary>
    /// Unsigned 16-bit value.
    /// The Device ID as reported in the Device Info message for ParentID = 0 and ObjectID = 0
    /// </summary>
    public ushort DeviceId { get; set; }

    /// <summary>
    /// 16 bytes of data. Format not defined yet.
    /// </summary>
    public string SerialNumber { get; set; }

    /// <summary>
    ///  Unsigned 16-bit value.
    /// </summary>
    public ushort FirmwareId { get; set; }

    /// <summary>
    /// CHAR array, NULL terminated, containing a 
    /// version string. Generally, in this format: "v1.00\0"
    /// </summary>
    public string Version { get; set; }

    /// <summary>
    /// CHAR array, NULL terminated, containing a model number.
    /// Generally, in this format: "NXC-232\0" (NetLinx Card-RS232)
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// CHAR array, NULL terminated, containing 
    /// String the mfg.'s name. Generally, in this format: "AMX Corp/0"
    /// </summary>
    public string Manufacture { get; set; }

    /// <summary>
    /// 8-bit value. Used to indicate type of extended address to follow.
    /// </summary>
    public ExtAddressType ExtAddressType { get; set; }

    /// <summary>
    /// 8-bit value. Used to indicate length in bytes of extended address to follow
    /// </summary>
    public byte ExtAddressLength { get; set; }

    /// <summary>
    /// Extended Address as indicated by Address Type and Length.
    /// </summary>
    public byte[] ExtAddress { get; set; }

    public IPAddress IPv4Address { get; set; }

    public int IpPort { get; set; }

    public PhysicalAddress MacAddress { get; set; }

    public IPAddress IPv6Address { get; set; }
  }

  public sealed class PortCountEventArgs : ICSPEventArgs
  {
    public PortCountEventArgs(MsgCmdPortCountBy message) : base(message)
    {
      Device = message.Device;

      System = message.System;

      PortCount = message.PortCount;
    }

    public ushort Device { get; private set; }

    public ushort System { get; private set; }

    public ushort PortCount { get; private set; }
  }

  public sealed class DynamicDeviceCreatedArgs : EventArgs
  {
    public DynamicDeviceCreatedArgs(ushort system, ushort dynamicDevice)
    {
      System = system;

      DynamicDevice = dynamicDevice;
    }

    public ushort System { get; private set; }

    public ushort DynamicDevice { get; private set; }
  }
}
