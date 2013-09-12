using System.Data;
using Shuttle.Core.Data;

namespace Test.All
{
    public class ClientMapper : IDataRowMapper<Client>
    {
        public MappedRow<Client> Map(DataRow row)
        {
            return new MappedRow<Client>(row, new Client {Name = row[1].ToString()});
        }
    }
}
