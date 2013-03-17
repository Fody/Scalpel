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

        CleanRefsBasedOnRemovers();

        CleanRefsBasedOnConfiguration();

        CleanTypesBasedOnRemovers();
    }

    void CleanTypesBasedOnRemovers()
    {
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
    }

    void CleanRefsBasedOnRemovers()
    {
        var assemblyNameReferences = ModuleDefinition.AssemblyReferences.ToList();

        var queue = new Queue<IRemover>(removers);
        while (removers.Count > 0)
        {
            var remover = queue.Dequeue();

            var referenceNamesToRemove = remover.GetReferenceNames().ToList();
            if (referenceNamesToRemove.Count == 0)
            {
                continue;
            }
            var foundReference = false;
            foreach (var reference in assemblyNameReferences)
            {
                if (referenceNamesToRemove.Contains(reference.Name))
                {
                    foundReference = true;
                    ModuleDefinition.AssemblyReferences.Remove(reference);
                }
            }
            if (!foundReference)
            {
                removers.Remove(remover);
            }
        }
    }

    void CleanRefsBasedOnConfiguration()
    {
        var assemblyNameReferences = ModuleDefinition.AssemblyReferences.ToList();
        foreach (var reference in assemblyNameReferences)
        {
            if (RemoveReferences.Any(x => x == reference.Name))
            {
                ModuleDefinition.AssemblyReferences.Remove(reference);
            }
        }
    }
}