Class Bedienung

    Private anzeige As BeamerAnzeige
    Private sicherung As Sicherung
    Dim strTeamnamen() As String = {"Team1", "Team2", "Team3", "Team4", "Orga-Team", "???"}


    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
        anzeige = New BeamerAnzeige
        anzeige.Show()

        ' Gruppen konfigurieren (Bezeichnungen setzen, Teams eintragen, mit der Ausgabe verknüpfen, Spielzeiten)
        GruppeA.setzeAusgabe(anzeige.GruppeA, sicherung)
        GruppeA.setzeSpielNamen()
        GruppeA.setzeTeams(strTeamnamen)
        GruppeA.lblGruppe.Content = "Gruppe A"
        GruppeA.Spiel1.txtTitel.Text = "Spiel 1: 12:35 Uhr"
        GruppeA.Spiel2.txtTitel.Text = "Spiel 3: 12:45 Uhr"
        GruppeA.Spiel3.txtTitel.Text = "Spiel 5: 12:55 Uhr"


        GruppeB.setzeAusgabe(anzeige.GruppeB, sicherung)
        GruppeB.setzeSpielNamen()
        GruppeB.setzeTeams(strTeamnamen)
        GruppeB.lblGruppe.Content = "Gruppe B"
        GruppeB.Spiel1.txtTitel.Text = "Spiel 1: 12:35 Uhr"
        GruppeB.Spiel2.txtTitel.Text = "Spiel 3: 12:45 Uhr"
        GruppeB.Spiel3.txtTitel.Text = "Spiel 5: 12:55 Uhr"


        'If Not sicherung.DateiInitialisiert Then
        '    sicherung.speichern()
        'Else
        '    sicherung.wiederherstellen()
        'End If



    End Sub



    Private Sub Window_Unloaded(sender As Object, e As RoutedEventArgs)
        End
    End Sub



End Class
