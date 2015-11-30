$(function () {
    //alert("working child page!");
    //hide form email onLoad
    var frmStatus;
    frmStatus = $("#ctl00_ContentPlaceHolder1_rbnloginOption_0").val();
    if (frmStatus == "0") {
        $("#formEmail").hide();
        $("#formId").show();
    } else {
        $("#formEmail").show();
        $("#formId").hide();
    }
    $("#ctl00_ContentPlaceHolder1_rbnloginOption_0").click(function () {
        $("#formId").show();
        $("#formEmail").hide();
    });
    $("#ctl00_ContentPlaceHolder1_rbnloginOption_1").click(function () {
        $("#formId").hide();
        $("#formEmail").show();
    });


    //define the processing modal
    var pleaseWait = $('#pleaseWaitDialog');
    var showPleaseWait = function () {
        pleaseWait.modal('show');
    };
    var hidePleaseWait = function () {
        pleaseWait.modal('hide');
    };


    function onFailure(response) {
        //debugger;
        $("#returnMsg").html("");
        $("#returnMsg").html("<h4>Failure!!! <br/> Login failed, contact the admin!<br/><br/>Click screen to try again!</h4>");
    }

    function retrieveLoginValues(admobjects) {
        var menuItem = new Object();

        var userPage = [];

        $.each(admobjects, function () {
            var admobject = $(this);
            var uRole = $(this).find("SEC_USER_ROLE").text();
            if (uRole == "0") {
                $("#returnMsg").html("");
                $("#returnMsg").html("<h4>User account has not been activated, contact admin for activation!<br/><br/>Click screen to try again!</h4>");
                //alert("User has not been activated, contact admin to activate account!");
                return false;
            }

            userPage.push({ userRole: $(this).find("SEC_USER_ROLE").text(), userName: $(this).find("SEC_USER_NAME").text() });

            var eString = JSON.stringify(userPage);
            sessionStorage.setItem("userRole", "");
            sessionStorage.setItem("userRole", eString);

            sessionStorage.setItem("menuActive", "0");
            sessionStorage.setItem("menuActive", "1");

            //move to next page
            window.location.href = "dashboard.aspx";

            return false;
        });
    }

    function onSuccessLogin(response) {
        //debugger;
        console.log(response.d);

        var xmlDoc = $.parseXML(response.d);
        var xml = $(xmlDoc);
        var admobjects = xml.find("Table");
        retrieveLoginValues(admobjects);
    }

    function onError(response) {
        var errorText = response.responseText;
        $("#returnMsg").html("<h4>Error!!! <br/>Invalid user details!<br/><br/>Click screen to try again!</h4>");

    }

    function doLogin(inputEmail, inputPassword) {
        $.ajax({
            type: "POST",
            url: "Login.aspx/DoLogin",
            data: "{userName : '" + inputEmail + "', userPassword : '" + inputPassword + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: onSuccessLogin,
            failure: onFailure,
            error: onError
        });
        // this avoids page refresh on button click
        return false;
    }

    $("#loginBtn").click(function (e) {
        e.preventDefault();
        var inputEmail = $("#txtEmail").val();
        var inputPassword = $("#txtPassword").val();
        if ((inputEmail != null) || inputPassword != null) {
            showPleaseWait();
            $("#returnMsg").html("");
            doLogin(inputEmail, inputPassword);
        } else {
            $("#returnMsg").html("");
            $("#returnMsg").html("<h4>Login fields cannot be empty.<br/><br/>Click screen to try again!</h4>");
        }
    });


    function onSuccessUserId(response) {
        console.log(response.d);
        $("#txtUserName").val(response.d);
        hidePleaseWait();
    }

    function onSuccessUserLogin(response) {
        var res = response.d;
        if (res == "1") {
            location.href = "dashboard.aspx";
        } else {
            $("#returnMsg").html("");
            $("#returnMsg").html("<h4>Login failed for user.<br/><br/>Click screen to try again!</h4>");
        }
    }

    function getUserIdName(userId) {
        $.ajax({
            type: "POST",
            url: "Login.aspx/GetUserIdName",
            data: "{userId : '" + userId + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: onSuccessUserId,
            failure: onFailure,
            error: onError
        });
        // this avoids page refresh on button click
        return false;
    }

    function getUserIdLogin(userId, userPwd) {
        $.ajax({
            type: "POST",
            url: "Login.aspx/GetUserIdLogin",
            data: "{userId : '" + userId + "', userPwd : '" + userPwd + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: onSuccessUserLogin,
            failure: onFailure,
            error: onError
        });
        // this avoids page refresh on button click
        return false;
    }

    $("#txtUserID").blur(function () {
        //alert("Blur
        if ($("#txtUserID").val() !== "") {
            showPleaseWait();
            var userId = $("#txtUserID").val().trim();
            getUserIdName(userId);
        } else {
            alert("User ID field connot be empty!");
        }

    });


    $("#loginBtnID").click(function (e) {
        e.preventDefault();
        if ($("#txtUserID").val() !== "" && $("#txtPasswordID").val() !== "") {
            showPleaseWait();
            var userId = $("#txtUserID").val().trim();
            var userPwd = $("#txtPasswordID").val().trim();
            getUserIdLogin(userId, userPwd);
        }


    });
});