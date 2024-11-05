# Create the solution
dotnet new sln -n QuizmasterGameSolution

# Create the core library project (for game logic)
dotnet new classlib -n QuizmasterGame.Core
# Verkare inte behövas --> dotnet add HangmanGame.Core package System.Collections.Immutable

# Create the console application project
dotnet new console -n QuizmasterGame.ConsoleApp

# Create the test project using xUnit
dotnet new xunit -n QuizmasterGame.Tests
dotnet add QuizmasterGame.Tests package Shouldly

# Add project references
dotnet add QuizmasterGame.ConsoleApp reference QuizmasterGame.Core
dotnet add QuizmasterGame.Tests reference QuizmasterGame.Core

# Add the projects to the solution
dotnet sln QuizmasterGameSolution.sln add QuizmasterGame.Core/QuizmasterGame.Core.csproj
dotnet sln QuizmasterGameSolution.sln add QuizmasterGame.ConsoleApp/QuizmasterGame.ConsoleApp.csproj
dotnet sln QuizmasterGameSolution.sln add QuizmasterGame.Tests/QuizmasterGame.Tests.csproj