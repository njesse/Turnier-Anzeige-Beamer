Public Class RundeBedienung

    Private gruppe As aktualisierbar
    Private rundeAusgabe As Runde
    Private sicherung As Sicherung

    Public Sub Init(ByRef neueRunde As Runde, ByRef neueGruppe As aktualisierbar, ByRef backup As Sicherung)
        rundeAusgabe = neueRunde
        gruppe = neueGruppe
        sicherung = backup
    End Sub

    Public Sub TeamsComboboxen(ByVal strTeams() As String)
        cmbTeam1.Items.Clear()
        cmbTeam2.Items.Clear()
        For i As Integer = 0 To strTeams.Length() - 1
            cmbTeam1.Items.Add(strTeams(i))
            cmbTeam2.Items.Add(strTeams(i))
        Next
    End Sub



    Private Sub txtTitel_TextChanged(sender As Object, e As TextChangedEventArgs) Handles txtTitel.TextChanged
        If Not IsNothing(rundeAusgabe) Then
            rundeAusgabe.txtHeader.Text = txtTitel.Text
        End If

    End Sub

    Private Sub cmbTeam1_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cmbTeam1.SelectionChanged
        If Not IsNothing(rundeAusgabe) Then
            rundeAusgabe.txtTeam1Name.Text = cmbTeam1.SelectedItem
        End If
    End Sub

    Private Sub cmbTeam2_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles cmbTeam2.SelectionChanged
        If Not IsNothing(rundeAusgabe) Then
            rundeAusgabe.txtTeam2Name.Text = cmbTeam2.SelectedItem
        End If
    End Sub

    Private Sub btnPunkteEintragen_Click(sender As Object, e As RoutedEventArgs) Handles btnPunkteEintragen.Click
        If IsNumeric(txtPunkteTeam2.Text) And IsNumeric(txtPuntkeTeam1.Text) Then
            Dim dPunkte1 As Double = txtPuntkeTeam1.Text
            Dim dPunkte2 As Double = txtPunkteTeam2.Text

            rundeAusgabe.setzeErgebnis(dPunkte1, dPunkte2)
            gruppe.aktualisiereTabelle()
            ' sicherung.speichern()
        End If
    End Sub


End Class
