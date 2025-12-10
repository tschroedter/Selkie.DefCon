using Microsoft.VisualStudio.TestTools.UnitTesting;

// Enable parallel test execution. Workers = 0 lets the test runner decide based on available CPUs.
[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]
