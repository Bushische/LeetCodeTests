# LeetCode tests

Personal repository for tracking progress on LeetCode problems. Problem descriptions are sourced from LeetCode and remain their property; they are included here only for reference alongside solutions and tests. Refer to LeetCode for the official problem statements and terms of use.

----

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