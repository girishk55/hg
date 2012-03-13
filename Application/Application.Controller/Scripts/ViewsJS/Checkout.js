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
                success: function (value) {
                    if (value == null) {
                        alert("Record not found with provided credentials, please register first.");
                    }
                    else {
                        $("#customerInformation").show();
                        $("#tblLogin").hide();
                        document.getElementById("lblName").innerHTML = value.FirstName + " " + value.LastName;
                        $("#tblLogout").show();
                        $("#txtCustomerID").val(value.CustomerID);
                        $("#txtTitle").val(value.Title);
                        $("#txtFirstName").val(value.FirstName);
                        $("#txtMiddleName").val(value.MiddleName);
                        $("#txtLastName").val(value.LastName);
                        $("#txtSuffix").val(value.Suffix);
                        $("#txtCompanyName").val(value.CompanyName);
                        $("#txtEmailAddress").val(value.EmailAddress);
                        $("#txtPhone").val(value.Phone);
                        $("#txtPassword").val(password);
                        $("#txtConfirmPassword").val(password);

                        $("#txtBAddressLine1").val(value.BillingAddressLine1);
                        $("#txtBAddressLine2").val(value.BillingAddressLine2);
                        $("#txtBCity").val(value.BillingCity);
                        $("#txtBStateProvince").val(value.BillingStateProvince);
                        $("#txtBCountryRegion").val(value.BillingCountryRegion);
                        $("#txtBPostalCode").val(value.BillingPostalCode);

                        $("#txtSAddressLine1").val(value.ShippingAddressLine1);
                        $("#txtSAddressLine2").val(value.ShippingAddressLine2);
                        $("#txtSCity").val(value.ShippingCity);
                        $("#txtSStateProvince").val(value.ShippingStateProvince);
                        $("#txtSCountryRegion").val(value.ShippingCountryRegion);
                        $("#txtSPostalCode").val(value.ShippingPostalCode);
                        $("#btnReset").val("Update");
                    }
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

function ClearForm() {
    $("#tblLogin").show();
    $("#tblLogout").hide();
    $("form")[0].reset();
}

function RegisterNewCustomer() {
    ClearForm();
    $('#customerInformation').show();
}                                                      