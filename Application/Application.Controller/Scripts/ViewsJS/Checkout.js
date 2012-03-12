 jQuery.support.cors = true;
var customersAddress = "/api/customers";
var URL = "http://localhost:50284/api/";

$(function () {
    $(".Login").live("click", function () {
        var userName = $("#txtUserID").val();
        var password = $("#pwdPassword").val();
        if (userName == "" || userName == null) {
            alert("Customer ID cannot be null.")
            $("#txttxtUserID").focus();
            return false;
        }
        else if (password == "" || password == null) {
            alert("Password cannot be null.")
            $("#pwdPassword").focus();
            return false;
        }
        else {
            var parameter = "/" + userName + "/" + password;
            $.ajax({
                type: "GET",
                dataType: "json",
                url: customersAddress + parameter,
                context: this,
                success: function (value) {
                    alert(value);
                }
            });
        }
        return false;
    });

    $("#customerInformation").submit(function () {
        //if (ValidateForm()) {
            $.post(
                    customersAddress,
                    $("#customerInformation").serialize(),
                    function (value) {
                        if ($("#txtCustomerID").val() == 0) {
                            alert("Record added successfully.");
                            $("form")[0].reset();
                        }
                        else {
                            alert("Record updated successfully.");
                        }
                    },
                    "json"
                );
        //}
        return false;
    });
});                                                         