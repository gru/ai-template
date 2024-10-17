# Prompt for variables
$migrationName = Read-Host "Enter the migration name"
$projectPath = "Src/AI.ProjectName.Entities/AI.ProjectName.Entities.csproj"
$startupProjectPath = "Src/AI.ProjectName.Migrations/AI.ProjectName.Migrations.csproj"
$context = "AI.ProjectName.Entities.ProjectNameDbContext"

# Create the migration
$command = "dotnet ef migrations add $migrationName --project `"$projectPath`" --startup-project `"$startupProjectPath`" --context `"$context`""

# Output the command (optional, for verification)
Write-Host "Executing command: $command"

# Execute the command
Invoke-Expression $command

# Check if the command was successful
if ($LASTEXITCODE -eq 0) {
    Write-Host "Migration '$migrationName' created successfully." -ForegroundColor Green
} else {
    Write-Host "Failed to create migration '$migrationName'. Please check the error messages above." -ForegroundColor Red
}