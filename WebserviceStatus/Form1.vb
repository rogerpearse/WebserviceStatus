Option Strict On
'-- Importing icons 
'  1. create icons as .ico using external resources.  http://icoconvert.com/
'  2. Double click on resource1.resx
'  3. Add Resource ... Add existing file.  Browse to the ico - will be added.
'-- Further problem: https://stackoverflow.com/questions/28638092/icon-in-task-bar-will-not-change-when-winform-is-published
'  This works when I run the exe from my machine from the solution bin/release folder. When I publish this and install it from the published location, the icon does not change.
'  1. changing the CopyToOutput property of your .ico file to "Copy Always" or "Copy If Newer". 

Public Class Form1

    Public Shared xSub As SampleCallEveryXMinute

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim intervalSecs As Decimal = Me.IntervalUpDown.Value * 1000
        Dim interval As Integer = CInt(intervalSecs)
        Dim url = Me.urlbox.Text
        If url.Trim = "" Then
            url = "http://localhost:8181/WebApp/cxf/CMSToPMSService?wsdl"
        End If
        xSub = New SampleCallEveryXMinute(interval, url)
        Me.TextBox1.Text = ""
        Me.Icon = My.Resources.Resource1.red
        xSub.StartTimer()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Icon = My.Resources.Resource1.black
        Me.urlbox.Text = "http://localhost:8181/WebApp/cxf/CMSToPMSService?wsdl"
    End Sub

    Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
        xSub.StopTimer()
        Me.Icon = My.Resources.Resource1.black
    End Sub
End Class
