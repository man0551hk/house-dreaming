<%@ Page Title="" Language="C#" MasterPageFile="~/agency/MasterPage.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="agency_Checkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <script src="https://www.paypalobjects.com/api/checkout.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                                <div id="paypal-button"></div>
                                <asp:Literal ID="Literal11" runat = "server" meta:resourceKey="checkout"></asp:Literal>
                                    <script>
                                        paypal.Button.render({
                                            env: 'sandbox', // Or 'production/sandbox',
                                            commit: true, // Show a 'Pay Now' button
                                            style: {
                                                color: 'blue',
                                                size: 'responsive',
                                                shape: 'rect'
                                            },

                                            payment: function (data, actions) {
                                                return actions.payment.create({
                                                    payment: {
                                                        transactions: [
                                                            {
                                                                amount: { total: '1.00', currency: 'USD' }
                                                            }
                                                        ]
                                                    }
                                                });
                                            },

                                            onAuthorize: function (data, actions) {
                                                return actions.payment.execute().then(function (payment) {
                                                    alert("success");
                                                    // The payment is complete!
                                                    // You can now show a confirmation message to the customer
                                                });
                                            },

                                            onCancel: function (data, actions) {
                                                /* 
                                                * Buyer cancelled the payment 
                                                */
                                            },

                                            onError: function (err) {
                                                /* 
                                                * An error occurred during the transaction 
                                                */
                                            }
                                        }, '#paypal-button');
                                </script>
</asp:Content>

