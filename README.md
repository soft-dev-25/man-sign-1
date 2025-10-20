# man-sign-1

## How to Start the Project

Make sure to setup the `.env` in the root of the project.

Run `docker compose up -d`

## How to test

### Unit tests

Run `npm run unit-test`

### Integration tests

Run `npm run integration-test`

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

