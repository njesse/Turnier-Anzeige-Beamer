Public Class Runde

    Public bRundeGespielt As Boolean = False
    Public bGleichstand As Boolean = False

    Public Sub setzeTeamNamen(ByVal strTeam1 As String, ByVal strTeam2 As String)
        txtTeam1Name.Text = strTeam1
        txtTeam2Name.Text = strTeam2
    End Sub
    Public Sub setzeErgebnis(ByVal dPunkte1 As Double,
                              ByVal dPunkte2 As Double)
        bRundeGespielt = True
        If (dPunkte1 = dPunkte2) Then
            bGleichstand = True
        End If
        txtTeam1Punkte.Text = dPunkte1
        txtTeam2Punkte.Text = dPunkte2

        If dPunkte1 > dPunkte2 Then
            txtTeam1Name.TextDecorations = TextDecorations.Underline
            txtTeam2Name.TextDecorations = Nothing
        ElseIf dPunkte2 > dPunkte1 Then
            txtTeam2Name.TextDecorations = TextDecorations.Underline
            txtTeam1Name.TextDecorations = Nothing
        ElseIf dPunkte2 = dPunkte1 Then
            txtTeam1Name.TextDecorations = Nothing
            txtTeam2Name.TextDecorations = Nothing
        End If
    End Sub

    Public Function getGewinnerName() As String
        Dim dPunkte1 As Double = txtTeam1Punkte.Text
        Dim dPunkte2 As Double = txtTeam2Punkte.Text
        If dPunkte1 > dPunkte2 Then
            Return txtTeam1Name.Text
        Else
            Return txtTeam2Name.Text
        End If
    End Function

    Public Function getGewinnerPunkte() As Double
        Dim dPunkte1 As Double = txtTeam1Punkte.Text
        Dim dPunkte2 As Double = txtTeam2Punkte.Text
        If dPunkte1 > dPunkte2 Then
            Return dPunkte1
        Else
            Return dPunkte2
        End If
    End Function

    Public Function getVerliererName() As String
        Dim dPunkte1 As Double = txtTeam1Punkte.Text
        Dim dPunkte2 As Double = txtTeam2Punkte.Text
        If dPunkte1 > dPunkte2 Then
            Return txtTeam2Name.Text
        Else
            Return txtTeam1Name.Text
        End If
    End Function

    Public Function getVerliererPunkte() As Double
        Dim dPunkte1 As Double = txtTeam1Punkte.Text
        Dim dPunkte2 As Double = txtTeam2Punkte.Text
        If dPunkte1 > dPunkte2 Then
            Return dPunkte2
        Else
            Return dPunkte1
        End If
    End Function
End Class
