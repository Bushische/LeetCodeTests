# build a specific project
```sh
dotnet build ./LeetCodeTests/LeetCodeTests.csproj
```

# run tests from the test project
```zsh
dotnet test ./LeetCodeTests.UnitTests/LeetCodeTests.UnitTests.csproj
```

# create a new solution and add projects
```sh
dotnet new sln -n LeetCodeTests
dotnet sln add ./LeetCodeTests/LeetCodeTests.csproj ./LeetCodeTests.UnitTests/LeetCodeTests.UnitTests.csproj
```

# remove the solution file (just deletes it)
```sh
rm LeetCodeTests.sln
```