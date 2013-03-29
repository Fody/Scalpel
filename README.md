# Test Remover addin for [Fody](https://github.com/Fody/Fody/) 

Strips all testing code from an assembly

[Introduction to Fody](http://github.com/Fody/Fody/wiki/SampleUsage)

## Nuget 

Nuget here http://nuget.org/packages/Scalpel.Fody 

To Install from the Nuget Package Manager Console 
    
    PM> Install-Package Scalpel.Fody

## What it actually does. 

When the compilation constant `Scalpel` is detected. (Requires Fody version 1.11.5 or higher)

### General

 * Removes all types ending in `Tests`.
 * Removes all types ending in `Mock`.
 * Removes all types marked with `Scalpel.RemoveAttribute`.
 * Removes all references as defined in  `<Scalpel RemoveReferences='XXX'/>` see below.

### NUnit

 * Removes all types marked with any Nunit attribute.
 * Remove the NUnit reference.

### XUnit

 * Removes all types containing an XUNit attribute.
 * Removes the Xunit reference.

### MSpec

 * Removes all types containing a field from `Machine.Specifications` or `Machine.Specifications.Clr4`
 * Removes the Machine.Specifications.Clr4 and Machine.Specifications references.
 * Removes all types that implement `ISupplementSpecificationResults`, `IAssemblyContext` or `ICleanupAfterEveryContextInAssembly`.
    
### RhinoMocks

 * Removes the refernece to RhinoMocks.
  
### NSubstitute

 * Removes the refernece to NSubstitute.
  
### FakeItEasy

 * Removes the refernece to FakeItEasy.
  
### Moq

 * Removes the refernece to Moq.
 

## But WHY?

When coding any tests then these tests should be a first class citizen to the functionality you are creating. As such it makes sense for them to be co-located with the code being tested. Unfortunately due to the nature of .net this is very difficult to achieve. The reason is that if you place tests next to the code being tested you and up having those tests include in your deployable assembly. You also have the problem of your assembly referencing unit test helper libraries like NUnit and Moq.

So Scalpel helps you work around the above problem by striping tests and references from your assembly. It also has the added side effect of allowing you to test internal types without needing to use the [InternalsVisibleToAttribute](http://msdn.microsoft.com/en-us/library/system.runtime.compilerservices.internalsvisibletoattribute.aspx).

## But how do I test my deployable artefacts

One problem with this approach is testing your deployable artefacts if the tests are removed from them.

This is a legitimate problem. The recommended approached it to create another build configuration call `Deployable`. It can have all the same settings as your `Release` configuration with the addition of the `Scalpel` compilation constant.
This way tests can run from your `Release` configuration and you can deploy from your `Deployable` configuration.

## Configuration Options

All configuration options are access by modifying the `Scalpel` node in FodyWeavers.xml
    
### RemoveReferences

A list of assembly names to removed at compile time.

Do not include `.exe` or `.dll` in the names.

Can take two forms. 

As an element with items delimited by a newline.

    <Scalpel>
        <RemoveReferences>
            Foo
            Bar
        </RemoveReferences>
    </Scalpel>
    
Or as a attribute with items delimited by a pipe `|`.

    <Scalpel RemoveReferences='Foo|Bar'/>
    
    
