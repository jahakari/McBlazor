using System.Collections.Immutable;
using System.ComponentModel;

namespace McBlazor.Client.Utility;

public static class EditorHelpers
{
    private static readonly ImmutableDictionary<Type, TypeConverter> typeConverters = new Dictionary<Type, TypeConverter>()
    {
        { typeof(byte), new ByteConverter() },
        { typeof(sbyte), new SByteConverter() },
        { typeof(decimal), new DecimalConverter() },
        { typeof(double), new DoubleConverter() },
        { typeof(float), new SingleConverter() },
        { typeof(int), new Int32Converter() },
        { typeof(uint), new UInt32Converter() },
        { typeof(long), new Int64Converter() },
        { typeof(ulong), new UInt64Converter() },
        { typeof(short), new Int16Converter() },
        { typeof(ushort), new UInt16Converter() },
        { typeof(string), new StringConverter() },
        { typeof(bool), new BooleanConverter() },
        { typeof(Guid), new GuidConverter() }
    }.ToImmutableDictionary();

    public static bool TryGetInputType<T>(out string? type)
    {
        Type t = typeof(T);

        type = t.Is<string>() ? "text"
            :  t.IsNumeric() ? "number"
            :  t.IsDate() ? "date"
            :  null;

        return type is not null;
    }

    public static T? ConvertFrom<T>(object o)
    {
        Type type = TypeHelpers.GetType<T>();
        TypeConverter converter = GetTypeConverter(type);

        return (T)converter.ConvertFrom(o)!;
    }

    private static TypeConverter GetTypeConverter(Type type)
    {
        if (typeConverters.TryGetValue(type, out TypeConverter? converter)) {
            return converter;
        }

        if (type.IsEnum) {
            return new EnumConverter(type);
        }

        throw new ArgumentException("Converter not found for the specified Type.", nameof(type));
    }
}