# Version Management

This project uses centralized version management through the `Directory.Build.props` file located in the `src` directory.

## How It Works

All version information is defined in `src/Directory.Build.props`:
- `VersionPrefix`: The main version number (e.g., 1.2.3)
- `VersionSuffix`: Optional suffix for pre-release versions (e.g., beta, alpha, rc1)
- `Version`: Automatically computed from prefix and suffix
- `AssemblyVersion` and `FileVersion`: Automatically set based on the version prefix

All project files (`.csproj`) automatically inherit these version properties.

## Updating the Version

### Option 1: Using the Update Script (Recommended)

#### On Linux/macOS:
```bash
./update-version.sh 1.2.3
# or with a pre-release suffix
./update-version.sh 1.2.3 beta
```

#### On Windows:
```powershell
.\update-version.ps1 -Version "1.2.3"
# or with a pre-release suffix
.\update-version.ps1 -Version "1.2.3" -VersionSuffix "beta"
```

### Option 2: Manual Update

Edit `src/Directory.Build.props` and update the version values:

```xml
<PropertyGroup>
  <VersionPrefix>1.2.3</VersionPrefix>
  <VersionSuffix>beta</VersionSuffix>
</PropertyGroup>
```

For stable releases, leave `VersionSuffix` empty:
```xml
<PropertyGroup>
  <VersionPrefix>1.2.3</VersionPrefix>
  <VersionSuffix></VersionSuffix>
</PropertyGroup>
```

## Version Format

The project follows [Semantic Versioning](https://semver.org/):
- **MAJOR** version when you make incompatible API changes
- **MINOR** version when you add functionality in a backward compatible manner
- **PATCH** version when you make backward compatible bug fixes

Pre-release versions can include a suffix (e.g., `1.2.3-beta`, `1.2.3-rc1`).

## Integration with CI/CD

The version can be updated in GitHub Actions workflows before building:

```yaml
- name: Update version
  run: ./update-version.sh ${{ github.event.inputs.version }}

- name: Build
  run: dotnet build src/Selkie.DefCon.sln --configuration Release
```

You can also use environment variables or git tags to automatically determine the version.

## Benefits

1. **Single Source of Truth**: Version is defined in one place
2. **Consistency**: All projects use the same version
3. **Automation**: Easy to update versions programmatically
4. **CI/CD Friendly**: Simple to integrate with build pipelines
5. **Flexibility**: Supports pre-release versions with suffixes
