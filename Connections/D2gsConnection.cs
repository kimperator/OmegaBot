﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace BattleNet.Connections
{
    class D2gsConnection : Connection
    {
        
        protected void StartGameServer(IPAddress ip, List<byte> hash, List<byte> token)
        {

        }

        public override bool Init(IPAddress server, ushort port, List<byte> data)
        {
            try
            {
                Logging.Logger.Write("Connecting to {0}:{1}",server,port);
                m_socket.Connect(server, port);
                m_stream = m_socket.GetStream();
                Console.WriteLine(" Connected");
            }
            catch
            {
                Console.WriteLine(" Failed To connect");
                return false;
            }
            OnStartThread();
            return true;
        }

        public override byte[] BuildPacket(byte command, params IEnumerable<byte>[] args)
        {
            List<byte> packet = new List<byte>();
            packet.Add((byte)command);

            List<byte> packetArray = new List<byte>();
            foreach (IEnumerable<byte> a in args)
                packetArray.AddRange(a);

            packet.AddRange(packetArray);

            return packet.ToArray();
        }
    }
}
