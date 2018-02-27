Option Strict On
Imports System.Windows.Media.Imaging

Public Class SampleCallEveryXMinute

    Private WithEvents xTimer As New System.Windows.Forms.Timer
    Private url As String

    Public Sub New(ByVal TickValue As Integer, ByVal UrlValue As String)
        xTimer = New System.Windows.Forms.Timer
        xTimer.Interval = TickValue
        url = UrlValue
    End Sub

    Public Sub StartTimer()
        xTimer.Start()
    End Sub

    Public Sub StopTimer()
        xTimer.Stop()
    End Sub

    Private Sub Timer_Tick() Handles xTimer.Tick
        Form1.Icon = My.Resources.Resource1.red
        Try
            Dim retval As String = getWSDL()
            Form1.TextBox1.Text = Form1.TextBox1.Text + retval + vbCrLf
            If retval = "OK" Then
                '-- Add resources to project, Right click WebserviceStatus, Add, new item, Resources file.  
                '-- Then add icon to resources; right-click on file, Open, then Add resource
                Form1.Icon = My.Resources.Resource1.green
            Else
                Form1.Icon = My.Resources.Resource1.red
            End If
        Catch ex As Exception
            Form1.TextBox1.Text = Form1.TextBox1.Text + ex.Message + vbCrLf
            Form1.Icon = My.Resources.Resource1.red
        End Try
    End Sub

    Private Function getWSDL() As String

        Dim client As System.Net.WebClient = New System.Net.WebClient()
        Dim text = ""
        Try
            text = client.DownloadString(url)
            text = "OK"
        Catch e As System.Net.WebException
            text = "NOTHING"
        End Try
        Return text
    End Function

End Class