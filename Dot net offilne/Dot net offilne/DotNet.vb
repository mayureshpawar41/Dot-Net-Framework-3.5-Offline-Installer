Public Class DotNet


    'Public Shared Sub RunCommandCom(ByVal command As String, ByVal arguments As String, ByVal permanent As Boolean)
    '    If flag = False Then
    '        Dim p As Process = New Process()
    '        Dim pi As ProcessStartInfo = New ProcessStartInfo()
    '        pi.Arguments = " " + IIf(permanent = True, "/K", "/C") + " " + command + " " + arguments

    '        pi.FileName = "cmd.exe"
    '        p.StartInfo = pi
    '        p.Start()

    '        SendKeys.Send("Dism /online /enable-feature /featurename:NetFX3 /All /Source:D:\sources\sxs /LimitAccess" & "{enter}")
    '        flag = True
    '    End If
    'End Sub


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '------------------ Add dll -------------
            Dim source = Application.StartupPath()
            Dim destination = "D:\sources\sxs"

            source = source + "\sxs"

            If (Not System.IO.Directory.Exists(destination)) Then
                System.IO.Directory.CreateDirectory(destination)
                My.Computer.FileSystem.CopyDirectory(source, destination, Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing) '' Copy the file to a new folder, overwriting existing file.
            End If



            '------------------ Run cmd -------------
            Dim p As Process = New Process()
            Dim pi As ProcessStartInfo = New ProcessStartInfo()

            pi.Verb = "runas"

            pi.Arguments = " " + IIf(True = True, "/K", "/C") + " cd c:\windows\system32 && Dism /online /enable-feature /featurename:NetFX3 /All /Source:D:\sources\sxs /LimitAccess && exit"



            pi.FileName = "cmd.exe"
            'pi.RedirectStandardInput = True
            'pi.RedirectStandardOutput = True
            'pi.UseShellExecute = False
            'pi.CreateNoWindow = True

            p.StartInfo = pi
            'p.StandardInput.WriteLine("Dism /online /enable-feature /featurename:NetFX3 /All /Source:D:\sources\sxs /LimitAccess" & "{enter}")
            p.Start()


            '("Dism /online /enable-feature /featurename:NetFX3 /All /Source:D:\sources\sxs /LimitAccess")
            'SendKeys.Send(" Dism /online /enable-feature /featurename:NetFX3 /All /Source:D:\sources\sxs /LimitAccess")
            'SendKeys.Send("{enter}")

            p.WaitForExit()
            p.Close()








            'Dim SR As System.IO.StreamReader = p.StandardOutput

            'Dim SW As System.IO.StreamWriter = p.StandardInput

            'SW.WriteLine("Dism /online /enable-feature /featurename:NetFX3 /All /Source:D:\sources\sxs /LimitAccess ")

            'SW.WriteLine("exit")


            '.ToString.Contains 'returns results of the command window


            'Dim pk = System.Diagnostics.Process.GetProcessesByName("cmd")

            'Dim readerStdOut As String = pk.StandardOutput.ReadLine()



            'While (p.HasExited = False)

            '    Dim Line As String = Console.ReadLine()

            '    If Line.Length > 0 Then

            '        MsgBox(Line, MsgBoxStyle.Critical)

            '    End If
            'End While

            '            lbl_output.Text = SR.ReadToEnd.ToString
            '            Panel1.Refresh()

            'up:         If Not SR.ReadToEnd.Contains("The operation completed successfully.") And Not SR.ReadToEnd = "" Then
            '                lbl_output.Text = SR.ReadToEnd.ToString
            '                Panel1.Refresh()

            '                System.Threading.Thread.Sleep(100)
            '                GoTo up
            '            Else
            '                'MsgBox("The operation completed successfully.")
            '            End If

            If (System.IO.Directory.Exists(destination)) Then
                My.Computer.FileSystem.DeleteDirectory(destination, FileIO.DeleteDirectoryOption.DeleteAllContents)
                My.Computer.FileSystem.DeleteDirectory("D:\sources", FileIO.DeleteDirectoryOption.DeleteAllContents)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Me.Close()
    End Sub


End Class
