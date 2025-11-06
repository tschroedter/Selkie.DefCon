# .NET 10.0 Upgrade Plan

## Execution Steps

Execute steps below sequentially one by one in the order they are listed.

1. Validate that an .NET 10.0 SDK required for this upgrade is installed on the machine and if not, help to get it installed.
2. Ensure that the SDK version specified in global.json files is compatible with the .NET 10.0 upgrade.
3. Upgrade Selkie.DefCon.One.Common\Selkie.DefCon.One.Common.csproj
4. Upgrade Selkie.DefCon.One\Selkie.DefCon.One.csproj
5. Upgrade Selkie.DefCon.One.Test.Examples\Selkie.DefCon.One.Test.Examples.csproj
6. Upgrade Selkie.DefCon.One.DotNetCore.Tests\Selkie.DefCon.One.DotNetCore.Tests.csproj


## Settings

### Excluded projects

Table below contains projects that do belong to the dependency graph for selected projects and should not be included in the upgrade.

| Project name                                   | Description                 |
|:-----------------------------------------------|:---------------------------:|


### Aggregate NuGet packages modifications across all projects

NuGet packages used across all selected projects or their dependencies that need version update in projects that reference them.

| Package Name                        | Current Version | New Version | Description                                   |
|:------------------------------------|:---------------:|:-----------:|:----------------------------------------------|
| System.Net.Http                     |   4.3.4         |             | Functionality included in .NET 10.0 framework; remove package reference |
| System.Text.RegularExpressions      |   4.3.1         |             | Functionality included in .NET 10.0 framework; remove package reference |


### Project upgrade details
This section contains details about each project upgrade and modifications that need to be done in the project.

#### Selkie.DefCon.One.Common modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net10.0`

NuGet packages changes:
  - (none)

Feature upgrades:
  - No feature-specific instructions discovered.

Other changes:
  - None


#### Selkie.DefCon.One modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net10.0`

NuGet packages changes:
  - Remove `System.Net.Http` (current: `4.3.4`) — functionality included in .NET 10.0 framework.
  - Remove `System.Text.RegularExpressions` (current: `4.3.1`) — functionality included in .NET 10.0 framework.

Feature upgrades:
  - No feature-specific instructions discovered.

Other changes:
  - None


#### Selkie.DefCon.One.Test.Examples modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net10.0`

NuGet packages changes:
  - Remove `System.Net.Http` (current: `4.3.4`) — functionality included in .NET 10.0 framework.

Feature upgrades:
  - No feature-specific instructions discovered.

Other changes:
  - None


#### Selkie.DefCon.One.DotNetCore.Tests modifications

Project properties changes:
  - Target framework should be changed from `net8.0` to `net10.0`

NuGet packages changes:
  - Remove `System.Net.Http` (current: `4.3.4`) — functionality included in .NET 10.0 framework.

Feature upgrades:
  - No feature-specific instructions discovered.

Other changes:
  - None
