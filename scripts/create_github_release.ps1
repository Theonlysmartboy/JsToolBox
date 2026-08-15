# Create a draft GitHub release for v1.0.1 using the GitHub CLI (gh).
# Requirements:
#  - GitHub CLI (gh) installed and authenticated (run `gh auth login`).
#  - You are in the repository root.
# Usage:
#  .\scripts\create_github_release.ps1

$tag = 'v1.0.1'
$notesPath = '.github/release-notes/v1.0.1.md'

if (-not (Get-Command gh -ErrorAction SilentlyContinue)) {
    Write-Error "GitHub CLI (gh) not found. Install it and authenticate with 'gh auth login'."
    exit 1
}

if (-not (Test-Path $notesPath)) {
    Write-Error "Release notes not found at $notesPath"
    exit 1
}

$body = Get-Content $notesPath -Raw

# Create a draft release; this will not publish it.
$cmd = "gh release create $tag --title '$tag' --notes-file $notesPath --draft"
Write-Host "Running: $cmd"
Invoke-Expression $cmd

if ($LASTEXITCODE -ne 0) {
    Write-Error "gh release command failed."
    exit $LASTEXITCODE
}

Write-Host "Draft release $tag created (if authenticated)."