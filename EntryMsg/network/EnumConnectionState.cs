using packet;

namespace network
{
    internal class EnumConnectionState
    {
        private static readonly IDictionary<PacketDirection, Dictionary<int, IPacket>> Packets =new Dictionary<PacketDirection, Dictionary<int, IPacket>>();

        static EnumConnectionState()
        {
            RegisterPacket(PacketDirection.SERVERBOUND, new CPacketKeepAlive());
            RegisterPacket(PacketDirection.SERVERBOUND, new CPacketLogin());
            RegisterPacket(PacketDirection.CLIENTBOUND, new SPacketKeepAlive());
        }

        private static void RegisterPacket(PacketDirection enumDirection, IPacket packet)
        {
            if (Packets.Keys.Contains(enumDirection))
            {
                Packets[enumDirection].Add(Packets[enumDirection].Count, packet);
            }
            else
            {
                Packets.Add(enumDirection, new Dictionary<int, IPacket>()
                {
                    { 0, packet }
                });
            }
        }

        public static IPacket GetPacket(PacketDirection enumDirection, int id)
        {
            return Packets[enumDirection][id];
        }

        public static int GetPacketId(PacketDirection enumDirection, IPacket packet)
        {
            foreach (var fPacket in Packets[enumDirection])
            {
                if (packet.GetType().FullName.Equals(fPacket.Value.GetType().FullName))
                {
                    return fPacket.Key;
                }
            }

            return -1;
        }
    }
}