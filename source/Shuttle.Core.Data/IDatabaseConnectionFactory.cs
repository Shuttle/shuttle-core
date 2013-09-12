namespace Shuttle.Core.Data
{
	public interface IDatabaseConnectionFactory 
    {
	    IDatabaseConnection Create(DataSource source);
    	IDatabaseConnection Get(DataSource source);
    }
}