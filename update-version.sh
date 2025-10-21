#!/bin/bash
# Updates the version number in Directory.Build.props
# Usage: ./update-version.sh VERSION [VERSION_SUFFIX]
# Example: ./update-version.sh 1.2.3
#          ./update-version.sh 1.2.3 beta

set -e

if [ -z "$1" ]; then
    echo "Error: Version parameter is required"
    echo "Usage: ./update-version.sh VERSION [VERSION_SUFFIX]"
    echo "Example: ./update-version.sh 1.2.3"
    echo "         ./update-version.sh 1.2.3 beta"
    exit 1
fi

VERSION=$1
VERSION_SUFFIX=${2:-""}

# Validate version format (semantic versioning)
if ! [[ $VERSION =~ ^[0-9]+\.[0-9]+\.[0-9]+$ ]]; then
    echo "Error: Invalid version format. Expected format: X.Y.Z (e.g., 1.2.3)"
    exit 1
fi

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PROPS_FILE="$SCRIPT_DIR/src/Directory.Build.props"

if [ ! -f "$PROPS_FILE" ]; then
    echo "Error: Directory.Build.props not found at: $PROPS_FILE"
    exit 1
fi

if [ -n "$VERSION_SUFFIX" ]; then
    echo "Updating version to: $VERSION-$VERSION_SUFFIX"
else
    echo "Updating version to: $VERSION"
fi

# Update VersionPrefix
sed -i.bak "s|<VersionPrefix>.*</VersionPrefix>|<VersionPrefix>$VERSION</VersionPrefix>|g" "$PROPS_FILE"

# Update VersionSuffix
sed -i.bak "s|<VersionSuffix>.*</VersionSuffix>|<VersionSuffix>$VERSION_SUFFIX</VersionSuffix>|g" "$PROPS_FILE"

# Remove backup file
rm -f "$PROPS_FILE.bak"

echo "Version updated successfully!"
echo "File: $PROPS_FILE"
