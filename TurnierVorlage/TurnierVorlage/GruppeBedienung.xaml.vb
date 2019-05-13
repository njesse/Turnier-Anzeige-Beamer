Public Class GruppeBedienung
    Implements aktualisierbar
    Private ausgabe As GruppeAusgabe



    Public Sub setzeSpielNamen()
        Spiel1.lblRunde.Content = "Spiel 1"
        Spiel2.lblRunde.Content = "Spiel 2"
        Spiel3.lblRunde.Content = "Spiel 3"
    End Sub

    Public Sub setzeAusgabe(ByRef neueAusgabe As GruppeAusgabe, ByRef backup As Sicherung)
        ausgabe = neueAusgabe
        Spiel1.Init(ausgabe.Spiel1, Me, backup)
        Spiel2.Init(ausgabe.Spiel2, Me, backup)
        Spiel3.Init(ausgabe.Spiel3, Me, backup)
    End Sub


    Public Sub setzeTeams(ByVal strTeams() As String)

        Spiel1.TeamsComboboxen(strTeams)
        Spiel2.TeamsComboboxen(strTeams)
        Spiel3.TeamsComboboxen(strTeams)

    End Sub

    Public Sub aktualisiereTabelle() Implements aktualisierbar.aktualisiereTabelle
        If Not IsNothing(ausgabe) Then
            ausgabe.aktualisiereTabelle()
        End If
    End Sub




End Class
