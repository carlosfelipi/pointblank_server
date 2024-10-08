﻿// Decompiled with JetBrains decompiler
// Type: PointBlank.Game.Network.ServerPacket.PROTOCOL_AUTH_SHOP_GOODSLIST_ACK
// Assembly: PointBlank.Game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9391C126-F6F2-4165-85EA-1FCDF75131C4
// Assembly location: C:\Users\LucasRoot\Desktop\Servidor BG\PointBlank.Game.exe

using PointBlank.Core.Managers;
using PointBlank.Core.Network;

namespace PointBlank.Game.Network.ServerPacket
{
  public class PROTOCOL_AUTH_SHOP_GOODSLIST_ACK : SendPacket
  {
    private int _tudo;
    private ShopData data;

    public PROTOCOL_AUTH_SHOP_GOODSLIST_ACK(ShopData data, int tudo)
    {
      this.data = data;
      this._tudo = tudo;
    }

    public override void write()
    {
      this.writeH((short) 1036);
      this.writeD(this._tudo);
      this.writeD(this.data.ItemsCount);
      this.writeD(this.data.Offset);
      this.writeB(this.data.Buffer);
      this.writeD(585);
    }
  }
}
