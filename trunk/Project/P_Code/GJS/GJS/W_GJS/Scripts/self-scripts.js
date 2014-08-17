inProgressLogin = false;

$( "#login-button" ).click(function() {
    if (!inProgressLogin) {
        inProgressLogin = true;
        $("#loadingDivLogin").show();
        $.post($(this).data("action"), $('#form-login').serialize(),
            function (data) { 
                $("#error-login").append(data.ErrorString);
                $("#loadingDivLogin").hide();
                inProgressLogin = false;
        });
    }
});

