using System.Collections.Generic;
using Shuttle.Core.Data;

namespace Test.All.Assembler
{
    public class ClientAssembler : IAssembler<Client>
    {
        public IEnumerable<Client> Assemble(MappedData data)
        {
            var result = new List<Client>();

            foreach (var clientRow in data.MappedRows<Client>())
            {
                var client = clientRow.Result;

                var clientId = clientRow.Row[0];

                foreach (var contactRow in data.MappedRows<ClientContact>(map => map.Row[0].Equals(clientId)))
                {
                    client.AddContact(contactRow.Result);
                }

                result.Add(client);
            }

            return result;
        }
    }
}