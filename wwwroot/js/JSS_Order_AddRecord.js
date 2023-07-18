const Order_AddRecord_form = document.getElementById('AddOrder');

Order_AddRecord_form.addEventListener('submit', function (event) {
    event.preventDefault();

    const clientIDScript = document.querySelector('input[name="ClientID"]').value;
    const describtionScript = document.querySelector('input[name="Describtion"]').value;
    const priceScript = document.querySelector('input[name="Price"]').value;
    const orderDateScript = document.querySelector('input[name="OrderDate"]').value;


    console.log('ID клиента:', clientIDScript);
    console.log('Описание:', describtionScript);
    console.log('Цена:', priceScript);
    console.log('Дата заказа:', orderDateScript);

    const order = {
        clientID: clientIDScript,
        desc: describtionScript,
        price: priceScript,
        orderDate: orderDateScript
    };

    let error = formValidate(Order_AddRecord_form);

    if (error === 0) {
        fetch('/JScript/AddOrder', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(order)
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
                alert('Заказ успешно добавлен');
                console.log('Заказ успешно добавлен:');
                console.log(data);
                Order_AddRecord_form.reset();
            })
            .catch(error => {
                alert(error);
                console.log('Ошибка при добавлении заказа:', error);
            });
    }
    else {
        alert('Заполните обязательные поля');
    }

    function formValidate(Order_AddRecord_form) {
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



