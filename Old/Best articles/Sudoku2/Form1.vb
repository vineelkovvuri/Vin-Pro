Public Class Form1
   Inherits System.Windows.Forms.Form

   Private SearchThread1 As SearchThread
   Private firstSearchDone As Boolean

   Public Cells(8, 8) As CellButton
   Const ZOOM As Integer = 41
   Const MARG As Integer = 4

   Sub New()
      InitializeComponent()
   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing AndAlso Not components Is Nothing Then
         components.Dispose()
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   'NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
   Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
   Friend WithEvents mnuAbout As System.Windows.Forms.MenuItem
   Friend WithEvents mnuHelp As System.Windows.Forms.MenuItem
   Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
   Friend WithEvents mnuQuit As System.Windows.Forms.MenuItem
   Friend WithEvents mnuNew As System.Windows.Forms.MenuItem
   Friend WithEvents mnuSave As System.Windows.Forms.MenuItem
   Friend WithEvents mnuLoad As System.Windows.Forms.MenuItem
   Friend WithEvents Timer1 As System.Windows.Forms.Timer
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Me.Panel1 = New System.Windows.Forms.Panel
      Me.Label2 = New System.Windows.Forms.Label
      Me.Label1 = New System.Windows.Forms.Label
      Me.MainMenu1 = New System.Windows.Forms.MainMenu
      Me.MenuItem4 = New System.Windows.Forms.MenuItem
      Me.mnuNew = New System.Windows.Forms.MenuItem
      Me.mnuLoad = New System.Windows.Forms.MenuItem
      Me.mnuSave = New System.Windows.Forms.MenuItem
      Me.mnuQuit = New System.Windows.Forms.MenuItem
      Me.MenuItem1 = New System.Windows.Forms.MenuItem
      Me.mnuHelp = New System.Windows.Forms.MenuItem
      Me.mnuAbout = New System.Windows.Forms.MenuItem
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
      Me.Panel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
      Me.Panel1.Controls.Add(Me.Label2)
      Me.Panel1.Controls.Add(Me.Label1)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(400, 72)
      Me.Panel1.TabIndex = 0
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.Location = New System.Drawing.Point(8, 40)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(376, 23)
      Me.Label2.TabIndex = 0
      Me.Label2.Text = "Label2"
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.Location = New System.Drawing.Point(8, 8)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(376, 23)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Label1"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'MainMenu1
      '
      Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem4, Me.MenuItem1})
      '
      'MenuItem4
      '
      Me.MenuItem4.Index = 0
      Me.MenuItem4.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuNew, Me.mnuLoad, Me.mnuSave, Me.mnuQuit})
      Me.MenuItem4.Text = "File"
      '
      'mnuNew
      '
      Me.mnuNew.Index = 0
      Me.mnuNew.Text = "New"
      '
      'mnuLoad
      '
      Me.mnuLoad.Enabled = False
      Me.mnuLoad.Index = 1
      Me.mnuLoad.Text = "Load"
      '
      'mnuSave
      '
      Me.mnuSave.Enabled = False
      Me.mnuSave.Index = 2
      Me.mnuSave.Text = "Save"
      '
      'mnuQuit
      '
      Me.mnuQuit.Index = 3
      Me.mnuQuit.Text = "Quit"
      '
      'MenuItem1
      '
      Me.MenuItem1.Index = 1
      Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuHelp, Me.mnuAbout})
      Me.MenuItem1.Text = "Help"
      '
      'mnuHelp
      '
      Me.mnuHelp.Index = 0
      Me.mnuHelp.Text = "How to use"
      '
      'mnuAbout
      '
      Me.mnuAbout.Index = 1
      Me.mnuAbout.Text = "About"
      '
      'Timer1
      '
      Me.Timer1.Enabled = True
      Me.Timer1.Interval = 250
      '
      'Form1
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(400, 488)
      Me.Controls.Add(Me.Panel1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.KeyPreview = True
      Me.Menu = Me.MainMenu1
      Me.Name = "Form1"
      Me.Text = "Sudoku Designer and Solver"
      Me.Panel1.ResumeLayout(False)
      Me.ResumeLayout(False)

   End Sub

   Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Dim p As CellButton
      Dim k As Integer = 0
      For y As Integer = 0 To 8
         For x As Integer = 0 To 8
            p = New CellButton(Me, x, y)
            k += 1
            p.Location = New Point(10 + pos(x), 80 + pos(y))
            p.Size = New Size(ZOOM, ZOOM)
            'p.Text = "."
            Me.Controls.Add(p)
            cells(x, y) = p
            p.Font = Me.Font
            AddHandler p.KeyPressed, AddressOf cellsKeyPressed
         Next
      Next
      SearchThread1 = New SearchThread(Me)
   End Sub

   Public Function pos(ByVal d As Integer) As Integer
      Select Case d
         Case 0 To 2
            Return d * ZOOM
         Case 3 To 5
            Return d * ZOOM + MARG
         Case 6 To 8
            Return d * ZOOM + 2 * MARG
      End Select

   End Function

   Sub cellsKeyPressed(ByVal c As CellButton, ByVal k As CellButton.CellKey)
      Dim restartSearch As Boolean = False
      Dim x As Integer = c.x
      Dim y As Integer = c.y
      Select Case k
         Case CellButton.CellKey.KeyLeft
            x -= 1
            If x < 0 Then x += 9
         Case CellButton.CellKey.KeyRight
            x += 1
            If x >= 9 Then x -= 9
         Case CellButton.CellKey.KeyUp
            y -= 1
            If y < 0 Then y += 9
         Case CellButton.CellKey.KeyDown
            y += 1
            If y >= 9 Then y -= 9
         Case CellButton.CellKey.Key1 To CellButton.CellKey.Key9
            Dim fv As Integer = k - CellButton.CellKey.KeyDelete
            If fv <> c.forcedVal Then
               c.SetForcedVal(fv)
               restartSearch = True
            End If
         Case CellButton.CellKey.KeyDelete
            If c.forcedVal <> 0 Then
               c.SetForcedVal(0)
               restartSearch = True
            End If
         Case Else
            Exit Sub
      End Select
      cells(x, y).Focus()
      If restartSearch Then SearchThread1.Restart()
   End Sub

   Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
      SearchThread1.IsClosing = True
      SearchThread1.Restart()
   End Sub

   Private Sub mnuHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelp.Click
      MsgBox("Select a cell and press a number 1 to 9" & vbCrLf & _
         "Press delete to clear a cell" & vbCrLf & _
         "Use the arrows to navigate within the grid")
   End Sub

   Private Sub mnuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAbout.Click
      MsgBox("Sudoku2 by Pascal GANAYE" & vbCrLf & _
         "Program published in www.codeproject.com")
   End Sub

   Private Sub mnuQuit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuQuit.Click
      Close()
   End Sub

   Private Sub Form1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
      If firstSearchDone = False Then
         firstSearchDone = True
         SearchThread1.Restart()
      End If

   End Sub


   Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNew.Click
      SearchThread1.StartNew()
   End Sub

   Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
      ' this forces the buttons to refresh every so often
      Panel1.BackColor = SearchThread1.Panel1BackColor
      Label1.Text = SearchThread1.Label1Text
      Label2.Text = SearchThread1.Label2Text
      Me.Invalidate(True)
   End Sub
End Class