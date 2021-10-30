let url = 'http://localhost:3030/jsonstore/collections/students';

let tbody = document.querySelector('#results tbody');
loadStudentsInTable();

let form = document.getElementById('form');
form.addEventListener('submit', onSubmitHandler)

function onSubmitHandler(e) {
    e.preventDefault();
    let formData = new FormData(e.currentTarget);

    let firstName = formData.get('firstName');
    let lastName = formData.get('lastName');
    let facultyNumber = formData.get('facultyNumber');
    let grade = formData.get('grade');

    if (firstName.trim() === '' || lastName.trim() === '' || facultyNumber.trim() === '' || grade.trim() === '') {
        return;
    }
    let body = JSON.stringify({
        firstName,
        lastName,
        facultyNumber,
        grade
    });

    fetch(url, {
        method: 'POST',
        headers: { 'Content-Type': 'application.json' },
        body
    })
        .then(() => createTableRow(firstName, lastName, facultyNumber, grade))
        .catch(err => {
            console.error(err.message);
        })

    form.reset();
}


async function loadStudentsInTable() {
    try {
        let students = await fetch(url).then(res => res.json());
        Object.values(students)
            .forEach(student => {
                createTableRow(student.firstName, student.lastName, student.facultyNumber, student.grade);
            })
    } catch (error) {
        console.error(error.message);
    }


}

function createTableRow(firstName, lastName, facultyNumber, grade) {
    let tdFirstName = document.createElement('td');
    tdFirstName.textContent = firstName;

    let tdLastName = document.createElement('td');
    tdLastName.textContent = lastName;

    let tdFacultyNumber = document.createElement('td');
    tdFacultyNumber.textContent = facultyNumber;

    let tdGrade = document.createElement('td');
    tdGrade.textContent = grade;

    let tr = document.createElement('tr');
    tr.appendChild(tdFirstName);
    tr.appendChild(tdLastName);
    tr.appendChild(tdFacultyNumber);
    tr.appendChild(tdGrade);

    tbody.appendChild(tr);
}