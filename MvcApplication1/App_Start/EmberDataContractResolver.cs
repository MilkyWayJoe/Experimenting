// Inspired by Gist https://gist.github.com/roryf/1042502#file-deliminatorseparatedpropertynamescontractresolver-cs

using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;


public class DeliminatorSeparatedPropertyNamesContractResolver : DefaultContractResolver {
    private readonly string _separator;

    protected DeliminatorSeparatedPropertyNamesContractResolver(char separator = '_')
        : base(true) {
        _separator = separator.ToString();
    }

    protected override string ResolvePropertyName(string propertyName) {
        var parts = new List<string>();
        var currentWord = new StringBuilder();

        foreach (var c in propertyName) {
            if (char.IsUpper(c) && currentWord.Length > 0) {
                parts.Add(currentWord.ToString());
                currentWord.Clear();
            }
            currentWord.Append(char.ToLower(c));
        }

        if (currentWord.Length > 0) {
            parts.Add(currentWord.ToString());
        }

        return string.Join(_separator, parts.ToArray());
    }
}

public class EmberDataContractResolver : DeliminatorSeparatedPropertyNamesContractResolver {
    public EmberDataContractResolver() : base('_') { }
}