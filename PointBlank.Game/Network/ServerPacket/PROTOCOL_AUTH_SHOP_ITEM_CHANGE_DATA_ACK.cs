﻿// Decompiled with JetBrains decompiler
// Type: PointBlank.Game.Network.ServerPacket.PROTOCOL_AUTH_SHOP_ITEM_CHANGE_DATA_ACK
// Assembly: PointBlank.Game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9391C126-F6F2-4165-85EA-1FCDF75131C4
// Assembly location: C:\Users\LucasRoot\Desktop\Servidor BG\PointBlank.Game.exe

using PointBlank.Core.Network;

namespace PointBlank.Game.Network.ServerPacket
{
  public class PROTOCOL_AUTH_SHOP_ITEM_CHANGE_DATA_ACK : SendPacket
  {
    private uint Error;

    public PROTOCOL_AUTH_SHOP_ITEM_CHANGE_DATA_ACK(uint Error) => this.Error = Error;

    public override void write()
    {
      this.writeH((short) 1088);
      this.writeD(this.Error);
    }
  }
}
