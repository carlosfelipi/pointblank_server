﻿// Decompiled with JetBrains decompiler
// Type: PointBlank.Game.Network.ServerPacket.PROTOCOL_BASE_CONNECT_ACK
// Assembly: PointBlank.Game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9391C126-F6F2-4165-85EA-1FCDF75131C4
// Assembly location: C:\Users\LucasRoot\Desktop\Servidor BG\PointBlank.Game.exe

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using PointBlank.Core;
using PointBlank.Core.Network;
using PointBlank.Game.Data.Configs;
using PointBlank.Game.Data.Xml;
using System;
using System.Net;

namespace PointBlank.Game.Network.ServerPacket
{
  public class PROTOCOL_BASE_CONNECT_ACK : SendPacket
  {
    private IPAddress Ip;
    private uint SessionId;
    private ushort SessionSeed;

    public PROTOCOL_BASE_CONNECT_ACK(GameClient Client)
    {
      this.SessionId = Client.SessionId;
      this.SessionSeed = Client.SessionSeed;
      this.Ip = Client.GetAddress();
    }

    public override void write()
    {
      byte[] derEncoded = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(PROTOCOL_BASE_CONNECT_ACK.GeneratePair().Public).ToAsn1Object().GetDerEncoded();
      byte[] numArray1 = new byte[128];
      Buffer.BlockCopy((Array) derEncoded, 29, (Array) numArray1, 0, numArray1.Length);
      byte[] numArray2 = new byte[3]
      {
        (byte) 1,
        (byte) 0,
        (byte) 17
      };
      short num1 = 2;
      int num2 = numArray1.Length + numArray2.Length + (int) num1;
      this.CheckIp(this.Ip);
      this.writeH((short) 514);
      this.writeH((short) 2);
      this.writeC((byte) ChannelsXml.getChannels(GameConfig.serverId).Count);
      for (int index = 0; index < ChannelsXml.getChannels(GameConfig.serverId).Count; ++index)
        this.writeC((byte) ChannelsXml._channels[index]._type);
      this.writeH((short) num2);
      this.writeH((short) numArray1.Length);
      this.writeB(numArray1);
      this.writeB(numArray2);
      this.writeC((byte) 3);
      this.writeH((short) 24);
      this.writeH(this.SessionSeed);
      this.writeD(this.SessionId);
    }

    public void CheckIp(IPAddress Ip) => Logger.LogProblems(Ip.ToString(), "Ip/Game");

    public static AsymmetricCipherKeyPair GeneratePair()
    {
      SecureRandom random = new SecureRandom((IRandomGenerator) new CryptoApiRandomGenerator());
      RsaKeyPairGenerator keyPairGenerator = new RsaKeyPairGenerator();
      keyPairGenerator.Init(new KeyGenerationParameters(random, 1024));
      return keyPairGenerator.GenerateKeyPair();
    }
  }
}
