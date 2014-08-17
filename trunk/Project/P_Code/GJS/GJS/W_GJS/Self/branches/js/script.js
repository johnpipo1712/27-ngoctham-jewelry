


function GetDCity() {
    $("#spansearchD").text($("#Dcity option:selected").text());
    if ($("#Dcity").val() != "") {
        $.ajax({
            url: '/Home/GetBrancheslByDCityAJAX',

            type: 'POST',

            data: { CITIES_DETAIL_CD: $("#Dcity").val() },

            dataType: 'json',

            success: function (results) {
                $('#table-branches').empty();
                $("#table-branches").append("<tbody>" +
                    "<tr>" +
                        "<td class=\"sys1\">Tên chi nhánh </td>" +
                        "<td class=\"sys2\">Địa chỉ</td>" +
                        "<td class=\"sys3\">Điện thoại</td>" +
                    "</tr>");

                for (var i = 0; i < results.length; i++) {
                    if (i % 2 == 0) {
                        $("#table-branches").append("<tr>" +
                                    "<td class=\"sys1\">" + results[i].BRANCH_NAME + "</td>" +
                                    "<td class=\"sys2\">" + results[i].ADDRESS + "</td>" +
                                    "<td class=\"sys3\">" + results[i].PHONE + "</td>" +
                                "</tr>");
                    }
                    else {
                        $("#table-branches").append("<tr class=\"even\">" +
                                    "<td class=\"sys1\">" + results[i].BRANCH_NAME + "</td>" +
                                    "<td class=\"sys2\">" + results[i].ADDRESS + "</td>" +
                                    "<td class=\"sys3\">" + results[i].PHONE + "</td>" +
                                "</tr>");
                    }

                }
                $("#table-branches").append("</tbody>");
            },
            error: function (results) {
                alert('checkloi');
            }


        });
    }
    else {
        $.ajax({
            url: '/Home/GetBrancheslByCityAJAX',

            type: 'POST',

            data: { CITIES_CD: $("#city").val() },

            dataType: 'json',

            success: function (results) {
                $('#table-branches').empty();
                $("#table-branches").append("<tbody>" +
                    "<tr>" +
                        "<td class=\"sys1\">Tên chi nhánh </td>" +
                        "<td class=\"sys2\">Địa chỉ</td>" +
                        "<td class=\"sys3\">Điện thoại</td>" +
                    "</tr>");

                for (var i = 0; i < results.length; i++) {
                    if (i % 2 == 0) {
                        $("#table-branches").append("<tr>" +
                                    "<td class=\"sys1\">" + results[i].BRANCH_NAME + "</td>" +
                                    "<td class=\"sys2\">" + results[i].ADDRESS + "</td>" +
                                    "<td class=\"sys3\">" + results[i].PHONE + "</td>" +
                                "</tr>");
                    }
                    else {
                        $("#table-branches").append("<tr class=\"even\">" +
                                    "<td class=\"sys1\">" + results[i].BRANCH_NAME + "</td>" +
                                    "<td class=\"sys2\">" + results[i].ADDRESS + "</td>" +
                                    "<td class=\"sys3\">" + results[i].PHONE + "</td>" +
                                "</tr>");
                    }

                }
                $("#table-branches").append("</tbody>");
            },
            error: function (results) {
                alert('checkloi');
            }


        });
    }

}
function GetCity() {

    $("#spansearch").text($("#city option:selected").text());

    $.ajax({
        url: '/Home/GetDetailByCityAJAX',

        type: 'POST',

        data: { CITIES_CD: $("#city").val() },

        dataType: 'json',

        success: function (results) {
            $('#Dcity').empty();
            $("#Dcity").append("<option value=\"\">---</option>");
            $("#spansearchD").text("---");
            for (var i = 0; i < results.length; i++) {
                $("#Dcity").append("<option value=\"" + results[i].CITIES_DETAIL_CD + "\">" + results[i].CITIES_DETAIL_NAME + "</option>");

            }
        },
        error: function (results) {
            alert('checkloi');
        }


    });

    $.ajax({
        url: '/Home/GetBrancheslByCityAJAX',

        type: 'POST',

        data: { CITIES_CD: $("#city").val() },

        dataType: 'json',

        success: function (results) {
            $('#table-branches').empty();
            $("#table-branches").append("<tbody>" +
                "<tr>" +
                    "<td class=\"sys1\">Tên chi nhánh </td>" +
                    "<td class=\"sys2\">Địa chỉ</td>" +
                    "<td class=\"sys3\">Điện thoại</td>" +
                "</tr>");

            for (var i = 0; i < results.length; i++) {
                if (i % 2 == 0) {
                    $("#table-branches").append("<tr>" +
                                "<td class=\"sys1\">" + results[i].BRANCH_NAME + "</td>" +
                                "<td class=\"sys2\">" + results[i].ADDRESS + "</td>" +
                                "<td class=\"sys3\">" + results[i].PHONE + "</td>" +
                            "</tr>");
                }
                else {
                    $("#table-branches").append("<tr class=\"even\">" +
                                "<td class=\"sys1\">" + results[i].BRANCH_NAME + "</td>" +
                                "<td class=\"sys2\">" + results[i].ADDRESS + "</td>" +
                                "<td class=\"sys3\">" + results[i].PHONE + "</td>" +
                            "</tr>");
                }

            }
            $("#table-branches").append("</tbody>");
        },
        error: function (results) {
            alert('checkloi');
        }


    });
}
