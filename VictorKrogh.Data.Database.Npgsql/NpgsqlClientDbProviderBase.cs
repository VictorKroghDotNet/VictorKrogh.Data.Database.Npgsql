using Npgsql;
using System.Data;
using System.Reflection;
using VictorKrogh.Data.Database.Providers;

namespace VictorKrogh.Data.Database.Npgsql;

public interface INpsqlClientDbProvider : IDbProvider
{
}

internal class NpgsqlClientDbProviderBase(IsolationLevel isolationLevel, NpgsqlClientProviderSettings npsqlClientProviderSettings) : DbProviderBase(isolationLevel), INpsqlClientDbProvider
{
    protected NpgsqlClientProviderSettings ProviderSettings { get; } = npsqlClientProviderSettings;

    protected override IDbConnection CreateConnection()
    {
        var connectionBuilder = new NpgsqlConnectionStringBuilder(ProviderSettings.ConnectionString);

        connectionBuilder.ApplicationName = Assembly.GetEntryAssembly()?.GetName()?.Name ?? connectionBuilder.ApplicationName;

        return new NpgsqlConnection(connectionBuilder.ToString());
    }
}
