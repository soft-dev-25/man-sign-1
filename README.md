# man-sign-1

## How to Start the Project

Make sure to setup the `.env` in the root of the project.

Run `docker compose up -d`

## How to test

### Unit tests

Run `npm run unit-test`

### Integration tests

Run `npm run integration-test`

### End-To-End tests

Run `npm run e2e-test`

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
  "floor": "4",
  "door": "mf",
  "postal_code": "9400",
  "town_name": "Nørresundby"
}
```

</td>
</tr>

</td>
</tr>
</td>
</tr>

<tr>
<td> <code>/person</code> </td>
<td> Combines all the information from the other endpoints to return a "complete" person </td>
<td>

```json
{
    "CPR": "0107832911",
    "firstName": "Michelle W.",
    "lastName": "Henriksen",
    "gender": "female",
    "birthDate": "1983-07-01",
    "address": {
        "street": "GYØVCoØMeceOjøtÆgvYrøQQDascNFCHArnSNrxub",
        "number": "521",
        "floor": 74,
        "door": "tv",
        "postal_code": "8670",
        "town_name": "Låsby"
    },
    "phoneNumber": "58676658"
}
```

</td>
</tr>

<tr>
<td> <code>/persons?count=int</code> </td>
<td> Returns multiple persons with all the data combined </td>
<td>

```json
[
  {
      "CPR":"2501803713",
      "firstName":"Rasmus B.",
      "lastName":"Friis",
      "gender":"male",
      "birthDate":"1980-01-25",
      "address": {
          "street": "gIKoXUåJeVT",
          "number": "249",
          "floor": "4",
          "door": "mf",
          "postal_code": "9400",
          "town_name": "Nørresundby"
      },
      "phoneNumber": "78678391"
  },
    {
      "CPR": "0107832911",
      "firstName": "Michelle W.",
      "lastName": "Henriksen",
      "gender": "female",
      "birthDate": "1983-07-01",
      "address": {
          "street": "GYØVCoØMeceOjøtÆgvYrøQQDascNFCHArnSNrxub",
          "number": "521",
          "floor": 74,
          "door": "tv",
          "postal_code": "8670",
          "town_name": "Låsby"
      },
      "phoneNumber": "58676658"
  }
]
```

</td>
</tr>

</table>

