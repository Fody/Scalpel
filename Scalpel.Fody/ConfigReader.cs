using System;
using System.Collections.Generic;

public partial class ModuleWeaver
{
    public List<string> RemoveReferences = new();

    public void ReadConfig()
    {
        ReadIncludes();
    }

    void ReadIncludes()
    {
        var includeAssembliesAttribute = Config.Attribute("RemoveReferences");
        if (includeAssembliesAttribute != null)
        {
            foreach (var item in includeAssembliesAttribute.Value.Split('|').NonEmpty())
            {
                RemoveReferences.Add(item);
            }
        }

        var includeAssembliesElement = Config.Element("RemoveReferences");
        if (includeAssembliesElement != null)
        {
            foreach (var item in includeAssembliesElement.Value
                .Split(new[] {"\r\n", "\n"}, StringSplitOptions.RemoveEmptyEntries)
                .NonEmpty())
            {
                RemoveReferences.Add(item);
            }
        }
    }
}