<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PostData.aspx.cs" Inherits="SmartLabours.PostData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Scripts/jquery-1.11.1.min.js"></script>
</head>
<body>
       <form action="https://happinessmeter.dubai.gov.ae/SubmitFeedback" method="post">
              <input type="text" name="json_payload" value="<%= jsonRequest %>" />
              <input type="text" name="client_id" value="<%= client_id %>"/>
              <input type="text" name="signature" value="<%= signature %>"/>
              <input type="text" name="lang" value="<%= Lang %>"/>

               <input type="text" name="timestamp" value="<%= timestamp %>"/>
               <input type="text" name="random" value="<%= random %>"/>
               <input type="text" name="nonce" value="<%= nonce %>"/>
           <h1></h1>
       </form>
</body>
<script type="text/javascript">
  //  document.forms[0].submit();
    $(document).ready(function () {
      
        var Sau = $("form").submit();
        
    });

</script>

</html>
