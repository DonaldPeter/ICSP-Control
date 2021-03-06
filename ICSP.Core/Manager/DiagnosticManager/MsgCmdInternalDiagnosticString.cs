﻿using System.Linq;
using System.Text;

using ICSP.Core.Constants;
using ICSP.Core.Extensions;
using ICSP.Core.Logging;

namespace ICSP.Core.Manager.DiagnosticManager
{
  [MsgCmd(DiagnosticManagerCmd.InternalDiagnosticString)]
  public class MsgCmdInternalDiagnosticString : ICSPMsg
  {
    public const int MsgCmd = DiagnosticManagerCmd.InternalDiagnosticString;

    private MsgCmdInternalDiagnosticString()
    {
    }

    public MsgCmdInternalDiagnosticString(byte[] buffer) : base(buffer)
    {
      if(Data.Length > 0)
      {
        ObjectId = Data.GetBigEndianInt16(0);

        Severity = Data.GetBigEndianInt16(2);

        Text = AmxUtils.GetNullStr(Data, 4);
      }
    }

    public override ICSPMsg FromData(byte[] bytes)
    {
      return new MsgCmdInternalDiagnosticString(bytes);
    }

    public static ICSPMsg CreateRequest(AmxDevice dest, AmxDevice source, ushort objectId, ushort severity, string text)
    {
      var lRequest = new MsgCmdInternalDiagnosticString
      {
        ObjectId = objectId,
        Severity = severity,
        Text = text
      };

      var lBytes = Encoding.GetEncoding(1252).GetBytes(lRequest.Text + "\0");
      
      var lData = ArrayExtensions.Int16ToBigEndian(lRequest.ObjectId).
        Concat(ArrayExtensions.Int16ToBigEndian(lRequest.Severity)).
        Concat(lBytes).
        ToArray();

      return lRequest.Serialize(dest, source, MsgCmd, lData);
    }

    /// <summary>
    /// Unsigned 16-bit value. Number of characters in string
    /// Values defined in the Constants & IDs specification document.
    /// </summary>
    public ushort ObjectId { get; set; }

    /// <summary>
    ///  Unsigned 16-bit value.
    /// </summary>
    public ushort Severity { get; set; }

    /// <summary>
    /// Containing text description of the error
    /// </summary>
    public string Text { get; private set; }

    protected override void WriteLogExtended()
    {
      Logger.LogDebug(false, "{0:l} ObjectId: {1}", GetType().Name, ObjectId);
      Logger.LogDebug(false, "{0:l} Severity: {1}", GetType().Name, Severity);
      Logger.LogDebug(false, "{0:l} Text    : {1:l}", GetType().Name, Text);
    }
  }
}