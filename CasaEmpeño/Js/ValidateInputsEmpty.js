function ValidateRequiredInputs(arrInputs, arrMessage) {
    let allReqInputsIsNotEmpty = true;
    for (var i = 0; i < arrInputs.length; i++) {
        if (document.getElementById(arrInputs[i]).value == '') {
            document.getElementById(arrMessage[i]).innerText = 'Este campo es obligatorio';
            allReqInputsIsNotEmpty = false;
        }
        else {
            document.getElementById(arrMessage[i]).innerText = '';
        }
    }

    return allReqInputsIsNotEmpty;
}