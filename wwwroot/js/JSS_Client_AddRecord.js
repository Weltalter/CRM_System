const Client_AddRecord_form = document.getElementById('AddClient');

Client_AddRecord_form.addEventListener('submit', function (event) {
    event.preventDefault();

    const middleNameScript = document.querySelector('input[name="MiddleName"]').value;
    const firstNameScript = document.querySelector('input[name="FirstName"]').value;
    const lastNameScript = document.querySelector('input[name="LastName"]').value;
    const birthDateScript = document.querySelector('input[name="BirthDate"]').value;


    console.log('Фамилия:', middleNameScript);
    console.log('Имя:', firstNameScript);
    console.log('Отчество:', lastNameScript);
    console.log('Дата рождения:', birthDateScript);

    const client = {
        firstName: firstNameScript,
        middleName: middleNameScript,
        lastName: lastNameScript,
        birthdate: birthDateScript
    };

    let error = formValidate(Client_AddRecord_form);

    if (error === 0) {
        fetch('/JScript/AddClient', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(client)
        })
            .then((response) => {
                if (!response.ok) {
                    return response.json().then((error) => {
                        throw new Error(error.error);
                    });
                }
                return response.json();
            })
            .then(data => {
                alert('Клиент успешно добавлен')
                console.log('Клиент успешно добавлен:');
                console.log(data);
                Client_AddRecord_form.reset();
            })
            .catch(error => {
                alert(error)
                console.log('Ошибка при добавлении клиента:');
                console.error(error);
            });
    }
    else {
        alert('Заполните обязательные поля');
    }

    function formValidate(Client_AddRecord_form) {
        let error = 0;
        let formReq = document.querySelectorAll('._req');

        for (let index = 0; index < formReq.length; index++) {
            const input = formReq[index];
            formRemoveError(input);

            if (input.classList.contains('_name')) {
                if (nameTest(input)) {
                    formAddError(input);
                    error++;
                }
            } else {
                if (input.value === '') {
                    formAddError(input);
                    error++;
                }
            }
        }
        return error;
    }

    function formAddError(input) {
        input.parentElement.classList.add('_error');
        input.classList.add('_error');
    }
    function formRemoveError(input) {
        input.parentElement.classList.remove('_error');
        input.classList.remove('_error');
    }
    function nameTest(input) {
        return !/^[a-zA-Zа-яА-ЯёЁ]+$/.test(input.value);
    }
});



