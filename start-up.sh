#!/bin/bash
# filepath: start-up.sh

# Start Docker containers in detached mode
docker-compose -f docker-compose.dbtest.yml up -d

# Run npm tests
npm test

# docker down
docker-compose -f docker-compose.dbtest.yml down -v
