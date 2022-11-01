namespace System.Reflection;

public static class ReflectionExtensions
{
    public static IEnumerable<Type> GetConcreteTypesExtending<T>(this Assembly assembly)
    {
        return assembly.GetTypes().Where(x => typeof(T).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract && !x.IsGenericType);
    }
}