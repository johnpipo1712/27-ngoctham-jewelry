// LOGIN

function login() {
    if (!inProgressLogin) {
        inProgressLogin = true;
        $("#loadingDivLogin").show();
        $("#error-login").hide();
        $.post($("#login-button").data("action"), $('#form-login').serialize(),
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
    return false; //stop submit form.
}

inProgressLogin = false;
$( "#login-button" ).click(function() {
    login();
});

$("#form-login").submit(function (event) {
    login();
    event.preventDefault();
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

// CONTACT
inProgressContact = false;
$("#contact-button").click(function () {
    if (!inProgressContact) {
        inProgressContact = true;
        $("#loadingDivContact").show();
        $("#error-contact").hide();
        $.post($(this).data("action"), $('#form-contact').serialize(),
            function (data) {
                if (data.HasError) {
                    $("#error-contact").html(data.ErrorString);
                    $("#loadingDivContact").hide();
                    inProgressContact = false;
                    $("#error-contact").show();

                } else {
                    $("#loadingDivContact").hide();
                    $("#BookingModal").modal('hide');
                    $("#ContactSuccesfully").modal('show');
                }
            });
    }
});


// LOGOUT
inProgressLogout = false;
$("#logout-button").click(function () {
    if (!inProgressLogout) {
        inProgressLogout = true;
        $.post($(this).data("action"),
            function (data) {
                if (!data.HasError) {
                    window.location.href = $("#logout-button").data("success-action");
                }
                inProgressLogout = false;
            });
    }
});

// ADD CART with ROLEs
$(".add-cart").click(function () {
    $("#LoginModal").modal('show');
    //$("#loginModelShow").show();
});
