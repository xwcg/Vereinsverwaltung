using SerWalterClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerWalterClient.Network
{
    class BanksResponse : SimplifiedResponse
    {
        public List<BankAccount> banks;

        public BanksResponse() { }
    }
}
