using System;
using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

public partial class ModuleWeaver
{
    static List<IRemover> removers;
    List<IRemover> filteredRemovers = new List<IRemover>();
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
        var assemblyReferences = ModuleDefinition.AssemblyReferences;
        var assemblyNameReference = assemblyReferences.FirstOrDefault(x => x.Name == "Scalpel");
        assemblyReferences.Remove(assemblyNameReference);

        if (DefineConstants == null || DefineConstants.All(x => x != "Scalpel"))
        {
            var typeDefinitions = ModuleDefinition.GetTypes().ToList();
            foreach (var type in typeDefinitions)
            {
                var removeAttribute = type.CustomAttributes.FirstOrDefault(x => x.AttributeType.FullName == "Scalpel.RemoveAttribute");
                if (removeAttribute != null)
                {
                    type.CustomAttributes.Remove(removeAttribute);
                }
            }
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
            if (filteredRemovers.Any(x => x.ShouldRemoveType(type)))
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
        while (queue.Count > 0)
        {
            var remover = queue.Dequeue();

            var referenceNamesToRemove = remover.GetReferenceNames().ToList();
            if (referenceNamesToRemove.Count == 0)
            {
                filteredRemovers.Add(remover);
                continue;
            }
            foreach (var reference in assemblyNameReferences)
            {
                if (referenceNamesToRemove.Contains(reference.Name))
                {
                    filteredRemovers.Add(remover);
                    ModuleDefinition.AssemblyReferences.Remove(reference);
                }
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