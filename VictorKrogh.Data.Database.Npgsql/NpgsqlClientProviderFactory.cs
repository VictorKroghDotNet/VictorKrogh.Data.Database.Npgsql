using System.Data;
using System.Reflection;
using VictorKrogh.Data.Providers;

namespace VictorKrogh.Data.Database.Npgsql;

public class NpgsqlClientProviderFactory<TProvider>(NpgsqlClientProviderSettings npgsqlClientProviderSettings) : IProviderFactory<TProvider>
    where TProvider : INpsqlClientDbProvider
{
    public TProvider CreateProvider(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
    {
        var type = typeof(TProvider);

        var ctor = type.GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(IsolationLevel), typeof(NpgsqlClientProviderSettings) }, null);
        if (ctor == null)
        {
            throw new NotImplementedException("Constructor not implemented.");
        }

        var instance = ctor.Invoke([isolationLevel, npgsqlClientProviderSettings]);

        return (TProvider)instance;
    }
}