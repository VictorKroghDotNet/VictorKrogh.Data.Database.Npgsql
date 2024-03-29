using VictorKrogh.Data.Database.Providers;

namespace VictorKrogh.Data.Database.Npgsql;

public class NpgsqlClientProviderSettings : IDbProviderSettings
{
    public string? ConnectionString { get; set; }
}
