//$(function () {
//    $("#menuDrawer").css('display', 'none').css('visibility', 'hidden');;

//    var menuStatus = sessionStorage.getItem("menuActive");
//    if (menuStatus == "0") {
//        $("#menuDrawer").css('display', 'none').css('visibility', 'hidden');;
//    } else {
//        $("#menuDrawer").css('display', 'inline').css('visibility', 'visible');
//    }
//});


//Load carousel
$(function () {
    // alert("working!");



});

$(function () {
    $("[data-toggle='tooltip']").tooltip();

    function searchFailed() {
        $("#searchresults").html("<div class='bg-info'>Sorry, there was a problem with the search.</div>");
    }
});


$(function() {

    $("#leftMenu").hide();

    $("#menuDrawer").on("click", function(event) {
        event.preventDefault();
        //alert("clicked");
        $("#leftMenu").show().animate({ left: "-5px", top: "0px" }); 
        //$(this).hide();
        $("#toggler1").show();
    });

    $("#toggler1").on("click", function(e) {
        e.preventDefault();
        $("#leftMenu").animate({ left: "-600px", top: "0px" });
        //$("#leftMenu").show();
    });
});


$(function() {
    $("#phone1Cb").click(function() {
        if ($("#phone1Cb").prop("checked")) {
            alert("Is checked on");
        } else {
            alert("Is checked off");
        }
    });
});


$(function() {
    $("#SpouseName").hide();
    $("#MaritalStatus").change(function() {
        var selectedIndex = $("#MaritalStatus").prop("selectedIndex");
        if (selectedIndex > 1) {
            $("#SpouseName").show();
        } else {
            $("#SpouseName").hide();
        }
    });
});