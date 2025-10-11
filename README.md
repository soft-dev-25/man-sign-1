# man-sign-1

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
</table>
