﻿using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ICSP.Core.Model
{

  [JsonConverter(typeof(StringEnumConverter))]
  public enum DrawOrder
  {
    // 01=Fill
    // 02=Bitmap
    // 03=Icon
    // 04=Text
    // 05=Border

    // http://www.permutationandcombination.com/permutations/12345

    [EnumMember(Value = null)] // 0102030405
    FillBitmapIconTextBorder,

    [EnumMember(Value = "0102030504")] FillBitmapIconBorderText,
    [EnumMember(Value = "0102040503")] FillBitmapTextBorderIcon,
    [EnumMember(Value = "0102040305")] FillBitmapTextIconBorder,
    [EnumMember(Value = "0102050304")] FillBitmapBorderIconText,
    [EnumMember(Value = "0102050403")] FillBitmapBorderTextIcon,
    [EnumMember(Value = "0103040502")] FillIconTextBorderBitmap,
    [EnumMember(Value = "0103040205")] FillIconTextBitmapBorder,
    [EnumMember(Value = "0103050204")] FillIconBorderBitmapText,
    [EnumMember(Value = "0103050402")] FillIconBorderTextBitmap,
    [EnumMember(Value = "0103020405")] FillIconBitmapTextBorder,
    [EnumMember(Value = "0103020504")] FillIconBitmapBorderText,
    [EnumMember(Value = "0104050203")] FillTextBorderBitmapIcon,
    [EnumMember(Value = "0104050302")] FillTextBorderIconBitmap,
    [EnumMember(Value = "0104020305")] FillTextBitmapIconBorder,
    [EnumMember(Value = "0104020503")] FillTextBitmapBorderIcon,
    [EnumMember(Value = "0104030502")] FillTextIconBorderBitmap,
    [EnumMember(Value = "0104030205")] FillTextIconBitmapBorder,
    [EnumMember(Value = "0105020304")] FillBorderBitmapIconText,
    [EnumMember(Value = "0105020403")] FillBorderBitmapTextIcon,
    [EnumMember(Value = "0105030402")] FillBorderIconTextBitmap,
    [EnumMember(Value = "0105030204")] FillBorderIconBitmapText,
    [EnumMember(Value = "0105040203")] FillBorderTextBitmapIcon,
    [EnumMember(Value = "0105040302")] FillBorderTextIconBitmap,
    [EnumMember(Value = "0203040501")] BitmapIconTextBorderFill,
    [EnumMember(Value = "0203040105")] BitmapIconTextFillBorder,
    [EnumMember(Value = "0203050104")] BitmapIconBorderFillText,
    [EnumMember(Value = "0203050401")] BitmapIconBorderTextFill,
    [EnumMember(Value = "0203010405")] BitmapIconFillTextBorder,
    [EnumMember(Value = "0203010504")] BitmapIconFillBorderText,
    [EnumMember(Value = "0204050103")] BitmapTextBorderFillIcon,
    [EnumMember(Value = "0204050301")] BitmapTextBorderIconFill,
    [EnumMember(Value = "0204010305")] BitmapTextFillIconBorder,
    [EnumMember(Value = "0204010503")] BitmapTextFillBorderIcon,
    [EnumMember(Value = "0204030501")] BitmapTextIconBorderFill,
    [EnumMember(Value = "0204030105")] BitmapTextIconFillBorder,
    [EnumMember(Value = "0205010304")] BitmapBorderFillIconText,
    [EnumMember(Value = "0205010403")] BitmapBorderFillTextIcon,
    [EnumMember(Value = "0205030401")] BitmapBorderIconTextFill,
    [EnumMember(Value = "0205030104")] BitmapBorderIconFillText,
    [EnumMember(Value = "0205040103")] BitmapBorderTextFillIcon,
    [EnumMember(Value = "0205040301")] BitmapBorderTextIconFill,
    [EnumMember(Value = "0201030405")] BitmapFillIconTextBorder,
    [EnumMember(Value = "0201030504")] BitmapFillIconBorderText,
    [EnumMember(Value = "0201040503")] BitmapFillTextBorderIcon,
    [EnumMember(Value = "0201040305")] BitmapFillTextIconBorder,
    [EnumMember(Value = "0201050304")] BitmapFillBorderIconText,
    [EnumMember(Value = "0201050403")] BitmapFillBorderTextIcon,
    [EnumMember(Value = "0304050102")] IconTextBorderFillBitmap,
    [EnumMember(Value = "0304050201")] IconTextBorderBitmapFill,
    [EnumMember(Value = "0304010205")] IconTextFillBitmapBorder,
    [EnumMember(Value = "0304010502")] IconTextFillBorderBitmap,
    [EnumMember(Value = "0304020501")] IconTextBitmapBorderFill,
    [EnumMember(Value = "0304020105")] IconTextBitmapFillBorder,
    [EnumMember(Value = "0305010204")] IconBorderFillBitmapText,
    [EnumMember(Value = "0305010402")] IconBorderFillTextBitmap,
    [EnumMember(Value = "0305020401")] IconBorderBitmapTextFill,
    [EnumMember(Value = "0305020104")] IconBorderBitmapFillText,
    [EnumMember(Value = "0305040102")] IconBorderTextFillBitmap,
    [EnumMember(Value = "0305040201")] IconBorderTextBitmapFill,
    [EnumMember(Value = "0301020405")] IconFillBitmapTextBorder,
    [EnumMember(Value = "0301020504")] IconFillBitmapBorderText,
    [EnumMember(Value = "0301040502")] IconFillTextBorderBitmap,
    [EnumMember(Value = "0301040205")] IconFillTextBitmapBorder,
    [EnumMember(Value = "0301050204")] IconFillBorderBitmapText,
    [EnumMember(Value = "0301050402")] IconFillBorderTextBitmap,
    [EnumMember(Value = "0302040501")] IconBitmapTextBorderFill,
    [EnumMember(Value = "0302040105")] IconBitmapTextFillBorder,
    [EnumMember(Value = "0302050104")] IconBitmapBorderFillText,
    [EnumMember(Value = "0302050401")] IconBitmapBorderTextFill,
    [EnumMember(Value = "0302010405")] IconBitmapFillTextBorder,
    [EnumMember(Value = "0302010504")] IconBitmapFillBorderText,
    [EnumMember(Value = "0405010203")] TextBorderFillBitmapIcon,
    [EnumMember(Value = "0405010302")] TextBorderFillIconBitmap,
    [EnumMember(Value = "0405020301")] TextBorderBitmapIconFill,
    [EnumMember(Value = "0405020103")] TextBorderBitmapFillIcon,
    [EnumMember(Value = "0405030102")] TextBorderIconFillBitmap,
    [EnumMember(Value = "0405030201")] TextBorderIconBitmapFill,
    [EnumMember(Value = "0401020305")] TextFillBitmapIconBorder,
    [EnumMember(Value = "0401020503")] TextFillBitmapBorderIcon,
    [EnumMember(Value = "0401030502")] TextFillIconBorderBitmap,
    [EnumMember(Value = "0401030205")] TextFillIconBitmapBorder,
    [EnumMember(Value = "0401050203")] TextFillBorderBitmapIcon,
    [EnumMember(Value = "0401050302")] TextFillBorderIconBitmap,
    [EnumMember(Value = "0402030501")] TextBitmapIconBorderFill,
    [EnumMember(Value = "0402030105")] TextBitmapIconFillBorder,
    [EnumMember(Value = "0402050103")] TextBitmapBorderFillIcon,
    [EnumMember(Value = "0402050301")] TextBitmapBorderIconFill,
    [EnumMember(Value = "0402010305")] TextBitmapFillIconBorder,
    [EnumMember(Value = "0402010503")] TextBitmapFillBorderIcon,
    [EnumMember(Value = "0403050102")] TextIconBorderFillBitmap,
    [EnumMember(Value = "0403050201")] TextIconBorderBitmapFill,
    [EnumMember(Value = "0403010205")] TextIconFillBitmapBorder,
    [EnumMember(Value = "0403010502")] TextIconFillBorderBitmap,
    [EnumMember(Value = "0403020501")] TextIconBitmapBorderFill,
    [EnumMember(Value = "0403020105")] TextIconBitmapFillBorder,
    [EnumMember(Value = "0501020304")] BorderFillBitmapIconText,
    [EnumMember(Value = "0501020403")] BorderFillBitmapTextIcon,
    [EnumMember(Value = "0501030402")] BorderFillIconTextBitmap,
    [EnumMember(Value = "0501030204")] BorderFillIconBitmapText,
    [EnumMember(Value = "0501040203")] BorderFillTextBitmapIcon,
    [EnumMember(Value = "0501040302")] BorderFillTextIconBitmap,
    [EnumMember(Value = "0502030401")] BorderBitmapIconTextFill,
    [EnumMember(Value = "0502030104")] BorderBitmapIconFillText,
    [EnumMember(Value = "0502040103")] BorderBitmapTextFillIcon,
    [EnumMember(Value = "0502040301")] BorderBitmapTextIconFill,
    [EnumMember(Value = "0502010304")] BorderBitmapFillIconText,
    [EnumMember(Value = "0502010403")] BorderBitmapFillTextIcon,
    [EnumMember(Value = "0503040102")] BorderIconTextFillBitmap,
    [EnumMember(Value = "0503040201")] BorderIconTextBitmapFill,
    [EnumMember(Value = "0503010204")] BorderIconFillBitmapText,
    [EnumMember(Value = "0503010402")] BorderIconFillTextBitmap,
    [EnumMember(Value = "0503020401")] BorderIconBitmapTextFill,
    [EnumMember(Value = "0503020104")] BorderIconBitmapFillText,
    [EnumMember(Value = "0504010203")] BorderTextFillBitmapIcon,
    [EnumMember(Value = "0504010302")] BorderTextFillIconBitmap,
    [EnumMember(Value = "0504020301")] BorderTextBitmapIconFill,
    [EnumMember(Value = "0504020103")] BorderTextBitmapFillIcon,
    [EnumMember(Value = "0504030102")] BorderTextIconFillBitmap,
    [EnumMember(Value = "0504030201")] BorderTextIconBitmapFill,
  }
}
