Public Class Tabellenplatz
    Implements IComparable

    Public strName As String

    Public dPunkte As Double




    Public Sub New(ByVal strTeamname As String, ByVal dPunkte As Double)
        strName = strTeamname

        Me.dPunkte = dPunkte
    End Sub


    Public Function CompareTo(gegner As Object) As Integer Implements IComparable.CompareTo
        ' Muss/Kann je nach Sortierung angepasst werden
        ' Rückgabewert Negativ: dieser Platz liegt vor dem Platz, mit dem verglichen wird
        ' Rückgabewert Positiv: dieser Platz liegt hinter dem Platz, mti dem verglichen wird

        If dPunkte > gegner.dPunkte Then
            Return -1
        End If
        If dPunkte < gegner.dPunkte Then
            Return 1
        End If

        ' Hier kann man weitere Kriterien einbauen, bei uns entschied im Zweifelsfall die Platzierung in der Vorrunde
        'If iPlatzVorrunde < gegner.iPlatzVorrunde Then
        '    Return -1
        'End If
        Return 1

    End Function



End Class
