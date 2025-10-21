# Selkie.DefCon

[![.NET Build and Test](https://github.com/tschroedter/Selkie.DefCon/actions/workflows/dotnet.yml/badge.svg)](https://github.com/tschroedter/Selkie.DefCon/actions/workflows/dotnet.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

A .NET library providing defensive programming utilities and testing helpers for building robust applications.

## Features

- **Guard Clauses**: Comprehensive set of guard methods to validate method arguments
- **Constructor Testing**: Automated testing utilities for constructor null checks using AutoFixture and NSubstitute
- **MSTest Integration**: Seamless integration with MSTest2 for automated testing
- **Autofac Support**: Built-in Autofac module for dependency injection

## Installation

Install via NuGet Package Manager:

```bash
dotnet add package Selkie.DefCon.One
```

Or via Package Manager Console:

```powershell
Install-Package Selkie.DefCon.One
```

## Quick Start

### Using Guard Clauses

```csharp
using Selkie.DefCon.One.Common;

public class MyService
{
    private readonly string _name;
    
    public MyService(string name)
    {
        Guard.ArgumentNotNullOrEmpty(name, nameof(name));
        _name = name;
    }
    
    public void ProcessValue(int value)
    {
        Guard.ArgumentNotNegative(value, nameof(value));
        // Process value...
    }
}
```

### Constructor Testing

```csharp
using Selkie.DefCon.One.Constructor;

[TestClass]
public class MyServiceTests
{
    [TestMethod]
    public void Constructor_Should_ThrowForNullParameters()
    {
        var sut = new NotNullTester<MyService>();
        sut.RunAllNotNullChecks();
    }
}
```

## Requirements

- .NET 8.0 or higher

## Building from Source

1. Clone the repository:
   ```bash
   git clone https://github.com/tschroedter/Selkie.DefCon.git
   cd Selkie.DefCon
   ```

2. Restore dependencies:
   ```bash
   cd src
   dotnet restore
   ```

3. Build the solution:
   ```bash
   dotnet build
   ```

4. Run tests:
   ```bash
   dotnet test
   ```

## Version Management

This project uses centralized version management. To update the version before building:

```bash
# On Linux/macOS
./update-version.sh 1.2.3

# On Windows
.\update-version.ps1 -Version "1.2.3"
```

For more information, see [VERSION_MANAGEMENT.md](VERSION_MANAGEMENT.md).

## Contributing

Contributions are welcome! Please read our [Contributing Guidelines](CONTRIBUTING.md) for details on our code of conduct and the process for submitting pull requests.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Built with [AutoFixture](https://github.com/AutoFixture/AutoFixture)
- Uses [NSubstitute](https://nsubstitute.github.io/) for test substitutes
- Dependency injection powered by [Autofac](https://autofac.org/)

## Support

If you encounter any issues or have questions, please [open an issue](https://github.com/tschroedter/Selkie.DefCon/issues/new) on GitHub.