using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

public partial class ModuleWeaver
{
    static List<IRemover> removers;
    public Action<string> LogInfo { get; set; }
    public Action<string> LogWarning { get; set; }
    public ModuleDefinition ModuleDefinition { get; set; }
    public List<string> DefineConstants { get; set; }

    static ModuleWeaver()
    {
        var removerType = typeof (IRemover);
        removers = removerType.Assembly.GetTypes()
            .Where(x => x.IsClass && removerType.IsAssignableFrom(x))
            .Select(x=>(IRemover)Activator.CreateInstance(x))
            .ToList();
    }

    public ModuleWeaver()
    {
        LogInfo = s => { };
        LogWarning = s => { };
    }

    public void Execute()
    {
        if (DefineConstants == null || DefineConstants.All(x => x != "Scalpel"))
        {
            return;
        }
        ReadConfig();

        var typeDefinitions = ModuleDefinition.GetTypes().ToList();
        foreach (var type in typeDefinitions)
        {
            if (removers.Any(x => x.ShouldRemoveType(type)))
            {
                if (type.IsNested)
                {
                    var enclosingType = type.DeclaringType;
                    enclosingType.NestedTypes.Remove(type);
                }
                else
                {
             
                ModuleDefinition.Types.Remove(type);       
                }
            }
        }
        var assemblyNameReferences = ModuleDefinition.AssemblyReferences.ToList();
        RemoveReferences.AddRange(removers.SelectMany(x=>x.ReferenceNames));
        foreach (var reference in assemblyNameReferences)
        {
            if (RemoveReferences.Any(x => x == reference.Name))
            {
                ModuleDefinition.AssemblyReferences.Remove(reference);
            }
        }
    }
}