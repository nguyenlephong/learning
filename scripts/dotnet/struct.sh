#!/bin/bash

# ===== Config =====
SOLUTION_NAME="LearningApp"
SRC_DIR="src"

# ===== Create solution =====
echo "📦 Creating solution: $SOLUTION_NAME"
dotnet new sln -n "$SOLUTION_NAME"

# ===== Create src directory =====
mkdir -p "$SRC_DIR"

# ===== Create projects =====
echo "📂 Creating Domain project..."
dotnet new classlib -n "$SOLUTION_NAME.Domain" -o "$SRC_DIR/$SOLUTION_NAME.Domain"

echo "📂 Creating Application project..."
dotnet new classlib -n "$SOLUTION_NAME.Application" -o "$SRC_DIR/$SOLUTION_NAME.Application"

echo "📂 Creating Infrastructure project..."
dotnet new classlib -n "$SOLUTION_NAME.Infrastructure" -o "$SRC_DIR/$SOLUTION_NAME.Infrastructure"

echo "📂 Creating API project..."
dotnet new webapi -n "$SOLUTION_NAME.API" -o "$SRC_DIR/$SOLUTION_NAME.API"

# ===== Add projects to solution =====
echo "🧩 Adding projects to solution..."
dotnet sln "$SOLUTION_NAME.sln" add "$SRC_DIR/$SOLUTION_NAME.Domain/$SOLUTION_NAME.Domain.csproj"
dotnet sln "$SOLUTION_NAME.sln" add "$SRC_DIR/$SOLUTION_NAME.Application/$SOLUTION_NAME.Application.csproj"
dotnet sln "$SOLUTION_NAME.sln" add "$SRC_DIR/$SOLUTION_NAME.Infrastructure/$SOLUTION_NAME.Infrastructure.csproj"
dotnet sln "$SOLUTION_NAME.sln" add "$SRC_DIR/$SOLUTION_NAME.API/$SOLUTION_NAME.API.csproj"

# ===== Add project references =====
echo "🔗 Adding references..."
dotnet add "$SRC_DIR/$SOLUTION_NAME.Application/$SOLUTION_NAME.Application.csproj" reference "$SRC_DIR/$SOLUTION_NAME.Domain/$SOLUTION_NAME.Domain.csproj"
dotnet add "$SRC_DIR/$SOLUTION_NAME.Infrastructure/$SOLUTION_NAME.Infrastructure.csproj" reference "$SRC_DIR/$SOLUTION_NAME.Application/$SOLUTION_NAME.Application.csproj"
dotnet add "$SRC_DIR/$SOLUTION_NAME.API/$SOLUTION_NAME.API.csproj" reference "$SRC_DIR/$SOLUTION_NAME.Application/$SOLUTION_NAME.Application.csproj"

# ===== Done =====
echo "✅ Clean Architecture skeleton created successfully!"
echo "➡ You can run API using:"
echo "   dotnet watch run --project $SRC_DIR/$SOLUTION_NAME.API"