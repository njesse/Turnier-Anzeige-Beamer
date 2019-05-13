Public Class GruppeAusgabe
    Implements aktualisierbar

    ' Public vorrunde As VorrundeAusgabe

    Public Sub aktualisiereTabelle() Implements aktualisierbar.aktualisiereTabelle

        Dim strTeam(2) As String

        Dim dPunkteGesamt(2) As Double

        ' erstmal die 3 Teamnamen bestimmen (Hier wird davon ausgegangen, dass in allen 3 Spielen die Gegner bereits gesetzt sind)
        strTeam(0) = Spiel1.txtTeam1Name.Text
        strTeam(1) = Spiel1.txtTeam2Name.Text

        If Not strTeam.Contains(Spiel2.txtTeam1Name.Text) Then
            strTeam(2) = Spiel2.txtTeam1Name.Text
        ElseIf Not strTeam.Contains(Spiel2.txtTeam2Name.Text) Then
            strTeam(2) = Spiel2.txtTeam2Name.Text

        End If
        'MsgBox(strTeam(0) & strTeam(1) & strTeam(2))
        Dim strGesuchtesTeam As String

        ' nur für gespielte Spiele werden die Punkte ausgelesen
        If Spiel1.bRundeGespielt Then

            ' Beide Teams bekommen ihre Punkte gut geschrieben 
            strGesuchtesTeam = Spiel1.getVerliererName
            For i As Integer = 0 To strTeam.Length - 1
                If strGesuchtesTeam.Equals(strTeam(i)) Then
                    dPunkteGesamt(i) += Spiel1.getVerliererPunkte
                End If
            Next
            strGesuchtesTeam = Spiel1.getGewinnerName
            For i As Integer = 0 To strTeam.Length - 1
                If strGesuchtesTeam.Equals(strTeam(i)) Then
                    dPunkteGesamt(i) += Spiel1.getGewinnerPunkte
                End If
            Next
        End If

        If Spiel2.bRundeGespielt Then

            'Frage Ergebnisse von Spiel2 ab - Gewinner
            strGesuchtesTeam = Spiel2.getGewinnerName
            For i As Integer = 0 To strTeam.Length - 1
                If strGesuchtesTeam.Equals(strTeam(i)) Then
                    dPunkteGesamt(i) += Spiel2.getGewinnerPunkte
                End If
            Next
            ' Verlierer
            strGesuchtesTeam = Spiel2.getVerliererName
            For i As Integer = 0 To strTeam.Length - 1
                If strGesuchtesTeam.Equals(strTeam(i)) Then
                    dPunkteGesamt(i) += Spiel2.getVerliererPunkte
                End If
            Next
        End If

        If Spiel3.bRundeGespielt Then
            'Frage Ergebnisse von Spiel3 ab - Gewinner
            strGesuchtesTeam = Spiel3.getGewinnerName
            For i As Integer = 0 To strTeam.Length - 1
                If strGesuchtesTeam.Equals(strTeam(i)) Then
                    dPunkteGesamt(i) += Spiel3.getGewinnerPunkte
                End If
            Next
            ' Verlierer
            strGesuchtesTeam = Spiel3.getVerliererName
            For i As Integer = 0 To strTeam.Length - 1
                If strGesuchtesTeam.Equals(strTeam(i)) Then
                    dPunkteGesamt(i) += Spiel3.getVerliererPunkte
                End If
            Next
        End If


        Dim tabelle(2) As Tabellenplatz
        For i As Integer = 0 To strTeam.Length - 1
            tabelle(i) = New Tabellenplatz(strTeam(i), dPunkteGesamt(i))
        Next

        Array.Sort(tabelle)

        txtGruppenerster.Text = tabelle(0).strName
        txtGruppenersterPunkte.Text = tabelle(0).dPunkte

        txtGruppenzweiter.Text = tabelle(1).strName
        txtGruppenzweiterPunkte.Text = tabelle(1).dPunkte

        txtGruppendritter.Text = tabelle(2).strName
        txtGruppendritterPunkte.Text = tabelle(2).dPunkte


    End Sub


End Class
