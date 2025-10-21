# Version Management

This project uses centralized version management through the `Directory.Build.props` file located in the `src` directory.

## How It Works

All version information is defined in `src/Directory.Build.props`:
- `VersionPrefix`: The main version number (e.g., 0.1)
- `BuildNumber`: The build number (e.g., 123). Defaults to 0 if not specified.
- `VersionSuffix`: Optional suffix for pre-release versions (e.g., beta, alpha, rc1)
- `Version`: Automatically computed from prefix, build number, and suffix
- `AssemblyVersion` and `FileVersion`: Automatically set based on the version prefix and build number

All project files (`.csproj`) automatically inherit these version properties.

## Updating the Version

### Option 1: Using the Update Script (Recommended)

#### On Linux/macOS:
```bash
./update-version.sh 0.1 123
# or with a pre-release suffix
./update-version.sh 0.1 123 beta
```

#### On Windows:
```powershell
.\update-version.ps1 -Version "0.1" -BuildNumber "123"
# or with a pre-release suffix
.\update-version.ps1 -Version "0.1" -BuildNumber "123" -VersionSuffix "beta"
```

### Option 2: Manual Update

Edit `src/Directory.Build.props` and update the version values:

```xml
<PropertyGroup>
  <VersionPrefix>0.1</VersionPrefix>
  <BuildNumber Condition="'$(BuildNumber)' == ''">123</BuildNumber>
  <VersionSuffix>beta</VersionSuffix>
</PropertyGroup>
```

For stable releases, leave `VersionSuffix` empty:
```xml
<PropertyGroup>
  <VersionPrefix>0.1</VersionPrefix>
  <BuildNumber Condition="'$(BuildNumber)' == ''">123</BuildNumber>
  <VersionSuffix></VersionSuffix>
</PropertyGroup>
```

## Version Format

The project uses a version format of `MAJOR.MINOR.BUILD[-SUFFIX]`:
- **MAJOR** version for significant releases
- **MINOR** version for feature releases  
- **BUILD** version for build number (typically from CI/CD)
- **SUFFIX** (optional) for pre-release versions (e.g., `0.1.123-beta`)

The build number is typically set automatically by the CI/CD system.

## Integration with CI/CD

The version can be updated in GitHub Actions workflows before building. The build number can be set using the GitHub Actions run number:

```yaml
- name: Update version
  run: ./update-version.sh 0.1 ${{ github.run_number }}

- name: Build
  run: dotnet build src/Selkie.DefCon.sln --configuration Release
```

Alternatively, you can pass the build number directly to the build command:

```yaml
- name: Build
  run: dotnet build src/Selkie.DefCon.sln --configuration Release /p:BuildNumber=${{ github.run_number }}
```

You can also use environment variables or git tags to automatically determine the version.

## Benefits

1. **Single Source of Truth**: Version is defined in one place
2. **Consistency**: All projects use the same version
3. **Automation**: Easy to update versions programmatically
4. **CI/CD Friendly**: Simple to integrate with build pipelines
5. **Flexibility**: Supports pre-release versions with suffixes
