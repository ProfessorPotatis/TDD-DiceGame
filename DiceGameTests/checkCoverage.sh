dotnet restore
dotnet build

cd DiceGameTests

# Instrument all assemblies
dotnet minicover instrument --workdir ../ --assemblies DiceGameTests/**/*.dll --sources DiceGame/**/*.cs 

# Reset hits count in case minicover was run for this project
dotnet minicover reset --workdir ../

for project in *.csproj; do dotnet test --no-build $project; done

# Uninstrument assemblies
dotnet minicover uninstrument --workdir ../

# Create html reports inside folder coverage-html
dotnet minicover htmlreport --workdir ../

# Print console report
dotnet minicover report --workdir ../

cd ..