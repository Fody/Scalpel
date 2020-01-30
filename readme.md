# <img src="/package_icon.png" height="30px"> Scalpel.Fody

[![Chat on Gitter](https://img.shields.io/gitter/room/fody/fody.svg)](https://gitter.im/Fody/Fody)
[![NuGet Status](https://img.shields.io/nuget/v/Scalpel.Fody.svg)](https://www.nuget.org/packages/Scalpel.Fody/)

Strips all testing code from an assembly.


### This is an add-in for [Fody](https://github.com/Fody/Home/)

**It is expected that all developers using Fody either [become a Patron on OpenCollective](https://opencollective.com/fody/contribute/patron-3059), or have a [Tidelift Subscription](https://tidelift.com/subscription/pkg/nuget-fody?utm_source=nuget-fody&utm_medium=referral&utm_campaign=enterprise). [See Licensing/Patron FAQ](https://github.com/Fody/Home/blob/master/pages/licensing-patron-faq.md) for more information.**


## Usage

See also [Fody usage](https://github.com/Fody/Home/blob/master/pages/usage.md).


### NuGet installation

Install the [Scalpel.Fody NuGet package](https://nuget.org/packages/Scalpel.Fody/) and update the [Fody NuGet package](https://nuget.org/packages/Fody/):

```powershell
PM> Install-Package Fody
PM> Install-Package Scalpel.Fody
```

The `Install-Package Fody` is required since NuGet always defaults to the oldest, and most buggy, version of any dependency.


### Add to FodyWeavers.xml

Add `<Scalpel/>` to [FodyWeavers.xml](https://github.com/Fody/Home/blob/master/pages/usage.md#add-fodyweaversxml)

```xml
<Weavers>
  <Scalpel/>
</Weavers>
```


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


### NSubstitute

 * Removes the reference to NSubstitute.


### FakeItEasy

 * Removes the reference to FakeItEasy.


### Moq

 * Removes the reference to Moq.


## But WHY?

When coding any tests then these tests should be a first class citizen to the functionality you are creating. As such it makes sense for them to be co-located with the code being tested. Unfortunately due to the nature of .net this is very difficult to achieve. The reason is that if you place tests next to the code being tested you and up having those tests include in your deployable assembly. You also have the problem of your assembly referencing unit test helper libraries like NUnit and Moq.

So Scalpel helps you work around the above problem by striping tests and references from your assembly. It also has the added side effect of allowing you to test internal types without needing to use the [InternalsVisibleToAttribute](http://msdn.microsoft.com/en-us/library/system.runtime.compilerservices.internalsvisibletoattribute.aspx).


## But how do I test my deployable artifacts

One problem with this approach is testing your deployable artifacts if the tests are removed from them.

This is a legitimate problem. The recommended approached it to create another build configuration call `Deployable`. It can have all the same settings as your `Release` configuration with the addition of the `Scalpel` compilation constant.
This way tests can run from your `Release` configuration and you can deploy from your `Deployable` configuration.


## Configuration Options

All configuration options are access by modifying the `Scalpel` node in FodyWeavers.xml


### RemoveReferences

A list of assembly names to removed at compile time.

Do not include `.exe` or `.dll` in the names.

Can take two forms.

As an element with items delimited by a newline.

```xml
<Scalpel>
    <RemoveReferences>
        Foo
        Bar
    </RemoveReferences>
</Scalpel>
```

Or as a attribute with items delimited by a pipe `|`.

```xml
<Scalpel RemoveReferences='Foo|Bar'/>
```


## Icon

[Exacto Knife](https://thenounproject.com/noun/exacto-knife/#icon-No489) designed by [Edward Boatman](https://thenounproject.com/edward/) from [The Noun Project](https://thenounproject.com).