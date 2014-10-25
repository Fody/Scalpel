using System;
using FakeItEasy;
using NUnit.Framework;

[TestFixture]
[Explicit]
public class ForceReferences
{
#pragma warning disable 169
    Type moqType = typeof(Moq.Mock);
    Type nSubstituteType = typeof(NSubstitute.Arg);
    Type rhinoType = typeof (Rhino.Mocks.RhinoMocks);
    Type fakeItEasyType = typeof(A);
#pragma warning restore 169
}