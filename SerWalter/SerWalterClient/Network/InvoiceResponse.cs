using SerWalterClient.Data;
using System.Collections.Generic;

namespace SerWalterClient.Network
{
    internal class InvoiceResponse : SimplifiedResponse
    {
        public List<Invoice> invoices;

        public InvoiceResponse()
        {
        }
    }
}