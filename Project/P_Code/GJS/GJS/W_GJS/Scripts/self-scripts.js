// LOGIN
inProgressLogin = false;
$( "#login-button" ).click(function() {
    if (!inProgressLogin) {
        inProgressLogin = true;
        $("#loadingDivLogin").show();
        $("#error-login").hide();
        $.post($(this).data("action"), $('#form-login').serialize(),
            function (data) {
                if (data.RoleOrFailed == 0) {
                    $("#error-login").html(data.ErrorString);
                    $("#loadingDivLogin").hide();
                    inProgressLogin = false;
                    $("#error-login").show();

                } else {
                    $("#loadingDivLogin").hide();
                    window.location.href = $("#login-button").data("success-action");
                }
        });
    }
});

// REGISTER
inProgressRegister = false;
$( "#register-button" ).click(function() {
    if (!inProgressRegister) {
        inProgressRegister = true;
        $("#loadingDivRegister").show();
        $("#error-register").hide();
        $.post($(this).data("action"), $('#form-register').serialize(),
            function (data) {
                if (data.HasError) {
                    $("#error-register").html(data.ErrorString);
                    $("#loadingDivRegister").hide();
                    inProgressRegister = false;
                    $("#error-register").show();

                } else {
                    $("#loadingDivRegister").hide();
                    $("#RegisterModal").modal('hide');
                    $("#registerSuccesfully").modal('show');
                    window.location.href = $("#register-button").data("success-action");
                }
        });
    }
});
