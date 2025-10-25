#!/bin/bash

cd ./e2e_playwrighttests/PlaywrightTests || return -1

pwsh bin/Debug/net9.0/playwright.ps1 install --with-deps

dotnet test
