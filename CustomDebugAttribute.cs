using System;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false)]
public class CustomDebugAttribute : Attribute
{
    string name;
    string color;
    string symbol;
    string symbolColor;

    public CustomDebugAttribute(string name,
                                string color = "lightblue",
                                string symbol = "[]",
                                string symbolColor = "yellow")
    {
        this.name = name;
        this.color = color;
        this.symbol = symbol;
        this.symbolColor = symbolColor;
    }
    public string GetHeader()
       => ($"<color={symbolColor}> {symbol} </color><color={color}><b>{name}: </b></color>");
}