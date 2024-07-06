﻿using ProtoBuf;
using Sandbox.ModAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using VRage.Game.ModAPI;
using VRageMath;

namespace GrappleHook
{
    [ProtoContract]
    public class ZiplineEntity
    {
        [ProtoMember(1)]
        public long playerId;

        [ProtoMember(2)]
        public bool direction;

        [ProtoMember(3)]
        public Vector3D pulley;

        [XmlIgnore]
        public IMyPlayer player;

        public ZiplineEntity() { }

        public ZiplineEntity(long pid, bool d)
        {
            playerId = pid;
            direction = d;
        }

        public ZiplineEntity(long pid, bool d, float t) 
        {
            playerId = pid;
            direction = d;
        }

        public static void Populate(ZiplineEntity ziplineData)
        {
            if (ziplineData.player == null)
            {
                List<IMyPlayer> players = new List<IMyPlayer>();
                MyAPIGateway.Players.GetPlayers(players);
                foreach (IMyPlayer p in players)
                {
                    if (ziplineData.playerId == p.IdentityId)
                    {
                        ziplineData.player = p;
                        break;
                    }
                }
            }
        }
    }
}