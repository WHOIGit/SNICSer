Imports System.Configuration
Imports System.Data.SqlClient
Imports MySqlConnector

Public Class MicadasRepository
    Private _primaryConnectionString As String
    Private _micadasConnectionString As String

    Public Sub New(connectionString As String)
        _primaryConnectionString = connectionString
        _micadasConnectionString = ConfigurationManager.ConnectionStrings("Micadas").ConnectionString
    End Sub

    Public Function GetMicadasData(magazine As String) As IEnumerable(Of MicadasRecord)
        Dim records = New List(Of MicadasRecord)
        Dim sampleTypes = GetSampleTypes(magazine)

        Using connection = New MySqlConnection(_micadasConnectionString)
            connection.Open()

            Dim cmd = connection.CreateCommand()
            cmd.CommandText = "
                SELECT      ROW_NUMBER() OVER (PARTITION BY position ORDER BY TIMEDAT) as Mst,
	                        RECNO, magazine, TIMEDAT, RUNTIME, position, user_label, CYCLES, ANA, A, B, R, BA, RA 
                FROM        workproto_v_nt 
                WHERE       magazine = @Magazine
                ORDER BY    TIMEDAT, position
            "
            cmd.Parameters.AddWithValue("@Magazine", magazine)

            Dim reader = cmd.ExecuteReader()
            While reader.Read()
                Dim record As New MicadasRecord()
                Try
                    record.RunTime = reader.GetDateTime("TIMEDAT")
                    record.RunDuration = reader.GetDouble("RUNTIME")
                    record.Position = reader.GetInt32("position")
                    record.IsOk = True
                    record.Measurement = reader.GetInt32("mst")
                    record.SampleName = reader.GetString("user_label")

                    If sampleTypes.ContainsKey(record.Position) Then
                        record.SampleType = sampleTypes(record.Position)
                    End If

                    record.Cycles = reader.GetInt32("CYCLES")
                    record.LE12C = reader.GetDouble("ANA") * 0.000001
                    record.HE12C = reader.GetDouble("A") * 0.000001
                    record.HE13C = reader.GetDouble("B") * 0.000001
                    record.CntTotH = 1 ' Always one per Kathy
                    record.CntTotS = 1 ' Always one per Kathy
                    record.CntTotGT = reader.GetInt32("R")
                    record.HE13Over12 = reader.GetDouble("BA")
                    record.HE14Over12 = reader.GetDouble("RA")
                    records.Add(record)
                Catch ex As Exception
                    MsgBox($"Error in MICADAS import: pos {record.Position}, meas {record.Measurement} {vbCrLf} {ex.Message}")
                End Try



            End While
        End Using

        Return records
    End Function

    Public Function GetSampleTypes(wheelId As String) As Dictionary(Of Integer, String)
        Dim sampleTypes As New Dictionary(Of Integer, String)

        Using connection As New SqlConnection(_primaryConnectionString)
            Try
                connection.Open()

                Dim cmd = connection.CreateCommand()
                cmd.CommandText = "
                    SELECT      wheel_pos.wheel_position, target.ttype 
                    FROM        wheel_pos 
                    LEFT JOIN   target 
                                ON target.tp_num = wheel_pos.tp_num
                    WHERE       wheel_id = @WheelId
                "
                cmd.Parameters.AddWithValue("@WheelId", wheelId)

                Using reader As IDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ' If type is nothing, do not add to the list. Issue get's handled downstream
                        If IsDBNull(reader("ttype")) Then
                            Continue While
                        End If

                        Dim sampleType = reader("ttype")
                        Dim wheelPosition = reader("wheel_position")

                        sampleTypes.Add(wheelPosition, sampleType)
                    End While
                End Using
            Catch ex As Exception
                MsgBox($"Error locating sample types{vbCrLf}{ex.Message}")
                Return New Dictionary(Of Integer, String)
            End Try
        End Using

        Return sampleTypes
    End Function

End Class
