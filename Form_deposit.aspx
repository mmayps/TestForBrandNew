<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form_deposit.aspx.cs" Inherits="TestForBrandNew.Form_deposit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://code.jquery.com/jquery-2.1.3.js"></script>
	<script src="http://code.jquery.com/ui/1.11.2/jquery-ui.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#btnSave').click(function ()
            {
                var errV = '';
                if ($('#txtamount').val() == '') errV = 'please input amount \n';
                if ($('#ddl').val() == '0') errV += 'please select account \n';
                if (errV != '')
                {
                    alert(errV);
                    return false;
                }
                else
                {
                    var myval = []

                    //myval.push($('#hidAccout_id').val());
                    myval.push($('#ddl').val());
                    myval.push($('#txtamount').val());
                    myval.push($('#txtdeposit').val());
                    myval.push($('#txtfee').val());

                    PageMethods.Save(myval, onsub);
                }
                //alert('test');
            });

            $('#txtamount').change(function ()
            {
                var fee =0.1 // 0.1%
                var amount = $('#txtamount').val();
                var result = (amount * fee) / 100;
                var finalResult = amount - result;
                var fee_val = result;

                $('#txtdeposit').val(finalResult);
                $('#txtfee').val(fee_val);

                //alert(amount);
                //alert(result);
            });

            $('#btncancel').click(function () {
                //location.href = "www.google.com";

                window.location.href = '/AutoRefreshWebPage.aspx';
            });
        });

        function onsub(a)
        {          
            var msg = a;
            alert(msg);
            clearValue();
        }
        function clearValue()
        {
            ('#ddl').val('');
            $('#txtamount').val('');
            $('#txtdeposit').val('');
            $('#txtfee').val('')
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">

        </asp:ScriptManager>
        <div>
            <fieldset>
                <legend>Transfer Form</legend>              
                <table id="tblAcc" >
                    <tr>
                        <td colspan="2">
                            <label>Account : </label>
                          <%--  <asp:TextBox id="txtacc" runat="server" size="50" />--%>
                            <asp:DropDownList ID="ddl" runat="server" Width="180px" > </asp:DropDownList>
                    
                        </td>   
                        <td>
                            <asp:GridView ID="gvData" runat="server">

                            </asp:GridView>
                        </td>                     
                    </tr>
                    <tr>
                        <td>
                            <label>Amount :</label>
                            <input type="number" id="txtamount" />
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <label>Deposit :</label>
                            <input type="number" id="txtdeposit" readonly="true" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <label>Fee Amount :</label>
                            <input type="number" id="txtfee" readonly="true"  />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <button id="btnSave" >save</button>                       
                            <asp:Button  id="btncancel" runat="server" Text="cancel" CausesValidation="false" OnClick="btncancel_Click"/>
                        </td>
                    </tr>
                </table>                    
            </fieldset>           
        </div>
    </form>
</body>
</html>
