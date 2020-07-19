' Name:         Gross Pay Project
' Purpose:      Displays an employee's gross pay.
' Programmer:   <your name> on <current date>

Option Explicit On
Option Strict Off
Option Infer Off

Imports System.Drawing.Text

Public Class frmMain

    'Declares the String Array
    Private strPayRate() As String = {"10.50",
                                     "12.50",
                                     "14.25",
                                     "15.75",
                                     "17.65"}

    




    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        
        ' Selects the first pay code in the list box.
        lstCodes.SelectedIndex = 0

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
      
        Me.Close()
   
    End Sub

    Private Sub ClearGross(sender As Object, e As EventArgs) Handles lstCodes.SelectedIndexChanged, txtHours.TextChanged
        
        lblGross.Text = String.Empty
       
    End Sub

    Private Sub txtHours_Enter(sender As Object, e As EventArgs) Handles txtHours.Enter

        txtHours.SelectAll()
       
    
    End Sub

    Private Sub txtHours_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHours.KeyPress
        
        ' Accept only numbers, the period, and the Backspace key.
        If (e.KeyChar < "0" OrElse e.KeyChar > "9") AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> ControlChars.Back Then
            ' e.Handled = True
        End If

    End Sub

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        
        Dim decPay As Decimal
        Dim decHours As Decimal

        If txtHours.Text < 41
            'Connects the list box to the array so when selected index is "0", "0" sub-index is called 
            lblGross.Text = strPayRate(lstCodes.SelectedIndex)
            'Parse the string array and calculate
            Decimal.TryParse(lblGross.Text, decPay)
            Decimal.TryParse(txtHours.Text, decHours)
            Dim decTotalStandardPay As Decimal = decPay * decHours
            lblGross.Text = decTotalStandardPay.ToString("N2")

        Else

            lblGross.Text = strPayRate(lstCodes.SelectedIndex)
            Decimal.TryParse(lblGross.Text, decPay)
            Decimal.TryParse(txtHours.Text, decHours)
            'Multiplies overtime pay by overtime hours then adds to standard pay totaling "decTotalPay"
            Dim decTotalPay As Decimal = (decPay * decHours)+ (decHours - 40) * (decPay * 0.50) 
            lblGross.Text = decTotalPay.ToString("N2")
         
        End If

    End Sub

    Private Sub lblGross_Click(sender As Object, e As EventArgs) Handles lblGross.Click
      

    End Sub
End Class
