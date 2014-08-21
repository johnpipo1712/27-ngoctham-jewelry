


function CheckPst(CUSTOMER_CD, control) {

    $.ajax({
        url: '/Customer/CheckPstAjax',

        type: 'POST',

        data: { CUSTOMER_CD: CUSTOMER_CD, CHECK: control.checked },

        dataType: 'json',

        success: function (results) {

        },
        error: function (results) {
            alert('Lỗi');
        }


    });

}
