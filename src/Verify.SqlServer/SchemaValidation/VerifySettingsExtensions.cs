namespace VerifyTests;

public static class VerifySettingsSqlExtensions
{
    public static SettingsTask SchemaSettings(
        this SettingsTask settings,
        bool storedProcedures = true,
        bool tables = true,
        bool views = true,
        bool userDefinedFunctions = true,
        bool synonyms = true,
        Func<string, bool>? includeItem = null)
    {
        settings.CurrentSettings.SchemaSettings(
            storedProcedures,
            tables,
            views,
            userDefinedFunctions,
            synonyms,
            includeItem);
        return settings;
    }

    public static void SchemaSettings(
        this VerifySettings settings,
        bool storedProcedures = true,
        bool tables = true,
        bool views = true,
        bool userDefinedFunctions = true,
        bool synonyms = true,
        Func<string, bool>? includeItem = null)
    {
        includeItem ??= _ => true;

        settings.Context.Add(
            "SqlServer",
            new SchemaSettings
            {
                StoredProcedures = storedProcedures,
                Tables = tables,
                Views = views,
                UserDefinedFunctions = userDefinedFunctions,
                Synonyms = synonyms,
                IncludeItem = (_) => includeItem(_.Name),
            });
    }

    public static void SchemaSettings(this VerifySettings settings, SchemaSettings schema) => settings.Context.Add("SqlServer", schema);

    public static SettingsTask SchemaSettings(this SettingsTask settings, SchemaSettings schema)
    {
        settings.CurrentSettings.SchemaSettings(schema);
        return settings;
    }

    internal static SchemaSettings GetSchemaSettings(this IReadOnlyDictionary<string, object> context)
    {
        if (context.TryGetValue("SqlServer", out var value))
        {
            return (SchemaSettings) value;
        }

        return defaultSettings;
    }

    static SchemaSettings defaultSettings = new();
}