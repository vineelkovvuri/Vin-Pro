Public Class SearchThread
   Public Panel1BackColor As Color
   Public Label1Text As String
   Public Label2Text As String
   Public isClosing As Boolean

   Private nbSol As Long
   Private searching As Boolean
   Private restartSearch As Boolean
   Private nbRecur As Long
   ' These arrays contain aggregated values
   ' horz(0) indicates which cells are already entered in the first horizontal line 
   ' horz(1) indicates which cells are already entered in the second horizontal line 
   ' ...
   ' Each value is encoded using a 9 bits binary mask
   ' a sudoku value of 1 is encoded with a 1
   ' a sudoku value of 2 is encoded with a 2
   ' a sudoku value of 3 is encoded with a 4
   ' a sudoku value of 4 is encoded with a 8
   ' a sudoku value of 5 is encoded with a 16
   ' a sudoku value of 6 is encoded with a 32
   ' a sudoku value of 7 is encoded with a 64
   ' a sudoku value of 8 is encoded with a 128
   ' a sudoku value of 9 is encoded with a 256

   ' For example let's say that horz(0)=13 
   ' 13 = 8+4+1
   ' 13 = value4 + value3 + value1
   ' So it means that the first horizontal line has already a 4, a 3 and a 1.
   Private horz(9 - 1) As Integer
   Private vert(9 - 1) As Integer
   Private box(9 - 1) As Integer
   Private nbBits(511) As Integer
   ' This array contains the 81 sudoku cells
   Private CellsArray(81 - 1) As CellButton
   
   Sub New(ByVal form1 As Form1)
      Dim j As Integer
      For i As Integer = 0 To 511
         j = i
         While j > 0
            If (j And 1) <> 0 Then nbBits(i) += 1
            j = j >> 1
         End While
      Next
      Dim n As Integer
      For x As Integer = 0 To 8
         For y As Integer = 0 To 8
            CellsArray(n) = form1.Cells(x, y)
            n += 1
         Next
      Next
   End Sub

   Public Sub StartNew()
      For n As Integer = 0 To 81 - 1
         CellsArray(n).SetForcedVal(0)
      Next
   End Sub

   Public Sub Restart()
      SyncLock Me
         If searching Then
            restartSearch = True
            Exit Sub
         Else
            searching = True
            Dim t As New Threading.Thread(AddressOf mainProc)
            t.Start()
         End If
      End SyncLock
   End Sub
   

   Private Sub mainProc()
restart:
      restartSearch = False
      If isClosing Then Exit Sub
      If InitBoard() Then
         nbSol = 0
         Panel1BackColor = Color.Orange
         Label1Text = "Searching solutions"
         Label2Text = 0.ToString("#,##0 solutions found so far")
         recur(0)
         If restartSearch Then
            GoTo restart
            ' continue in next loop
         Else
            Label1Text = "Search completed"
            Label2Text = nbSol.ToString("#,##0 solutions found.")
            If nbSol = 1 Then
               Panel1BackColor = Color.Green
            Else
               Panel1BackColor = Color.Red
            End If
         End If
      Else
         Panel1BackColor = Color.Red
         Label1Text = "Search completed"
         Label2Text = "No solution found. This Sudoku is not solvable."
      End If
      SyncLock Me
         searching = False
         If restartSearch Then
            restartSearch = False
            GoTo restart
         End If
      End SyncLock
   End Sub

   Private Function InitBoard() As Boolean
      Dim boardOk As Boolean = True
      For i As Integer = 0 To 9 - 1
         horz(i) = 0
         vert(i) = 0
         box(i) = 0
      Next
      For n As Integer = 0 To 81 - 1
         Dim curCell As CellButton = CellsArray(n)
         curCell.played = False
         If curCell.forcedVal = 0 Then
            curCell.v = 0
            curCell.solValues = 0
         Else
            curCell.v = curCell.forcedVal
            Dim v As Integer
            v = 1 << (curCell.v - 1)
            curCell.solValues = v
            If (horz(curCell.y) And v) <> 0 _
               Or (vert(curCell.x) And v) <> 0 _
              Or (box(curCell.box) And v) <> 0 Then
               ' imossible...
               boardOk = False
            Else
               horz(curCell.y) = horz(curCell.y) Or v
               vert(curCell.x) = vert(curCell.x) Or v
               box(curCell.box) = box(curCell.box) Or v
            End If
         End If
      Next
      Return boardOk
   End Function

   Public Sub recur(ByVal n As Integer)
      If n < 81 Then
         Dim curCell, bestCell As CellButton
         curcell = CellsArray(n)
         Dim curCellConstraint As Integer
         Dim constraintMax As Integer = -1
         ' try to find the cell with the most constraints
         For i As Integer = 0 To 81 - 1
            curCell = CellsArray(i)
            With curcell
               If .played = False Then
                  If .forcedVal > 0 Then
                     ' found a very good one
                     bestCell = curCell
                     Exit For
                  Else
                     ' try to calculate the constraints for curCell
                     Dim pos As Integer = horz(.y) Or vert(.x) Or box(.box)
                     curCellConstraint = nbBits(pos)
                     If curCellConstraint > constraintMax Then
                        bestCell = curCell
                        constraintMax = curCellConstraint
                        If constraintMax = 9 Then Exit For
                     End If
                  End If
               End If
            End With
         Next
         curCell = bestCell

         nbRecur += 1
         If restartSearch Then Exit Sub
         With curCell
            .played = True
            If .forcedVal > 0 Then
               recur(n + 1)
            Else
               Dim pos As Integer = horz(.y) Or vert(.x) Or box(.box)
               Dim v As Integer
               Dim nv As Integer
               v = 1
               For i As Integer = 1 To 9
                  If (v And pos) = 0 Then
                     horz(.y) = horz(.y) Or v
                     vert(.x) = vert(.x) Or v
                     box(.box) = box(.box) Or v
                     .v = i
                     nv = Not v
                     recur(n + 1)
                     horz(.y) = horz(.y) And nv
                     vert(.x) = vert(.x) And nv
                     box(.box) = box(.box) And nv
                     .v = 0
                     If restartSearch Then Exit Sub
                  Else
                     ' can't fit
                  End If
                  v += v
               Next
            End If
            .played = False
         End With
      Else
         nbSol += 1
         Label2Text = nbSol.ToString("#,##0 solutions found so far")
         For n = 0 To 80
            Dim curCell As CellButton = CellsArray(n)
            curCell.solValues = curCell.solValues Or (1 << (curCell.v - 1))
         Next
      End If
   End Sub
End Class
