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

This is the repository for the mandatory assignment #1 in the Test Class.

Make sure to run `npm install` after cloning this repository to use Husky's pre-commit hook.

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

</td>
</tr>
<tr>
<td> <code>/name-gender</code> </td>
<td> Receive a random person's first name, last name and gender </td>
<td>

```json
{
 "firstName": "Nanna P.",
 "lastName": "Paulsen",
 "gender": "female"
}
```

</td>
</tr>
<tr>
<td> <code>/name-gender-dob</code> </td>
<td> Receive a random person's first name, last name, gender and date of birth (YYYY-MM-DD) </td>
<td>

```json
{
 "firstName": "Nanna P.",
 "lastName": "Paulsen",
 "gender": "female",
 "birthDate": "2012-11-29"
}
```

</td>
</tr>
<tr>
<td> <code>/phone</code> </td>
<td> Receive a random 8-digit phone number </td>
<td>

```json
{
 "phoneNumber": "78678391"
}
```

</td>
</tr>
<tr>
<td> <code>/cpr-name-gender</code> </td>
<td> Receive a random person's first name, last name, gender and cpr </td>
<td>

```json
{
  "CPR":"0503523211",
  "firstName":"Sander S.",
  "lastName":"Friis",
  "gender":"male"
}
```

</td>
</tr>
<tr>
<td> <code>/cpr-name-gender-dob</code> </td>
<td> Receive a random person's first name, last name, gender, cpr and date of birth (YYYY-MM-DD) </td>
<td>

```json
{
  "CPR":"2501803713",
  "firstName":"Rasmus B.",
  "lastName":"Friis",
  "gender":"male",
  "birthDate":"1980-01-25"
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

