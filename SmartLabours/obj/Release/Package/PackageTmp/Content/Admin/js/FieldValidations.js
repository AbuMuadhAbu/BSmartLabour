//Only Allowed Char with Symbols
function AllowSymbolAlphaOnly(event) {

    var inputValue = event.which;
    if ((inputValue > 47 && inputValue < 58) && (inputValue != 32)) {
        event.preventDefault();
    }
}

// Only Allowed Numeric
function AllowNumericOnly(e) {

    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
     (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
     (e.keyCode >= 35 && e.keyCode <= 40)) {
        return;
    }
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        e.preventDefault();
    }

   // if (event.shiftKey == true) {
   //     event.preventDefault();
   // }

   //// if a decimal has been added, disable the "."-button
   // if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
   //   (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
   //   (e.keyCode >= 35 && e.keyCode <= 40)) {
   //     return;
   // }
   // if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
   //     e.preventDefault();
   // }

}

//only Alphapets
function AllowAlphaOnly(evt) {

    var charCode;
    if (window.event)
        charCode = window.event.keyCode;  //for IE
    else
        charCode = evt.which;  //for firefox
    if (charCode == 32) //for &lt;space&gt; symbol
        return true;
    if (charCode > 31 && charCode < 65) //for characters before 'A' in ASCII Table
        return false;
    if (charCode > 90 && charCode < 97) //for characters between 'Z' and 'a' in ASCII Table
        return false;
    if (charCode > 122) //for characters beyond 'z' in ASCII Table
        return false;
    return true;


    //var regex = new RegExp("^[a-zA-Z]+$");
    //var str = String.fromCharCode(!e.charCode ? e.which : e.charCode);
    //if (regex.test(str)) {
    //    return true;
    //}
    //e.preventDefault();
    //return false;


    //// debugger
    //if (window.event) {
    //    var charCode = window.event.keyCode;
    //}
    //else if (e) {
    //    var charCode = e.which; // For FieFox
    //}
    //else { return true; }
    //if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123 || (charCode == 32)))
    //    return true;
    //else
    //{
    //    event.preventDefault();
    //    return false;
    //}
       

}


try {
    $("input[type='text']").each(function () {
        $(this).attr("autocomplete", "off");
    });
}
catch (e)
{ }
