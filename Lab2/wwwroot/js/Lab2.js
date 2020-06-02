const uri = 'api/Medicines';
let medicines = [];

function getMedicines() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayMedicines(data))
        .catch(error => console.error('Unable to get medicines.', error));
}

function addMedicine() {
    const addNameTextbox = document.getElementById('add-name');
    const addLimitationTextbox = document.getElementById('add-limitation');

    const medicine = {
        name: addNameTextbox.value.trim(),
        limitation: addLimitationTextbox.value.trim(),
    };

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(medicine)
    })
        .then(response => response.json())
        .then(() => {
            getMedicines();
            addNameTextbox.value = '';
            addLimitationTextbox.value = '';
        })
        .catch(error => console.error('Unable to add medicine.', error));
}

function deleteMedicine(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => getMedicines())
        .catch(error => console.error('Unable to delete medicine.', error));
}

function displayEditForm(id) {
    const medicine = medicines.find(medicine => medicine.id === id);

    document.getElementById('edit-id').value = medicine.id;
    document.getElementById('edit-name').value = medicine.name;
    document.getElementById('edit-limitation').value = medicine.limitation;
    document.getElementById('editForm').style.display = 'block';
}

function updateMedicine() {
    const medicineId = document.getElementById('edit-id').value;
    const medicine = {
        id: parseInt(medicineId, 10),
        name: document.getElementById('edit-name').value.trim(),
        limitation: document.getElementById('edit-limitation').value.trim()
    };

    fetch(`${uri}/${medicineId}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(medicine)
    })
        .then(() => getMedicines())
        .catch(error => console.error('Unable to update medicine.', error));

    closeInput();

    return false;
}

function closeInput() {
    document.getElementById('editForm').style.display = 'none';
}


function _displayMedicines(data) {
    const tBody = document.getElementById('medicines');
    tBody.innerHTML = '';


    const button = document.createElement('button');

    data.forEach(medicine => {
        let editButton = button.cloneNode(false);
        editButton.innerText = 'Edit';
        editButton.setAttribute('onclick', `displayEditForm(${medicine.id})`);

        let deleteButton = button.cloneNode(false);
        deleteButton.innerText = 'Delete';
        deleteButton.setAttribute('onclick', `deleteMedicine(${medicine.id})`);

        let tr = tBody.insertRow();


        let td1 = tr.insertCell(0);
        let textNode = document.createTextNode(medicine.name);
        td1.appendChild(textNode);

        let td2 = tr.insertCell(1);
        let textNodeLimitation = document.createTextNode(medicine.limitation);
        td2.appendChild(textNodeLimitation);

        let td3 = tr.insertCell(2);
        td3.appendChild(editButton);

        let td4 = tr.insertCell(3);
        td4.appendChild(deleteButton);
    });

    medicines = data;
}
