using SerWalterClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerWalterClient.Network
{
    class MembersResponse : SimplifiedResponse
    {
        public List<Member> members;

        public MembersResponse() { }
    }
}
