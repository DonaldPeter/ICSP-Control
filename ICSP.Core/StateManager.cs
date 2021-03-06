﻿using System;
using System.Collections;
using System.Collections.Generic;

using ICSP.Core.Manager.DeviceManager;

// ========================================================================================
// In progress
// ========================================================================================

namespace ICSP.Core
{
  public class DeviceState
  {
    public DeviceState(AmxDevice device)
    {
      Device = device;

      Channels = new ChannelStates();

      Levels = new LevelStates();
    }

    public AmxDevice Device { get; set; }

    public ChannelStates Channels { get; set; }

    public LevelStates Levels { get; set; }
  }

  public struct ChannelValue
  {
    public ChannelValue(ushort channel)
    {
      Channel = channel;

      Value = false;
    }

    public ChannelValue(ushort channel, bool value)
    {
      Channel = channel;

      Value = value;
    }

    public ushort Channel { get; set; }

    public bool Value { get; set; }
  }

  public struct LevelValue
  {
    public LevelValue(ushort level)
    {
      Level = level;

      Value = 0;
    }

    public LevelValue(ushort level, int value)
    {
      Level = level;

      Value = value;
    }

    public ushort Level { get; set; }

    public int Value { get; set; }
  }

  public class ChannelStates : IEnumerable<ChannelValue>
  {
    private readonly Dictionary<ushort, ChannelValue> mChannels;

    public ChannelStates()
    {
      mChannels = new Dictionary<ushort, ChannelValue>();
    }

    public bool this[ushort index]
    {
      get
      {
        if(mChannels.ContainsKey(index))
          return mChannels[index].Value;

        return false;
      }
      set
      {
        if(value)
        {
          if(!mChannels.ContainsKey(index))
            mChannels.Add(index, new ChannelValue(index, value));
        }
        else
        {
          if(mChannels.ContainsKey(index))
            mChannels.Remove(index);
        }
      }
    }

    public IEnumerator<ChannelValue> GetEnumerator()
    {
      return mChannels.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return mChannels.Values.GetEnumerator();
    }
  }

  public class LevelStates : IEnumerable<LevelValue>
  {
    private readonly Dictionary<ushort, LevelValue> mLevels;

    public LevelStates()
    {
      mLevels = new Dictionary<ushort, LevelValue>();
    }

    public int this[ushort index]
    {
      get
      {
        if(mLevels.ContainsKey(index))
          return mLevels[index].Value;

        return 0;
      }
      set
      {
        if(value > 0)
        {
          if(!mLevels.ContainsKey(index))
            mLevels.Add(index, new LevelValue(index, value));
        }
        else
        {
          if(mLevels.ContainsKey(index))
            mLevels.Remove(index);
        }
      }
    }

    public IEnumerator<LevelValue> GetEnumerator()
    {
      return mLevels.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return mLevels.Values.GetEnumerator();
    }
  }
  
  public class StateManager
  {
    private readonly ICSPManager mManager;

    private readonly Dictionary<ushort, DeviceInfoData> mDevices;

    private readonly Dictionary<AmxDevice, DeviceState> mDevicePorts;

    public StateManager(ICSPManager manager)
    {
      mManager = manager;

      mDevices = new Dictionary<ushort, DeviceInfoData>();

      mDevicePorts = new Dictionary<AmxDevice, DeviceState>();

      // Suppress Warnings IDE0052, under development ...
      Console.WriteLine(mManager);
      Console.WriteLine(mDevices);
      Console.WriteLine(mDevicePorts);

      // Test ...
      if(!mDevicePorts.ContainsKey(AmxDevice.Empty))
      {
        var lDevice = AmxDevice.Empty;

        var lDeviceState = new DeviceState(lDevice);

        mDevicePorts.Add(lDevice, lDeviceState);
        
        lDeviceState.Channels[2] = true;
        lDeviceState.Channels[4] = true;
        lDeviceState.Channels[6] = true;
        lDeviceState.Channels[4] = false;

        foreach(var item in lDeviceState.Channels)
        {
          Console.WriteLine(item);
        }
      }
    }
  }
}
