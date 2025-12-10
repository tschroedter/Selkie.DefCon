#!/bin/bash
# Updates the version number in Directory.Build.props
# Usage: ./update-version.sh VERSION [BUILD_NUMBER] [VERSION_SUFFIX]
# Example: ./update-version.sh 0.1 123
#          ./update-version.sh 0.1 123 beta

set -e

if [[ -z "$1" ]]; then
    echo "Error: Version parameter is required" >&2
    echo "Usage: ./update-version.sh VERSION [BUILD_NUMBER] [VERSION_SUFFIX]"
    echo "Example: ./update-version.sh 0.1 123"
    echo "         ./update-version.sh 0.1 123 beta"
    exit 1
fi

VERSION=$1
BUILD_NUMBER=${2:-"0"}
VERSION_SUFFIX=${3:-""}

# Validate version format (X.Y format)
if ! [[ $VERSION =~ ^[0-9]+\.[0-9]+$ ]]; then
    echo "Error: Invalid version format. Expected format: X.Y (e.g., 0.1)" >&2
    exit 1
fi

# Validate build number format
if ! [[ $BUILD_NUMBER =~ ^[0-9]+$ ]]; then
    echo "Error: Invalid build number format. Expected a number (e.g., 123)" >&2
    exit 1
fi

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PROPS_FILE="$SCRIPT_DIR/src/Directory.Build.props"

if [[ ! -f "$PROPS_FILE" ]]; then
    echo "Error: Directory.Build.props not found at: $PROPS_FILE" >&2
    exit 1
fi

if [[ -n "$VERSION_SUFFIX" ]]; then
    echo "Updating version to: $VERSION.$BUILD_NUMBER-$VERSION_SUFFIX"
else
    echo "Updating version to: $VERSION.$BUILD_NUMBER"
fi

# Update VersionPrefix
sed -i.bak "s|<VersionPrefix>.*</VersionPrefix>|<VersionPrefix>$VERSION</VersionPrefix>|g" "$PROPS_FILE"

# Update BuildNumber
sed -i.bak "s|<BuildNumber Condition=\"'\$(BuildNumber)' == ''\">.*</BuildNumber>|<BuildNumber Condition=\"'\$(BuildNumber)' == ''\">$BUILD_NUMBER</BuildNumber>|g" "$PROPS_FILE"

# Update VersionSuffix
sed -i.bak "s|<VersionSuffix>.*</VersionSuffix>|<VersionSuffix>$VERSION_SUFFIX</VersionSuffix>|g" "$PROPS_FILE"

# Remove backup file
rm -f "$PROPS_FILE.bak"

echo "Version updated successfully!"
echo "File: $PROPS_FILE"
