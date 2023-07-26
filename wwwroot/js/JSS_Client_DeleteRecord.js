const Client_DeleteRecord_form = document.getElementById('RemoveClient');

Client_DeleteRecord_form.addEventListener('submit', function (event) {
    event.preventDefault();

    const clientIDScript = document.querySelector('input[name="ClientID"]').value;

    console.log('ID клиента для удаления:', clientIDScript);

    let error = formValidate(Client_DeleteRecord_form);

    if (error === 0) {
        fetch('/JScript/RemoveClient', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(clientIDScript)
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
                alert('Клиент успешно удален');
                console.log('Клиент успешно удален:');
                console.log(data);
                Client_DeleteRecord_form.reset();
            })
            .catch(error => {
                alert(error);
                console.log('Ошибка при удалении клиента:', error);
            });
    }
    else {
        alert('Заполните обязательные поля');
    }

    function formValidate(Client_DeleteRecord_form) {
        let error = 0;
        let formReq = document.querySelectorAll('._req');

        for (let index = 0; index < formReq.length; index++) {
            const input = formReq[index];
            formRemoveError(input);

            if (input.classList.contains('_num')) {
                if (numTest(input)) {
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
    function numTest(input) {
        return !/^[0-9]+$/.test(input.value);
    }
});



