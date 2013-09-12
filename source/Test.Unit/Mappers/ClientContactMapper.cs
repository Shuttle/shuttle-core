using System.Data;
using Shuttle.Core.Data;

namespace Test.All
{
    public class ClientContactMapper : IDataRowMapper<ClientContact>
    {
        public MappedRow<ClientContact> Map(DataRow row)
        {
            return new MappedRow<ClientContact>(row, new ClientContact {Name = row[1].ToString()});
        }
    }
}
