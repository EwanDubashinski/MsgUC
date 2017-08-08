Public Class TextToTaskEventArgs
    Inherits EventArgs

    Public Sub New(Text As String)
        Me.Text = Text
    End Sub

    Public Property Text As String
End Class

Public Class msgArea
    Shared currentMsgAreaObject As msgArea

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        currentMsgAreaObject = Me ' It make me sad
    End Sub

    Shared Function getMsgArea() As msgArea
        Return currentMsgAreaObject
    End Function

    Public Event TextToTask As EventHandler

    Public Sub onTextToTask(e As TextToTaskEventArgs)
        RaiseEvent TextToTask(Me, e)
    End Sub

    Public Sub insMsg(ByVal out As Boolean, ByVal header As String, ByVal txt As String, ByVal dt As String, ByVal attach As Boolean)
        msgPanel.Children.Add(New MailItem(out, header, txt, dt, attach))
        sw.ScrollToBottom()
    End Sub

    Public Sub clearMsg()
        msgPanel.Children.Clear()
    End Sub

    Public Sub insSep(ByVal text As String)
        msgPanel.Children.Add(New MsgSeparator(text))
        sw.ScrollToBottom()
    End Sub
End Class
