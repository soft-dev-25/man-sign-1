# man-sign-1

## How to Start the Project

To start the project, use the provided `start-up.sh` script. This script will:

1. Start all required Docker containers in the background using Docker Compose.
2. Run the project's tests with `npm test`.

### Steps

1. Make sure you have Docker Desktop running on your machine.
2. Give execute permission to the script (only needed once) using ``git bash``:

   ```bash
      chmod +x start-up.sh
   ```

3. Run the script in `git bash`:

   ```bash
      ./start-up.sh
   ```

This will set up your environment and run the tests automatically.

## Endpoints

<table>
<tr>
<td> <strong>Route</strong> </td> <td> <strong>Description</strong> </td> <td> <strong>Response</strong> </td>
</tr>
<tr>
<td> <code>/cpr</code> </td>
<td> Receive a random 10-digit CPR-number </td>
<td>

```json
{
    "CPR": "1002272249"
}
```

<tr>
<td><code>/address</code></td>
<td>Receive a random address</td>
<td>

```json
{
  "street": "gIKoXUåJeVT",
  "number": "249",
  "floorDisplay": "4",
  "door": "mf",
  "postalCode": "9400",
  "townName": "Nørresundby"
}
```

</td>
</tr>

</td>
</tr>
</td>
</tr>
</table>





# Pull Request

## What type of PR is this? (check all applicable)

- [ ] Refactor
- [X]   Feature
- [ ] Bug Fix
- [ ] Optimization
- [ ] Documentation Update

## Description
This PR adds the Address.cs class and sets up a repository to retrieve all postal codes and return a random postal code from the database.
The Address class includes all relevant validations.
An NUnit project was added to provide both unit tests and integration tests, organized into different classes and categories.

Additionally, a pipeline was set up for running unit tests and integration database tests.

## Related Tickets & Documents

- Related Issue #9 
- Closes #9 

## Added/updated tests?

- [X] Yes, added
- [ ] Yes, updated
- [ ] No, and this is why: _please replace this line with details on why tests have not been included_

## How to test?


**Version 1 (recommended):**

1. Make sure Docker Desktop is running.
2. Set up your `.env` file in the project root if required.
3. Give execute permission to the script (only needed once) using
**Git Bash**:
   ```bash
   chmod +x start-up.sh
   ```
1. Run the script in **Git Bash**:
   ```bash
   ./start-up.sh
   ```
This will set up your environment and run the tests automatically.

**Version 2 (if `.env` is already set up):**

If you have already set up your `.env` file:

1. Start the services:
   ```bash
   docker-compose up -d
   ```
2. Run the tests:
   ```bash
   npm test
   ```
3. Run `curl localhost:3000/address` to see JSON response or alternatively use Postman or a web browser.

