using System;
using FakeItEasy;
using NUnit.Framework;

[TestFixture]
public class ForceReferences
{
    //// ReSharper disable UnusedMember.Local
    Type moqType = typeof(Moq.Mock);
    Type nsubType = typeof (NSubstitute.Arg);
    Type rhinoType = typeof (Rhino.Mocks.RhinoMocks);
    Type fakeItEasyType = typeof(A);
    //// ReSharper restore UnusedMember.Local
}