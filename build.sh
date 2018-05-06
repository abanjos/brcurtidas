#!/bin/bash
dotnet build ./src/BRCurtidas.sln -c "Release"
dotnet vstest ./src/BRCurtidas.Web.Api.Tests/bin/Release/netcoreapp2.0/BRCurtidas.Web.Api.Tests.dll