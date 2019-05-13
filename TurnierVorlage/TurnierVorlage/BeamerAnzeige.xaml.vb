Public Class BeamerAnzeige


    Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)

        GruppeA.lblGruppe.Content = "Gruppe A"
        GruppeB.lblGruppe.Content = "Gruppe B"


    End Sub
    Private Sub Window_MouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs)
        Me.DragMove()
    End Sub
End Class
