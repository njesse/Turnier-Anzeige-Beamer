Imports excel = Microsoft.Office.Interop.Excel

Public Class Sicherung
    ' Gesichert werden soll:

    ' (hier Verweise auf die Objekte, aus denen Daten gespeichert werden sollen)
    ' z.B. Public Vorrunde As VorrundeAusgabe


    Private strDateiname As String = ""


    Public Sub New(ByVal strName As String)
        ' Diese Prozedur wird einmalig bei der Initialisierung aufgerufen und kann genutzt werden, um Verweise auf die Objekte, aus denen Daten gespeichert werden soll zu übergeben
        ' Bsp für die Anpassung der Parameter: 
        'Public Sub New(ByVal strName As String, ByRef Vorrunde As VorrundeAusgabe)
        ' Bsp um den Verweis auf ein Objekt in einer Klassenvariable zu speichern
        ' Me.Vorrunde = Vorrunde
        Me.strDateiname = strName
    End Sub

    Public Function DateiInitialisiert() As Boolean
        ' Öffne Datei, überprüfe ob in einem bestimmten Feld ein Wert steht, ist das Feld leer ist die Tabelle nicht initialisiert
        ' Welches Feld das ist, ist abhängig vom Layout der Datei
        Dim bWerteGefunden As Boolean = False

        Dim obSeite As excel.Worksheet
        Dim obZelle As excel.Range
        Dim xlsApp = New excel.Application
        Dim excelDatei = oeffneExceldatei(strDateiname, xlsApp)
        obSeite = excelDatei.Sheets.Item("Tabelle1")

        obZelle = obSeite.Cells(3, 2)  ' Hier B3
        If Not obZelle.Text = "" Then
            bWerteGefunden = True
        End If

        ' alles notwendig, um Excel sauber zu schließen:
        excelDatei.Close()
        xlsApp.Quit()
        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelDatei)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp)
        excelDatei = Nothing
        xlsApp = Nothing
        Return bWerteGefunden
    End Function

    Public Sub wiederherstellen()
        Dim obSeite As excel.Worksheet
        Dim xlsApp = New excel.Application
        Dim excelDatei = oeffneExceldatei(strDateiname, xlsApp)
        obSeite = excelDatei.Sheets.Item("Tabelle1")

        ' Beispiel für Vorrunden Ergebnisse 
        '  For i As Integer = 0 To Vorrunde.Ergebnisse.Length - 1
        'Dim ergebnis As New VorrundenZeit
        '    ergebnis.strTeamname = obSeite.Cells(3 + i, 2).Value
        '    ergebnis.iMinuten = obSeite.Cells(3 + i, 3).Value
        '    ergebnis.dSekunden = obSeite.Cells(3 + i, 4).Value
        '    ergebnis.dPunkte = obSeite.Cells(3 + i, 5).Value

        '    Vorrunde.addErgebnis(ergebnis)
        'Next
        ' Ergebnisse Gruppe A
        ' Pro Spiel 1. Teams setzen und wenn bereits gespielt wurde anschließend die Punkte
        'Dim strBezeichnung As String = ""
        'Dim strT1 As String = ""
        'Dim strT2 As String = ""
        'Dim dP1 As Double
        'Dim dP2 As Double
        'Dim bBereitsgespielt As Boolean

        ' Beispiel um ein Spiel aus Zeile 12 einzulesen und dann in einem Bedienungsfeld zu schreiben
        ' im BedienungA sind mehrere Spiele hinterlegt (Spiel1 bis SpielX), das ist das Backend der Spiele
        ' Frontend (sehen die Zuschauer) ist gruppeA 
        ' Hier werden nur die Ergebnisse gesetzt und anschließend die Tabelle neu berechnet

        'leseSpielAusZeile(obSeite, 12, strBezeichnung, strT1, strT2, dP1, dP2, bBereitsgespielt)
        'BedienungA.Spiel1.txtTitel.Text = strBezeichnung
        'If Not strT1.Equals("Team2") And Not strT2.Equals("Team1") Then ' Wenn schon Werte gesetzt sind
        '    BedienungA.Spiel1.cmbTeam1.SelectedItem = strT1
        '    BedienungA.Spiel1.cmbTeam2.SelectedItem = strT2

        '    If bBereitsgespielt Then
        '        BedienungA.Spiel1.txtPuntkeTeam1.Text = dP1
        '        BedienungA.Spiel1.txtPunkteTeam2.Text = dP2
        '        gruppeA.Spiel1.setzeErgebnis(dP1, dP2)
        '        gruppeA.aktualisiereTabelle()
        '    End If
        'End If



        excelDatei.Close(True)
        xlsApp.Quit()
        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelDatei)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp)
        excelDatei = Nothing
        xlsApp = Nothing
    End Sub



    Public Sub speichern()

        Dim obSeite As excel.Worksheet
        Dim xlsApp = New excel.Application
        Dim excelDatei = oeffneExceldatei(strDateiname, xlsApp)
        obSeite = excelDatei.Sheets.Item("Tabelle1")

        ' Jeweils Beispiele, wie in eine Exceldatei geschrieben werden kann:

        ' Vorrunden Ergebnisse
        'For i As Integer = 0 To Vorrunde.Ergebnisse.Length - 1

        '    obSeite.Cells(3 + i, 2).Value = Vorrunde.Ergebnisse(i).strTeamname
        '    obSeite.Cells(3 + i, 3).Value = Vorrunde.Ergebnisse(i).iMinuten
        '    obSeite.Cells(3 + i, 4).Value = Vorrunde.Ergebnisse(i).dSekunden
        '    obSeite.Cells(3 + i, 5).Value = Vorrunde.Ergebnisse(i).dPunkte
        'Next


        ' Gruppe A Ergebnisse
        'schreibeSpielinZeile(obSeite, gruppeA.Spiel1, 12)

        excelDatei.Close(True)
        xlsApp.Quit()
        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelDatei)
        System.Runtime.InteropServices.Marshal.ReleaseComObject(xlsApp)
        excelDatei = Nothing
        xlsApp = Nothing
    End Sub

    Private Sub leseSpielAusZeile(ByRef seite As excel.Worksheet, ByRef iZeile As Integer, ByRef bez As String, ByRef T1 As String, ByRef T2 As String, ByRef P1 As Double, ByRef P2 As Double, ByRef bgespielt As Boolean)
        bez = seite.Cells(iZeile, 2).Value
        T1 = seite.Cells(iZeile, 3).Value
        P1 = seite.Cells(iZeile, 4).Value
        T2 = seite.Cells(iZeile, 5).Value
        P2 = seite.Cells(iZeile, 6).Value
        bgespielt = seite.Cells(iZeile, 7).Value
    End Sub

    Private Sub schreibeSpielinZeile(ByRef seite As excel.Worksheet, ByRef spiel As Runde, ByRef iZeile As Integer)
        seite.Cells(iZeile, 2).Value = spiel.txtHeader.Text
        seite.Cells(iZeile, 3).Value = spiel.getGewinnerName
        seite.Cells(iZeile, 4).Value = spiel.getGewinnerPunkte
        seite.Cells(iZeile, 5).Value = spiel.getVerliererName
        seite.Cells(iZeile, 6).Value = spiel.getVerliererPunkte
        seite.Cells(iZeile, 7).Value = spiel.bRundeGespielt
    End Sub


    Private Function oeffneExceldatei(ByVal strDateiname As String, ByRef xlsApp As excel.Application) As excel.Workbook

        Dim xlsFile = xlsApp.Workbooks.Open(System.AppDomain.CurrentDomain.BaseDirectory & strDateiname)
        Return xlsFile

    End Function

End Class
