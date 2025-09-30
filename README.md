# man-sign-1

### What has been added? (Ali, 30.09.2025)

#### Frontend

- Cloned from Arturo
- Added `Dockerfile`, which exposes frontend to port 8080

#### Backend

- Created a solution, `backend.sln`, with two projects `api.cspoj` and `tests.csproj` (XUnit).

#### GitHub Actions

- Created `pull_request.yml`. Runs tests in the backend and tries to build the application
- Created `mega-linter.yml`. Static linting.
- Added `docker-compose.yml` in root. Runs frontend, backend with a postgres db container.

#### Other

- Added PR template
