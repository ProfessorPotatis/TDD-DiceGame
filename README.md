# TDD-DiceGame
An exercise in Test Driven Development.

## Setup in Visual Studio Code
1. In optional directory:
```
mkdir TDD-DiceGame
```
2. In TDD-DiceGame:
```
mkdir DiceGame
mkdir DiceGameTests
```
3. In DiceGame:
```
dotnet new console
dotnet restore
dotnet run
```
4. In DiceGameTests:
```
dotnet new console
dotnet restore
dotnet run
```
5. Open Command Palette...
6. NuGet Package Manager: Add Package (To DiceGameTests.csproj)
* NUnit latest version
* NUnit.Console latest version
* Moq latest version
* OpenCover latest version
7. In DiceGameTests.csproj:
```
<ProjectReference Include="..\DiceGame\DiceGame.csproj" />
```