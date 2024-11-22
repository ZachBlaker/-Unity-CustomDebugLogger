using System.Diagnostics;
using System;
using System.Reflection;

public static class CustomDebugLogger
{
    const string contextNameColor = "#72d47f";

    [Conditional("debug")]
    public static void Log(string message)
    {
        var type = new StackTrace(1, false).GetFrame(0).GetMethod().DeclaringType;
        UnityEngine.Debug.Log($"{GetHeader(type)} {message}");
    }
    [Conditional("debug")]
    public static void Log(string message, UnityEngine.Object context)
    {
        var type = new StackTrace(1, false).GetFrame(0).GetMethod().DeclaringType;
        UnityEngine.Debug.Log($"{GetHeader(type, context)} {message}", context);
    }

    [Conditional("deepdebug")]
    public static void LogDeep(string message)
    {
        var type = new StackTrace(1, false).GetFrame(0).GetMethod().DeclaringType;
        UnityEngine.Debug.Log($"{GetHeader(type)} {message}");
    }
    [Conditional("deepdebug")]
    public static void LogDeep(string message, UnityEngine.Object context)
    {
        var type = new StackTrace(1, false).GetFrame(0).GetMethod().DeclaringType;
        UnityEngine.Debug.Log($"{GetHeader(type, context)} {message}", context);
    }


    [Conditional("UNITY_ASSERTIONS")]
    public static void DebugAssert(bool condition, string message)
    {
        var type = new StackTrace(1, false).GetFrame(0).GetMethod().DeclaringType;
        UnityEngine.Debug.Assert(condition, $"{GetHeader(type)} {message}");
    }
    [Conditional("UNITY_ASSERTIONS")]
    public static void DebugAssert(bool condition, string message, UnityEngine.Object context)
    {
        var type = new StackTrace(1, false).GetFrame(0).GetMethod().DeclaringType;
        UnityEngine.Debug.Assert(condition, $"{GetHeader(type, context)} {message}", context);
    }


    private static string GetHeader(Type type)
    {
        CustomDebugAttribute customDebugAttribute = type.GetCustomAttribute<CustomDebugAttribute>(false);

        if (customDebugAttribute == null)
            customDebugAttribute = type.BaseType.GetCustomAttribute<CustomDebugAttribute>(false);

        if (customDebugAttribute == null)
            throw new Exception($"{type} and it's BaseType {type.BaseType} does not have CustomDebugAttribute");

        return customDebugAttribute.GetHeader();
    }

    private static string GetHeader(Type type, UnityEngine.Object context)
    {
        return $"{GetHeader(type)} <color={contextNameColor}><b>{context.name}: </b></color>";
    }
}