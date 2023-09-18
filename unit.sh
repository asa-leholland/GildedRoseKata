#!/bin/bash
cd csharpcore && dotnet build && dotnet test  --filter "Category=UnitTest"
