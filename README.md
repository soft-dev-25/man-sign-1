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

