# Test Remover addin for [Fody](https://github.com/Fody/Fody/) 

Strips all testing code from an assembly

[Introduction to Fody](http://github.com/Fody/Fody/wiki/SampleUsage)

## Nuget package

Available here http://nuget.org/packages/Scalpel.Fody 

## What it actually does. 

When the compilation constant `Scalpel` is detected. (Requires Fody version 1.11.5 or higher)

 * Removes all types ending in `Tests`
 * Removes all types ending in `Mock`
 * Removes all types marked with `NUnit.TestFixture`
 * Removes all types containing a method marked with `Xunit.Fact`
 * Removes all references to NUnit, Xunit, RhunoMocks, NSubstitute and Moq.
 * Removes all types marked with `Scalpel.RemoveAttribute`.
 * Removes all references as defined in  `<Scalpel RemoveReferences='XXX'/>` see below.

## But WHY?

When coding tests should be a first class citizen to the functionality you are creating. As such it makes sense for them to be co-located with the code being tested. Unfortunately due to the nature of .net this is very difficult to achieve. The reason is that if you place tests next to the code being tested you and up having those tests include in your deployable assembly. You also have the problem of your assembly referencing unit test helper libraries like NUnit and Moq.

## But how do I test my deployable artifacts

One problem with this approach is testing your deployable atrifacts if the tests are removed from them.

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
    
    