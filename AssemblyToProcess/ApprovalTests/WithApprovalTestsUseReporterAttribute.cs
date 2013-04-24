using ApprovalTests.Reporters;
using ApprovalUtilities.Utilities;

[UseReporter(typeof(DiffReporter))]
public class WithApprovalTestsUseReporterAttribute
{
#pragma warning disable 169
    ClassUtilities classUtilities = new ClassUtilities();
#pragma warning restore 169
}