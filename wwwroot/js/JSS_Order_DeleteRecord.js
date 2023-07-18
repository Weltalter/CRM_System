const Order_DeleteRecord_form = document.getElementById('RemoveOrder');

Order_DeleteRecord_form.addEventListener('submit', function (event) {
    event.preventDefault();

    const orderIDScript = document.querySelector('input[name="OrderID"]').value;

    console.log('ID заказа для удаления:', orderIDScript);

    let error = formValidate(Order_DeleteRecord_form);

    if (error === 0) {
        fetch('/JScript/RemoveOrder', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(orderIDScript)
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
                alert('Заказ успешно удален');
                console.log('Заказ успешно удален:');
                console.log(data);
                Order_DeleteRecord_form.reset();
            })
            .catch(error => {
                alert(error);
                console.log('Ошибка при удалении заказа:');
                console.error(error);
            });
    }
    else {
        alert('Заполните обязательные поля');
    }

    function formValidate(Order_DeleteRecord_form) {
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



