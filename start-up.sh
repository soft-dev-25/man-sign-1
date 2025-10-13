#!/bin/bash
# filepath: start-up.sh

# Start Docker containers in detached mode
docker-compose up -d

# Run npm tests
npm test

# docker down
docker-compose down -v
