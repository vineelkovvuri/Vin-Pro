Public Class CellButton
   Inherits Button
   Enum CellKey
      KeyDelete = 0
      Key1 = 1
      Key2 = 2
      Key3 = 3
      Key4 = 4
      Key5 = 5
      Key6 = 6
      Key7 = 7
      Key8 = 8
      Key9 = 9
      KeyUp
      KeyDown
      KeyLeft
      KeyRight
   End Enum

   Public ReadOnly x As Integer
   Public ReadOnly y As Integer
   Public box As Integer
   Public v As Integer
   Private form1 As Form1
   Public forcedVal As Integer
   Public played As Boolean
   Public solValues As Integer

   Sub New(ByVal form1 As Form1, ByVal x As Integer, ByVal y As Integer)
      Me.form1 = form1
      Me.x = x
      Me.y = y
      box = (y \ 3) * 3 + (x \ 3)
   End Sub

   Protected Overrides Function ProcessDialogKey(ByVal keyData As System.Windows.Forms.Keys) As Boolean
      Select Case keyData
         Case Keys.Up
            RaiseEvent KeyPressed(Me, CellKey.KeyUp)
            Return True
         Case Keys.Down
            RaiseEvent KeyPressed(Me, CellKey.KeyDown)
            Return True
         Case Keys.Left
            RaiseEvent KeyPressed(Me, CellKey.KeyLeft)
            Return True
         Case Keys.Right
            RaiseEvent KeyPressed(Me, CellKey.KeyRight)
            Return True
         Case Keys.Delete
            RaiseEvent KeyPressed(Me, CellKey.KeyDelete)
            Return True
         Case Else
            Return MyBase.ProcessDialogKey(keyData)
      End Select
   End Function

   Protected Overrides Function ProcessDialogChar(ByVal charCode As Char) As Boolean
      Dim k As CellKey = CellKey.Key1
      Select Case charCode
         Case "1"c : k = CellKey.Key1
         Case "2"c : k = CellKey.Key2
         Case "3"c : k = CellKey.Key3
         Case "4"c : k = CellKey.Key4
         Case "5"c : k = CellKey.Key5
         Case "6"c : k = CellKey.Key6
         Case "7"c : k = CellKey.Key7
         Case "8"c : k = CellKey.Key8
         Case "9"c : k = CellKey.Key9
         Case "0"c, "."c, " "c : k = CellKey.KeyDelete
         Case Else
            Exit Function
      End Select
      RaiseEvent KeyPressed(Me, k)
      Return True
   End Function

   Public Event KeyPressed(ByVal sender As CellButton, ByVal key As CellKey)

   Public Sub SetForcedVal(ByVal v As Integer)
      forcedVal = v
      If v > 0 Then
         'Text = CStr(v)
         ForeColor = Color.Red
         Me.v = v
         Me.solValues = 1 << (v - 1)
      Else
         'Text = "."
         ForeColor = Color.Black
         Me.solValues = 0
         Me.v = 0
      End If
      Me.Refresh()
   End Sub

   Private Shared bigfont As New Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold)

   Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
      MyBase.OnPaint(e)
      For i As Integer = 1 To 9
         Dim vi As Integer = 1 << (i - 1)
         If Me.solValues = vi Then
            e.Graphics.DrawString(CStr(i), bigfont, New SolidBrush(Me.ForeColor), 5, 4)
            Exit Sub
         End If
      Next
      If v > 0 Then e.Graphics.DrawString(CStr(Me.v), bigfont, New SolidBrush(Color.LightGray), 5, 4)
      If (Me.solValues And 1 << 0) <> 0 Then e.Graphics.DrawString("1", Me.Font, New SolidBrush(Me.ForeColor), 5, 4)
      If (Me.solValues And 1 << 1) <> 0 Then e.Graphics.DrawString("2", Me.Font, New SolidBrush(Me.ForeColor), 15, 4)
      If (Me.solValues And 1 << 2) <> 0 Then e.Graphics.DrawString("3", Me.Font, New SolidBrush(Me.ForeColor), 25, 4)
      If (Me.solValues And 1 << 3) <> 0 Then e.Graphics.DrawString("4", Me.Font, New SolidBrush(Me.ForeColor), 5, 14)
      If (Me.solValues And 1 << 4) <> 0 Then e.Graphics.DrawString("5", Me.Font, New SolidBrush(Me.ForeColor), 15, 14)
      If (Me.solValues And 1 << 5) <> 0 Then e.Graphics.DrawString("6", Me.Font, New SolidBrush(Me.ForeColor), 25, 14)
      If (Me.solValues And 1 << 6) <> 0 Then e.Graphics.DrawString("7", Me.Font, New SolidBrush(Me.ForeColor), 5, 24)
      If (Me.solValues And 1 << 7) <> 0 Then e.Graphics.DrawString("8", Me.Font, New SolidBrush(Me.ForeColor), 15, 24)
      If (Me.solValues And 1 << 8) <> 0 Then e.Graphics.DrawString("9", Me.Font, New SolidBrush(Me.ForeColor), 25, 24)
   End Sub
End Class
