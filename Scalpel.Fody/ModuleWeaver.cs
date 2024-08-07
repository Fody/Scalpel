﻿using System;
using System.Collections.Generic;
using System.Linq;
using Fody;

public partial class ModuleWeaver: BaseModuleWeaver
{
    static List<IRemover> removers;
    List<IRemover> filteredRemovers = new();

    static ModuleWeaver()
    {
        var removerType = typeof (IRemover);
        removers = removerType.Assembly.GetTypes()
            .Where(_ => _.IsClass && removerType.IsAssignableFrom(_))
            .Select(_ => (IRemover)Activator.CreateInstance(_))
            .ToList();
    }

    public override void Execute()
    {
        var assemblyReferences = ModuleDefinition.AssemblyReferences;
        var assemblyNameReference = assemblyReferences.FirstOrDefault(_ => _.Name == "Scalpel");
        assemblyReferences.Remove(assemblyNameReference);

        if (DefineConstants.All(_ => _ != "Scalpel"))
        {
            var typeDefinitions = ModuleDefinition.GetTypes().ToList();
            foreach (var type in typeDefinitions)
            {
                var removeAttribute = type.CustomAttributes.FirstOrDefault(_ => _.AttributeType.FullName == "Scalpel.RemoveAttribute");
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
        CleanModuleAndAssemblyAttributes();
    }

    public override IEnumerable<string> GetAssembliesForScanning() => [];

    public override bool ShouldCleanReference => true;

    void CleanModuleAndAssemblyAttributes()
    {
        foreach (var remover in removers)
        {

            foreach (var attributeName in remover.GetModuleAttributeNames())
            {
                foreach (var attributeToRemove in ModuleDefinition.CustomAttributes.Where(_ => _.AttributeType.FullName == attributeName).ToList())
                {
                    ModuleDefinition.CustomAttributes.Remove(attributeToRemove);
                }
            }
            foreach (var attributeName in remover.GetAssemblyAttributeNames())
            {
                foreach (var attributeToRemove in ModuleDefinition.Assembly.CustomAttributes.Where(_ => _.AttributeType.FullName == attributeName).ToList())
                {
                    ModuleDefinition.Assembly.CustomAttributes.Remove(attributeToRemove);
                }
            }
        }
    }

    void CleanTypesBasedOnRemovers()
    {
        var typeDefinitions = ModuleDefinition.GetTypes().ToList();
        foreach (var type in typeDefinitions)
        {
            if (filteredRemovers.Any(_ => _.ShouldRemoveType(type)))
            {
                ModuleDefinition.RemoveType(type);
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
            if (RemoveReferences.Any(_ => _ == reference.Name))
            {
                ModuleDefinition.AssemblyReferences.Remove(reference);
            }
        }
    }
}