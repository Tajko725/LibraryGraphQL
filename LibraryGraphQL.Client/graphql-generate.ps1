# Skrypt inicjalizuje klienta GraphQL i generuje kod
param (
    [string]$SchemaUrl = "https://localhost:7046/graphql",
    [string]$ProjectPath = "."
)

# Przejdź do folderu projektu
Set-Location $ProjectPath

Write-Host "🔧 Inicjalizacja StrawberryShake..." -ForegroundColor Cyan
dotnet graphql init $SchemaUrl

# Podmień "name" w pliku .graphqlrc.json
$rcPath = ".graphqlrc.json"
if (Test-Path $rcPath) {
    (Get-Content $rcPath) -replace '"name":\s*"LibraryGraphQL\.Client"', '"name": "LibraryGraphQL_Client"' | Set-Content $rcPath
    Write-Host "✅ Zmieniono nazwę klienta w .graphqlrc.json na 'LibraryGraphQL_Client'" -ForegroundColor Green
} else {
    Write-Host "❌ Nie znaleziono pliku .graphqlrc.json. Anuluję." -ForegroundColor Red
    exit 1
}

# Wygeneruj klienta
Write-Host "🚀 Generowanie klienta..." -ForegroundColor Cyan
dotnet graphql generate

Write-Host "✅ Gotowe. Sprawdź folder 'Generated'." -ForegroundColor Green
