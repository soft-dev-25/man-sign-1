import './style.css'

const baseUrl = import.meta.env.VITE_API_URL || 'http://localhost:3000';

document.querySelector('#app').innerHTML = `
  <header>
      <h1>Fake Personal Data Generator</h1>
  </header>
  <main>
      <section id="description">
          <p>This application generates fake personal data for Danish persons.</p>
      </section>
      <form id="frmGenerate">
          <fieldset>
              <div id="person">
                  <input type="radio" name="fake-data" id="chkPerson" checked>
                  <input type="number" id="txtNumberPersons" min="1" max="100" value="1" required>
                  <label for="chkPerson">person(s)</label>
              </div>
              <div id="partialOptions">
                  <input type="radio" name="fake-data" id="chkPartialOptions">
                  <label for="chkPartialOptions">Partial generation:</label>
                  <select id="cmbPartialOptions">
                      <option value="cpr" selected>CPR</option>
                      <option value="name-gender">Name and gender</option>
                      <option value="name-gender-dob">Name, gender and birthdate</option>
                      <option value="cpr-name-gender">CPR, name and gender</option>
                      <option value="cpr-name-gender-dob">CPR, name, gender, birthdate</option>
                      <option value="address">Address</option>
                      <option value="phone">Phone number</option>
                  </select>
              </div>
              <div id="submit">
                  <input type="submit" value="Generate">
              </div>
          </fieldset>
      </form>
      <section id="output" class="hidden"></section>
  </main>
  <footer>
      <p>&copy; 2024 Arturo Mora-Rioja</p>
  </footer>
  <template id="personTemplate">
      <article class="personCard">
          <p class="hidden cpr" grid-area="leftColumn">CPR: </p>
          <p class="hidden cprValue" grid-area="rightColumn"></p>
          <p class="hidden firstName" grid-area="leftColumn">First name: </p>
          <p class="hidden firstNameValue" grid-area="rightColumn"></p>
          <p class="hidden lastName" grid-area="leftColumn">Last name: </p>
          <p class="hidden lastNameValue" grid-area="rightColumn"></p>
          <p class="hidden gender" grid-area="leftColumn">Gender: </p>
          <p class="hidden genderValue" grid-area="rightColumn"></p>
          <p class="hidden dob" grid-area="leftColumn">Date of birth: </p>
          <p class="hidden dobValue" grid-area="rightColumn"></p>
          <p class="hidden address" grid-area="leftColumn">Address:</p>
          <!-- <div> -->
          <!-- Street, number, floor and door -->
          <p class="hidden streetValue" grid-area="rightColumn"></p>
          <!-- Postal code and town name -->
          <p class="hidden townValue" grid-area="rightColumn"></p>
          <!-- </div> -->
          <p class="hidden phoneNumber" grid-area="leftColumn">Phone number: </p>
          <p class="hidden phoneNumberValue" grid-area="rightColumn"></p>
      </article>
  </template>
`

document.querySelector('#frmGenerate').addEventListener('submit', (e) => {
    e.preventDefault();

    // The endpoint is inferred from the selected option
    let endpoint = '/';
    if (e.target.chkPerson.checked) {
        endpoint += 'person'
        const numPersons = parseInt(e.target.txtNumberPersons.value);
        if (numPersons > 1) {
            endpoint += '?n=' + numPersons;
        }
    } else {
        endpoint += e.target.cmbPartialOptions.value;
    }

    // API call
    fetch(baseUrl + endpoint)
        .then(response => {
            if (!response.ok) {
                handleError();
            } else {
                return response.json();
            }
        })
        .then(handlePersonData)
        .catch(handleError);
});

const handlePersonData = (data) => {
    const output = document.querySelector('#output');
    output.innerHTML = '';

    if (data.length === undefined) {
        data = [data];
    }

    data.forEach(item => {
        const personCard = document.importNode(document.getElementById('personTemplate').content, true);
        if (item.CPR !== undefined) {
            const cprValue = personCard.querySelector('.cprValue');
            cprValue.innerText = item.CPR;
            cprValue.classList.remove('hidden');
            personCard.querySelector('.cpr').classList.remove('hidden');
        }
        if (item.firstName !== undefined) {
            const firstNameValue = personCard.querySelector('.firstNameValue');
            firstNameValue.innerText = item.firstName;
            firstNameValue.classList.remove('hidden');
            const lastNameValue = personCard.querySelector('.lastNameValue');
            lastNameValue.innerText = item.lastName;
            lastNameValue.classList.remove('hidden');
            personCard.querySelector('.firstName').classList.remove('hidden');
            personCard.querySelector('.lastName').classList.remove('hidden');
        }
        if (item.gender !== undefined) {
            const genderValue = personCard.querySelector('.genderValue');
            genderValue.innerText = item.gender;
            genderValue.classList.remove('hidden');
            personCard.querySelector('.gender').classList.remove('hidden');
        }
        if (item.birthDate !== undefined) {
            const dobValue = personCard.querySelector('.dobValue');
            dobValue.innerText = item.birthDate;
            dobValue.classList.remove('hidden');
            personCard.querySelector('.dob').classList.remove('hidden');
        }
        if (item.address !== undefined) {
            const streetValue = personCard.querySelector('.streetValue');
            streetValue.innerText = `${item.address.street} ${item.address.number}, ${item.address.floor}.${item.address.door}`;
            streetValue.classList.remove('hidden');
            const townValue = personCard.querySelector('.townValue');
            townValue.innerText = `${item.address.postal_code} ${item.address.town_name}`;
            townValue.classList.remove('hidden');
            personCard.querySelector('.address').classList.remove('hidden');
        }
        if (item.phoneNumber !== undefined) {
            const phoneNumberValue = personCard.querySelector('.phoneNumberValue');
            phoneNumberValue.innerText = item.phoneNumber;
            phoneNumberValue.classList.remove('hidden');
            personCard.querySelector('.phoneNumber').classList.remove('hidden');
        }

        output.appendChild(personCard);
    });
    output.classList.remove('hidden');
};

const handleError = () => {
    const output = document.querySelector('#output');

    output.innerHTML =
        '<p>There was a problem communicating with the API</p>';
    output.classList.add('error');

    setTimeout(() => {
        output.innerHTML = '';
        output.classList.remove('error');
    }, 2000);
};