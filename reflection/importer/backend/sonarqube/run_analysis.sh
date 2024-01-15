dotnet test ../GenericImporter.sln /p:CollectCoverage=true /p:CoverletOutputFormat=opencover
dotnet sonarscanner begin /k:"GenericImporter" /d:sonar.host.url="http://localhost:8082" /d:sonar.login="24dedc268477787c8258210414847f211423f30d" /d:sonar.cs.opencover.reportsPaths="../tests/*/coverage.opencover.xml" /d:sonar.coverage.exclusions="**Tests*.cs,**/Startup.cs,**/Program.cs,,**/NativeInjectorBootStrapper.cs,**/Migrations/**,src/Something.API/Configurations/**"
dotnet build ../GenericImporter.sln
dotnet sonarscanner end /d:sonar.login="24dedc268477787c8258210414847f211423f30d"
