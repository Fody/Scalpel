using System;
using FakeItEasy;
using NUnit.Framework;

[TestFixture]
public class ForceReferences
{
    Type moqType = typeof(Moq.Mock);
    Type nsubType = typeof (NSubstitute.Arg);
    Type rhinoType = typeof (Rhino.Mocks.RhinoMocks);
    Type fakeItEasyType = typeof (A);
}