
using ApprovalTests.Reporters;

[assembly: UseReporter(typeof(ClipboardReporter), typeof(DiffReporter))]
[assembly: FrontLoadedReporter(typeof(object) )]