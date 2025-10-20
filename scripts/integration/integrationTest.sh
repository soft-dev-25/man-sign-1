#!/bin/bash

# Start Docker containers in detached mode
docker-compose -f scripts/integration/docker-compose.dbtest.yml up -d

# Set connectionString for database integration test
export ConnectionStrings__Default="server=localhost;port=5433;database=GetAddress;userid=user;password=secret"

# Run integration tests
dotnet test backend/backend.sln --filter 'TestCategory=IntegrationTest'

# docker down
docker-compose -f scripts/integration/docker-compose.dbtest.yml down -v
