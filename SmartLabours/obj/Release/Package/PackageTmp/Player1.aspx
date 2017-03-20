<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Player1.aspx.cs" Inherits="SmartLabours.Player1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>

     <script src="//code.jquery.com/jquery-1.10.2.js"></script>
     <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">

    <script type="text/javascript" >
        $(document).ready(function () {
            // debugger
            var FileName = document.getElementById('txtRoleBased').value;
            $("#HomeVideo").html('');
            $("#HomeVideo").html(' <source src=' + '"/Uplodify/Testimonialvideo/' + FileName + '" type=' + '"video/mp4"' + '>' + '<source src=' + '"/Uplodify/Testimonialvideo/' + FileName + '" type=' + '"video/webm"' + '>');

        });
    </script>
    <style type="text/css" >
        #HomeVideo{
            width:100%;
            height:auto;
        }
    </style>
</head>

<body>

    <form id="form1" runat="server">
        <asp:TextBox ID="txtRoleBased" runat="server" style="display:none"></asp:TextBox>
        <div>
                 <video id="HomeVideo" controls>                      
                        Your browser does not support the video tag.
                    </video>
        </div>
    </form>

</body>
</html>
