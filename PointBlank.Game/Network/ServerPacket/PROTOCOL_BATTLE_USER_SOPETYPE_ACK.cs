﻿// Decompiled with JetBrains decompiler
// Type: PointBlank.Game.Network.ServerPacket.PROTOCOL_BATTLE_USER_SOPETYPE_ACK
// Assembly: PointBlank.Game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9391C126-F6F2-4165-85EA-1FCDF75131C4
// Assembly location: C:\Users\LucasRoot\Desktop\Servidor BG\PointBlank.Game.exe

using PointBlank.Core.Network;
using PointBlank.Game.Data.Model;

namespace PointBlank.Game.Network.ServerPacket
{
  public class PROTOCOL_BATTLE_USER_SOPETYPE_ACK : SendPacket
  {
    private Account Player;

    public PROTOCOL_BATTLE_USER_SOPETYPE_ACK(Account Player) => this.Player = Player;

    public override void write()
    {
      this.writeH((short) 4253);
      this.writeD(this.Player._slotId);
      this.writeC((byte) this.Player.Sight);
    }
  }
}
