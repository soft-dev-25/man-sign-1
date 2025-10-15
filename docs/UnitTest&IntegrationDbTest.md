# CI / CD - Unit Test & Integration DB Test

**Overview:**  
Our GitHub Actions CI/CD pipeline uses two separate workflows: one for fast in-memory unit tests and another for integration tests with a real `PostgreSQL` database. This design makes our test results clearer, our builds faster, and the maintenance of CI logic much easier.

## Architecture of the Workflows

- **Separation of concerns:**

  - **Unit tests:**

    - These run in `.github/workflows/UnitTest.yml` and are triggered only by changes to core models or test code, based on the specified paths and `TestCategory`.
      For example:

    ```yaml
    paths:
      - "src/Models/**" # Any file change in this folder triggers the workflow.
      - "tests/UnitTests/**"
    ```

  - **Integration tests:**
    - These are defined in `.github/workflows/IntegrationTest.yml` and are triggered by changes to the provided paths and `TestCategory`.

- **.NET Version and NuGet Caching:**
  - Each job uses the latest .NET 9 and enables built-in NuGet caching to speed up dependency restoration.
- **Database Health-Check:**
  - The integration test workflow includes a health-check step to ensure the `PostgreSQL` service is ready before running tests.

---

**Things to Note:**  
When adding `--filter` to run the tests, make sure to use the correct `TestCategory` attribute in your test classes and name them without spaces. For example:

```csharp
[TestCategory("UnitTest")]
public class MyUnitTestClass
{
    // Unit test methods here
}
```
