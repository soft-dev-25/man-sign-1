#!/bin/bash

docker compose up -d # Makes sure the application is running

cd ./e2e_playwrighttests/PlaywrightTests || exit 1

pwsh bin/Debug/net9.0/playwright.ps1 install --with-deps

dotnet test
