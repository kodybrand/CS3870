

<!DOCTYPE html>
<script runat="server">
    '---------------------------------------------------------------------------------------------
    ' Class      : CS 3870CS 5870
    '
    ' Name       : Kody Brand 
    '
    ' UserName   : brandk
    '
    ' Description: Calculates the Subtotal, Tax, and Grand Total from the user input. It will 
    '   save the values if the calculation good. Use of the reset button will remove saved values
    '
    '---------------------------------------------------------------------------------------------

    Private Sub Prog2_OrderingProduct_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Session("Prog2_Computed") = True Then
            txtID.Text = Session("Prog2_ProductID")
            txtPrice.Text = Session("Prog2_ProductPrice")
            txtQuantity.Text = Session("Prog2_ProductQuantity")
            txtSubTotal.Text = Session("Prog2_ProductSubTotal")
            txtTax.Text = Session("Prog2_ProductTax")
            txtGrandTotal.Text = Session("Prog2_ProductGrandTotal")

        End If
    End Sub

    Protected Sub btnReset_Click(sender As Object, e As EventArgs)
        txtID.Text = ""
        txtPrice.Text = ""
        txtQuantity.Text = ""
        txtSubTotal.Text = ""
        txtTax.Text = ""
        txtGrandTotal.Text = ""
        Session("Prog2_Computed") = False
        txtID.Focus()

    End Sub

    Protected Sub btnCompute_Click(sender As Object, e As EventArgs) Handles btnCompute.Click
        Dim price As Double = txtPrice.Text
        Dim quant As Double = txtQuantity.Text

        txtSubTotal.Text = (price * quant).ToString("C")
        txtTax.Text = ((price * quant) * 0.0505).ToString("C")
        txtGrandTotal.Text = (((price * quant) * 0.0505) + (price * quant)).ToString("C")

        Session("Prog2_ProductID") = txtID.Text
        Session("Prog2_ProductPrice") = txtPrice.Text
        Session("Prog2_ProductQuantity") = txtQuantity.Text
        Session("Prog2_ProductSubTotal") = txtSubTotal.Text
        Session("Prog2_ProductTax") = txtTax.Text
        Session("Prog2_ProductGrandTotal") = txtGrandTotal.Text

        Session("Prog2_Computed") = True
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>CS3870 - Program 2</title>
    <link rel="stylesheet" type="text/css" href="../StyleSheet.css" />
</head>

<body>

    <form id="form1" runat="server">

        <h1 class="CS3870Title">Web Protocols, Technologies and Applications </h1>
        <h2 class="CS3870Name">Kody Brand</h2>

        <ul class="navbar">
            <li><a href="Default.aspx">Start Page</a></li>
            <li><a href="OrderingProduct.aspx">Order Form</a></li>
        </ul>

        <h3 class="centerText">CS 3870: Program 2</h3>
        <asp:Label ID="Label1" runat="server" Text="Label" TabIndex="-1" Style="z-index: 1; position: relative; width: 15%; margin-left: 17.5%; display: inline-block; text-align: center">Product ID</asp:Label>
        <asp:Label ID="Label2" runat="server" Text="Label" Style="z-index: 1; position: relative; width: 15%; margin-left: 10%; display: inline-block; text-align: center">Price</asp:Label>
        <asp:Label ID="Label3" runat="server" Text="Label" Style="z-index: 1; position: relative; width: 15%; margin-left: 10%; display: inline-block; text-align: center">Quantity</asp:Label>
        <br />
        <br />

        <asp:TextBox ID="txtID" runat="server" Style="border-style: Solid; position: relative; margin-left: 17.5%; width: 15%; display: inline-block"></asp:TextBox>
        <asp:TextBox ID="txtPrice" runat="server" Style="border-style: Solid; position: relative; margin-left: 10%; width: 15%; display: inline-block; text-align: right"></asp:TextBox>
        <asp:TextBox ID="txtQuantity" runat="server" Style="border-style: Solid; position: relative; margin-left: 10%; width: 15%; display: inline-block; text-align: right"></asp:TextBox>
        <br />
        <br />

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="ID cannot be empty!" ControlToValidate="txtID" style="z=index:1;position:relative;margin-left:17.5%;width:15%;display:inline-block;visibility:hidden;" ></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Price cannot be empty!" ControlToValidate="txtPrice" style="z-index:1;position:relative;margin-left:10.5%;width:15%;display:inline-block;visibility:hidden;"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Quantity cannot be empty!" ControlToValidate="txtQuantity" style="z-index:1;position:relative;margin-left:10.5%;width:15%;display:inline-block;visibility:hidden;" ></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Unit Price must be a positive number!" ControlToValidate="txtPrice" Operator="GreaterThan" Type="Double" ValueToCompare="0" style="z-index:1;position:relative;margin-left:-41%;width:20%;display:inline-block;visibility:hidden;"></asp:CompareValidator>
        <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Quantity must be a non-negative integer!" ControlToValidate="txtQuantity" Operator="GreaterThan" Type="Double" ValueToCompare="0" style="z-index:1;position:relative;margin-left:5%;width:25%;display:inline-block;visibility:hidden;"></asp:CompareValidator>
        <br />
        <br />

        <asp:Label ID="lblSubTotal" runat="server" Text="Label" TabIndex="-1" Style="z-index: 1; position: relative; width: 15%; margin-left: 17.5%; display: inline-block; text-align: center">Sub Total</asp:Label>
        <asp:Label ID="lblTax" runat="server" Text="Label" Style="z-index: 1; position: relative; width: 15%; margin-left: 10%; display: inline-block; text-align: center">Tax</asp:Label>
        <asp:Label ID="lblGrandTotal" runat="server" Text="Label" Style="z-index: 1; position: relative; width: 15%; margin-left: 10%; display: inline-block; text-align: center">Grand Total</asp:Label>
        <br />
        <br />

        <asp:TextBox ID="txtSubTotal" runat="server" Style="border-color: black; border-style: solid; z-index: 1; position: relative; margin-left: 17.5%; width: 15%; display: inline-block; text-align: right"></asp:TextBox>
        <asp:TextBox ID="txtTax" runat="server" Style="border-color: black; border-style: solid; z-index: 1; position: relative; margin-left: 10%; width: 15%; display: inline-block; text-align: right"></asp:TextBox>
        <asp:TextBox ID="txtGrandTotal" runat="server" Style="border-color: black; border-style: solid; z-index: 1; position: relative; margin-left: 10%; width: 15%; display: inline-block; text-align: right"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnCompute" runat="server" Text="Compute" style="width:80px;z-index: 1; position: relative; width: 10%; margin-left: 35%" OnClick="btnCompute_Click" />
        <asp:Button ID="btnReset" runat="server" Text="Reset" style="height:26px;width:80px;z-index: 1; position: relative; margin-left: 10%; width: 10%" OnClick="btnReset_Click" />


    </form>



</body>
</html>
