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
* xUnit latest version
* xunit.runner.visualstudio latest version
* Moq latest version
* Minicover latest version
7. In DiceGameTests.csproj:
```
<ProjectReference Include="..\DiceGame\DiceGame.csproj" />
```


## Write bash-file for coverage
Follow the instructions [here](https://github.com/lucaslorentz/minicover).  
Name the file: checkCoverage.sh.


## Run all tests and generate test coverage (minicover)
In the terminal, directory DiceGameTests:
```
bash checkCoverage.sh
```

This generates a coverage report, which you can see in coverage-html/DiceGame.


## Run application using Visual Studio Code integrated terminal
1. Download and open this repository with VSC.
2. Open the integrated terminal (Go to View -> Integrated Terminal).
3. Write 'cd DiceGame' and press Enter.
4. Write 'dotnet run' and press Enter.
