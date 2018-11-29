using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.Launcher.Networking.Data
{
    public enum PacketType
    {
        HashVerification = 0,

        FriendListRequest = 101,
        FriendListResponse,
    }
}
