#!/bin/bash

# Set destination directory (default to current directory)
DEST=${1:-.}

# Define all directories to create
DIRS=(
  "$DEST/lib/core/error"
  "$DEST/lib/core/usecases"
  "$DEST/lib/core/utils"
  "$DEST/lib/data/datasources"
  "$DEST/lib/data/models"
  "$DEST/lib/data/repositories"
  "$DEST/lib/domain/entities"
  "$DEST/lib/domain/repositories"
  "$DEST/lib/domain/usecases"
  "$DEST/lib/presentation/pages"
  "$DEST/lib/presentation/widgets"
  "$DEST/lib/presentation/routes"
  "$DEST/lib/features/auth/data"
  "$DEST/lib/features/auth/domain"
  "$DEST/lib/features/auth/presentation"
  "$DEST/lib/services"
  "$DEST/test/unit"
  "$DEST/test/widget"
  "$DEST/test/integration"
)

# Create directories and add README.md in each
for dir in "${DIRS[@]}"; do
  mkdir -p "$dir"
  touch "$dir/README.md"
done

# Create key files
touch "$DEST/lib/core/constants.dart"
touch "$DEST/lib/main.dart"
touch "$DEST/lib/injection.dart"

echo "Project structure created successfully at $DEST"