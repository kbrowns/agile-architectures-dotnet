using System.Text;

namespace System;

public static class StringExtensions
{
    public static string ToJoinedString(this IEnumerable<string> strings, string delimiter)
    {
        return string.Join(delimiter, strings);
    }
    
    /// <summary>
    /// from this:  foo_bar_baz
    /// to this:    FooBarBaz
    /// </summary>
    /// <param name="s"></param>
    /// <param name="delimiter"></param>
    /// <returns></returns>
    public static string FromSnakeCaseToPascalCase(this string s, char delimiter = '_')
    {
        return string.Join("", s.Split(delimiter, StringSplitOptions.RemoveEmptyEntries).Select(x => $"{x.Substring(0, 1).ToUpper()}{x.Substring(1)}"));
    }

    /// <summary>
    /// from this:  foo_bar_baz
    /// to this:    fooBarBaz
    /// </summary>
    /// <param name="s"></param>
    /// <param name="delimiter"></param>
    /// <returns></returns>
    public static string FromSnakeCaseToCamelCase(this string s, char delimiter = '_')
    {
        var pascal = s.FromSnakeCaseToPascalCase(delimiter);

        if (string.IsNullOrEmpty(pascal))
            return pascal;

        return string.Concat(pascal.Substring(0, 1).ToLower(), pascal.Substring(1));
    }

    /// <summary>
    /// from this:  FooBarBaz
    /// to this:    foo_bar_baz
    /// WARNING!  this is not efficient - this is indented for use in build time and startup-time things like EF mappings (not hot spots in the app)
    /// </summary>
    /// <param name="s"></param>
    /// <param name="delimiter"></param>
    /// <returns></returns>
    public static string FromPascalCaseToSnakeCase(this string s, char delimiter = '_')
    {
        var builder = new StringBuilder();

        for (var index = 0; index < s.Length; index++)
        {
            var c = s[index];
            string part = c.ToString();

            if (index > 0 && index < s.Length && part == c.ToString().ToUpper())
{                    builder.Append(delimiter);}

            builder.Append(part.ToLower());
        }

        return builder.ToString();
    }
}