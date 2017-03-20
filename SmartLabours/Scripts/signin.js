

$(document).ready(function (e) {

    

    $('#signinforLabour').click(function () {
        
        var ErrStr = "";
        var Remember = "";
        if ($.trim($('#txtEmailID').val()) == '' && $.trim($('#txtpassword').val()) == '') {
            // $('#signEmailID').addClass('error');
            // $('#SignPassword').addClass('error');

            ErrStr = "Email ID should not be Empty!! \n";

            ErrStr = ErrStr + "Password should not be Empty!! \n";
            alert(ErrStr);
            return false;
        }
        else if ($.trim($('#txtEmailID').val()) != '') {
            var filter = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            //if (!filter.test($.trim($('#txtEmailID').val()))) {
            //    // $('#signEmailID').addClass('error');
            //    // $('#SignPassword').addClass('error');
            //    ErrStr = "Please Enter Valid Email ID!! \n <br>";
            //    alert(ErrStr)
            //    return false;
            //}
        }
        else if ($.trim($('#txtpassword').val()) == '') {
            $('#signEmailID').removeClass(' error');
            //$('#signEmailID').addClass('error');
            //$('#SignPassword').addClass(' error');
            ErrStr = ErrStr + "Password should not be Empty!! \n";
            alert(ErrStr);
            return false;
        }
        else if ($.trim($('#txtpassword').val()).length < 6) {
           // $('#signEmailID').removeClass(' error');
           // $('#signEmailID').addClass('error');
            // $('#SignPassword').addClass(' error');
            ErrStr = ErrStr + "Password minimum character length is 6!! \n";
            alert(ErrStr);
            return false;
        }
        if (document.getElementById("remember-me").checked == true) {

            Remember = true;
        }
        else {
            Remember = false;
        }


        $('#PloadingIns1').addClass('Inncoursrload');
        $.post('/Labour/SignInforLabour', { EmailID: $.trim($('#txtEmailID').val()), Password: $.trim($('#txtpassword').val()), RememberMe: Remember }, function (data) {
            if (data == "1") {

                window.location.href = "/LabourAccount/ProfileDetails/1";
                $('#PloadingIns1').removeClass('Inncoursrload');
            }

            else if (data == "2") {
               // $('#signEmailID').addClass('error');
                //$('#SignPassword').addClass('error');
                ErrStr =  "User Name or Password is wrong!! \n";
                alert(ErrStr);
                $('#PloadingIns1').removeClass('Inncoursrload');
            }
            else if (data == "3") {
                ErrStr =  "User Name or Password is wrong!! \n";
                alert(ErrStr);
                $('#PloadingIns1').removeClass('Inncoursrload');
            }
            else if (data == "4") {
                alert("Your account has been inactive, Kindly contact administrator");
                $('#PloadingIns1').removeClass('Inncoursrload');
                return false;
            }
        });
        return false;
    });
});



$(document).ready(function () {
    var ErrStr1 = "";
    var RememberMe1 = "";
    $('#signinforSponsor').click(function () {

        if ($.trim($('#txtsponsorEmailID').val()) == '' && $.trim($('#txtsponsorpassword').val()) == '') {
            //$('#signinsponsorEmailID').addClass('error');
            // $('#SigninsponsorPassword').addClass('error');
            ErrStr1 = "Email ID should not be Empty!! \n";

            ErrStr1 = ErrStr1 + "Password should not be empty!! \n";
            alert(ErrStr1);
            return false;
        }
        else if ($.trim($('#txtsponsorEmailID').val()) != '') {
            var filter = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;

            //if (!filter.test($.trim($('#txtsponsorEmailID').val()))) {
            //    //                $('#signinsponsorEmailID').addClass('error');
            //    //                $('#SigninsponsorPassword').addClass('error');
            //    ErrStr1 = "Please Enter Valid Email ID!!";
            //    alert(ErrStr1)
            //    return false;
            //}
        }
        else if ($.trim($('#txtpassword').val()) == '') {
            //            $('#signinsponsorEmailID').removeClass(' error');
            ////            $('#signinsponsorEmailID').addClass('error');
            //            $('#SigninsponsorPassword').addClass(' error');
            ErrStr1 = ErrStr1 + "Password should not be empty!! \n";
            alert(ErrStr1);
            return false;
        }
        else if ($.trim($('#txtpassword').val()).length < 6) {
            //            $('#signinsponsorEmailID').removeClass(' error');
            //            $('#signinsponsorEmailID').addClass('error');
            //            $('#SigninsponsorPassword').addClass(' error');
            ErrStr1 = ErrStr1 + "Password minimum character length is 6!! \n";
            alert(ErrStr1);
            return false;
        }
        if (document.getElementById("remember-mesponsor").checked == true) {

            Remember1 = true;
        }
        else {
            Remember1 = false;
        }

        $('#PloadingIns1').addClass('Inncoursrload');
        $.post('/Sponsor/SignInforSponsor', { EmailID: $.trim($('#txtsponsorEmailID').val()), Password: $.trim($('#txtsponsorpassword').val()), RememberMe: Remember1 }, function (data) {
            if (data == "1") {

                window.location.href = "/SponsorAccount/ProfileDetails/1";
                $('#PloadingIns1').removeClass('Inncoursrload');
            }

            else if (data == "2") {
                //                $('#signinsponsorEmailID').addClass('email');
                //                $('#SigninsponsorPassword').addClass('password error');
                ErrStr1 = "User Name or Password is wrong!! \n";
                alert(ErrStr1);
                $('#PloadingIns1').removeClass('Inncoursrload');
            }
            else if (data == "3") {
                //                $('#signinsponsorEmailID').addClass('email error');
                //                $('#SigninsponsorPassword').addClass('password');
                ErrStr1 = "User Name or Password is wrong!! \n";
                alert(ErrStr1);
                $('#PloadingIns1').removeClass('Inncoursrload');
            }
            else if (data == "4") {
                alert("Your account has been inactive, Kindly contact administrator");
                $('#PloadingIns1').removeClass('Inncoursrload');
                return false;
            }
        });
        return false;

    });
});