Public Class MailItem
    Public Sub New(ByVal out As Boolean, ByVal header As String, ByVal txt As String, ByVal dt As String, ByVal attach As Boolean)
        'ByVal itemWidth As Integer
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        msgText.Text = txt
        msgHeader.Text = header
        msgTime.Content = dt
        If attach Then
            hasAttach.Visibility = Visibility.Visible
        Else
            hasAttach.Visibility = Visibility.Hidden
        End If

        If out Then
            Me.Margin = New Thickness(5, Margin.Top, 30, Margin.Bottom)
            bord.CornerRadius = New CornerRadius(0, 10, 10, 10)
            msgHeader.HorizontalAlignment = HorizontalAlignment.Left
            msgText.HorizontalAlignment = HorizontalAlignment.Left
            HorizontalAlignment = HorizontalAlignment.Left
        Else
            Me.Margin = New Thickness(30, Margin.Top, 5, Margin.Bottom)
            bord.CornerRadius = New CornerRadius(10, 0, 10, 10)
            msgHeader.HorizontalAlignment = HorizontalAlignment.Right
            msgText.HorizontalAlignment = HorizontalAlignment.Right
            HorizontalAlignment = HorizontalAlignment.Right
        End If
    End Sub

    Private Sub AddToTask_Click(sender As Object, e As RoutedEventArgs) Handles AddToTask.Click
        msgArea.getMsgArea().onTextToTask(New TextToTaskEventArgs(msgText.SelectedText))
    End Sub

    Private Sub msgText_SelectionChanged(sender As Object, e As RoutedEventArgs) Handles msgText.SelectionChanged
        If msgText.SelectionLength > 0 Then
            PopupButton.IsOpen = True
        ElseIf PopupButton IsNot Nothing Then
            PopupButton.IsOpen = False
        End If
    End Sub
End Class
