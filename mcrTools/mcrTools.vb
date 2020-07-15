Imports mcrLog.NLog

Public Class mcrTools

#Region "Data"
    Private Shared sModuleName As String = "mcrTools"
#End Region

#Region "Time Operations"
    Public Shared Sub mcrDelay(ByVal iNumMiliSeconds As Integer)

        Try
            Dim SW2 As New Stopwatch
            SW2.Start()

            If iNumMiliSeconds < 50 Then iNumMiliSeconds = 50
            If iNumMiliSeconds > 5000 Then iNumMiliSeconds = 5000

            Do
            Loop Until SW2.ElapsedMilliseconds >= iNumMiliSeconds

        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrDelay", ex, "")
        End Try

    End Sub


#End Region

#Region "Formats conversions"

#Region "Convert to Hexadecimal"
    ''' <summary>
    ''' Convert byte to Hexadecimal
    ''' </summary>
    ''' <param name="iValue">Byte to convert in Hexadecimal format "00"</param>
    ''' <returns>String value formatedd "00</returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function mcrHexa(ByVal iValue As Byte) As String
        Dim sResult As String = "&H00"
        Dim sTemp1 As String

        Try
            sTemp1 = "00" & Hex(iValue)
            sResult = Right(sTemp1, 2)

        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrHexa-Byte", ex, "Value: " & iValue.ToString)
            sResult = "&H00"
        Finally
            mcrHexa = sResult
        End Try
    End Function

    Public Overloads Shared Function mcrHexa(ByVal iValue As UShort) As String
        Dim sResult As String = "&H0000"
        Dim sTemp1 As String

        Try
            sTemp1 = "0000" & Hex(iValue)
            sResult = Right(sTemp1, 4)

        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrHexa-Short", ex, "Value: " & iValue.ToString)
            sResult = "&H0000"
        Finally
            mcrHexa = sResult
        End Try
    End Function

    Public Overloads Shared Function mcrHexa(ByVal iValue As UInt32) As String
        Dim sResult As String = "&H00000000"
        Dim sTemp1 As String, sTemp2 As String

        Try
            sTemp1 = "00000000" & Hex(iValue)
            sTemp2 = Right(sTemp1, 8)
            sResult = sTemp2.Substring(0, 4) & " " & sTemp2.Substring(4, 4)

        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrHexa-Int", ex, "Value: " & iValue.ToString)
            sResult = "&H00000000"
        Finally
            mcrHexa = sResult
        End Try
    End Function

#End Region

#Region "Convert to Binary"
    Public Overloads Shared Function mcrBinary(ByVal iValue As Byte) As String
        Dim sResult As String = "&H00"
        Dim sTemp1 As String, sTemp2 As String

        Try
            sTemp1 = Convert.ToString(iValue, 2)
            sTemp2 = Right("00000000" & sTemp1, 8)
            sResult = sTemp2.Substring(0, 4) & " " & sTemp2.Substring(4, 4)

        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrBinary-Byte", ex, "Value: " & iValue.ToString)
            sResult = "Err"
        Finally
            mcrBinary = sResult
        End Try
    End Function

    Public Overloads Shared Function mcrBinary(ByVal iValue As UShort) As String
        Dim sResult As String = "&H0000"
        Dim sTemp1 As String, sTemp2 As String

        Try
            sTemp1 = Convert.ToString(iValue, 2)
            sTemp2 = Right("0000000000000000" & sTemp1, 16)
            sResult = sTemp2.Substring(0, 4) & " " & sTemp2.Substring(4, 4) & " " & sTemp2.Substring(8, 4) & " " & sTemp2.Substring(12, 4)

        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrBinary-Byte", ex, "Value: " & iValue.ToString)
            sResult = "Err"
        Finally
            mcrBinary = sResult
        End Try
    End Function

    Public Overloads Shared Function mcrBinary(ByVal iValue As UInt32) As String
        Dim sResult As String = "&H00000000"
        Dim sTemp1 As String, sTemp2 As String

        Try
            sTemp1 = Convert.ToString(iValue, 2)
            sTemp2 = Right("00000000000000000000000000000000" & sTemp1, 32)
            sResult = sTemp2.Substring(0, 4) & " " & sTemp2.Substring(4, 4) & " " & sTemp2.Substring(8, 4) & " " & sTemp2.Substring(12, 4) & "   " &
                      sTemp2.Substring(16, 4) & " " & sTemp2.Substring(20, 4) & " " & sTemp2.Substring(24, 4) & " " & sTemp2.Substring(28, 4)

        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrBinary-Byte", ex, "Value: " & iValue.ToString)
            sResult = "Err"
        Finally
            mcrBinary = sResult
        End Try
    End Function
#End Region

#Region "Bit Operations"

#Region "Get Bit"
    Public Overloads Shared Function mcrGetBit(ByVal iValue As Byte, iNumBit As Integer) As Boolean
        Dim iMask As Integer

        Try
            If iNumBit < 0 Then iNumBit = 0
            If iNumBit > 7 Then iNumBit = 7

            iMask = CInt(2 ^ iNumBit)                          ' Create a bitmask with the 2^bit
            mcrGetBit = ((iValue And iMask) > 0)                    ' Return the state of 2^Bit
        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrGetBit-Byte", ex, "Value: " & iValue.ToString)
            mcrGetBit = False
        End Try

    End Function
    Public Overloads Shared Function mcrGetBit(ByVal iValue As UShort, iNumBit As Integer) As Boolean
        Dim iMask As Integer

        Try
            If iNumBit < 0 Then iNumBit = 0
            If iNumBit > 15 Then iNumBit = 15

            iMask = CInt(2 ^ iNumBit)                          ' Create a bitmask with the 2^bit
            mcrGetBit = ((iValue And iMask) > 0)                    ' Return the state of 2^Bit
        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrGetBit-Word", ex, "Value: " & iValue.ToString)
            mcrGetBit = False
        End Try

    End Function
    Public Overloads Shared Function mcrGetBit(ByVal iValue As UInt32, iNumBit As Integer) As Boolean
        Dim iMask As Integer

        Try
            If iNumBit < 0 Then iNumBit = 0
            If iNumBit > 31 Then iNumBit = 31

            iMask = CInt(2 ^ iNumBit)                          ' Create a bitmask with the 2^bit
            mcrGetBit = ((iValue And iMask) > 0)                    ' Return the state of 2^Bit
        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrGetBit-DWord", ex, "Value: " & iValue.ToString)
            mcrGetBit = False
        End Try

    End Function
#End Region

#Region "Set Bit"
    Public Function mcrSetBit(ByVal iValue As Byte, iNumBit As Integer) As Byte
        Dim iMask As Integer

        Try
            If iNumBit < 0 Then iNumBit = 0
            If iNumBit > 7 Then iNumBit = 7

            iMask = CInt(2 ^ iNumBit)                          ' Create a bitmask with the 2^bit
            mcrSetBit = CByte(iValue Or iMask)

        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrGetBit-Byte", ex, "Value: " & iValue.ToString)
            mcrSetBit = 0
        End Try
    End Function

    Public Function mcrSetBit(ByVal iValue As UShort, iNumBit As Integer) As UShort
        Dim iMask As Integer

        Try
            If iNumBit < 0 Then iNumBit = 0
            If iNumBit > 15 Then iNumBit = 15

            iMask = CInt(2 ^ iNumBit)                          ' Create a bitmask with the 2^bit
            mcrSetBit = CUShort((iValue Or iMask))

        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrGetBit-Word", ex, "Value: " & iValue.ToString)
            mcrSetBit = 0
        End Try
    End Function

    Public Function mcrSetBit(ByVal iValue As Int32, iNumBit As Integer) As UInt32
        Dim iMask As Integer

        Try
            If iNumBit < 0 Then iNumBit = 0
            If iNumBit > 31 Then iNumBit = 31

            iMask = CInt(2 ^ iNumBit)                          ' Create a bitmask with the 2^bit
            mcrSetBit = CUInt((iValue Or iMask))

        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrGetBit-DWord", ex, "Value: " & iValue.ToString)
            mcrSetBit = 0
        End Try
    End Function

#End Region

#Region "Reset Bit"
    Public Overloads Shared Function mcrResetBit(ByVal iValue As Byte, iNumBit As Integer) As Byte
        Dim iMask As Integer

        Try
            If iNumBit < 0 Then iNumBit = 0
            If iNumBit > 7 Then iNumBit = 7

            iMask = CInt(2 ^ iNumBit)                          ' Create a bitmask with the 2^bit
            mcrResetBit = CByte(iValue And Not iMask)

        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrResetBit-Byte", ex, "Value: " & iValue.ToString)
            mcrResetBit = 0
        End Try
    End Function

    Public Overloads Shared Function mcrResetBit(ByVal iValue As UShort, iNumBit As Integer) As UShort
        Dim iMask As Integer

        Try
            If iNumBit < 0 Then iNumBit = 0
            If iNumBit > 15 Then iNumBit = 15

            iMask = CInt(2 ^ iNumBit)                          ' Create a bitmask with the 2^bit
            mcrResetBit = CUShort((iValue And Not iMask))

        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrResetBit-Word", ex, "Value: " & iValue.ToString)
            mcrResetBit = 0
        End Try
    End Function

    Public Overloads Shared Function mcrResetBit(ByVal iValue As UInt32, iNumBit As Integer) As UInt32
        Dim iMask As Integer

        Try
            If iNumBit < 0 Then iNumBit = 0
            If iNumBit > 31 Then iNumBit = 31

            iMask = CInt(2 ^ iNumBit)                          ' Create a bitmask with the 2^bit
            mcrResetBit = CUInt((iValue And Not iMask))

        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrResetBit-Dword", ex, "Value: " & iValue.ToString)
            mcrResetBit = 0
        End Try
    End Function

#End Region

#Region "Change Bit"
    Public Overloads Shared Function mcrChangeBit(ByVal iValue As Byte, iNumBit As Integer) As Byte
        Dim iMask As Integer

        Try
            If iNumBit < 0 Then iNumBit = 0
            If iNumBit > 7 Then iNumBit = 7

            iMask = CInt(2 ^ iNumBit)                          ' Create a bitmask with the 2^bit
            mcrChangeBit = CByte(iValue Xor iMask)

        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrResetBit-Byte", ex, "Value: " & iValue.ToString)
            mcrChangeBit = 0
        End Try
    End Function

    Public Overloads Shared Function mcrChangeBit(ByVal iValue As UShort, iNumBit As Integer) As UShort
        Dim iMask As Integer

        Try
            If iNumBit < 0 Then iNumBit = 0
            If iNumBit > 15 Then iNumBit = 15

            iMask = CInt(2 ^ iNumBit)                          ' Create a bitmask with the 2^bit
            mcrChangeBit = CUShort((iValue Xor iMask))

        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrResetBit-Word", ex, "Value: " & iValue.ToString)
            mcrChangeBit = 0
        End Try
    End Function

    Public Overloads Shared Function mcrChangeBit(ByVal iValue As UInt32, iNumBit As Integer) As UInt32
        Dim iMask As Integer

        Try
            If iNumBit < 0 Then iNumBit = 0
            If iNumBit > 31 Then iNumBit = 31

            iMask = CInt(2 ^ iNumBit)                          ' Create a bitmask with the 2^bit
            mcrChangeBit = CUInt((iValue Xor iMask))

        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrResetBit-DWord", ex, "Value: " & iValue.ToString)
            mcrChangeBit = 0
        End Try

    End Function

#End Region

#End Region

#Region "BCD Conversions"

#Region "Num To BCD"
    Public Overloads Shared Function mcrNumToBCD(ByVal iValue As Byte) As String
        Dim sValue As String
        Dim iBCD As Byte

        Try
            sValue = iValue.ToString("X2")
            If IsNumeric(sValue) Then
                iBCD = Convert.ToByte(sValue)
                mcrNumToBCD = iBCD.ToString("00")
            Else
                mcrNumToBCD = ".."
            End If

        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrIntToBCD-Byte", ex, "Value: " & iValue.ToString)
            mcrNumToBCD = "Err"
        End Try
    End Function

    Public Overloads Shared Function mcrNumToBCD(ByVal iValue As UShort) As String
        Dim sValue As String
        Dim iBCD As UShort

        Try
            sValue = iValue.ToString("X4")
            If IsNumeric(sValue) Then
                iBCD = Convert.ToUInt16(sValue)
                mcrNumToBCD = iBCD.ToString("0000")
            Else
                mcrNumToBCD = "...."
            End If

        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrIntToBCD-Word", ex, "Value: " & iValue.ToString)
            mcrNumToBCD = "Err"
        End Try
    End Function

    Public Overloads Shared Function mcrNumToBCD(ByVal iValue As UInt32) As String
        Dim sValue As String
        Dim iBCD As UInt32
        Dim sTmp As String

        Try
            sValue = iValue.ToString("X8")
            If IsNumeric(sValue) Then
                iBCD = Convert.ToUInt32(sValue)
                sTmp = iBCD.ToString("00000000")
                mcrNumToBCD = sTmp.Substring(0, 4) & " " & sTmp.Substring(4, 4)
            Else
                mcrNumToBCD = "...."
            End If

        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrIntToBCD-DWord", ex, "Value: " & iValue.ToString)
            mcrNumToBCD = "Err"
        End Try
    End Function

#End Region

#Region "BCD to Num"

    Public Shared Function mcrBCDToNum(ByVal iValue As Byte) As Byte
        Dim iOp1 As Byte, iOp2 As Byte

        Try
            iOp1 = CByte((iValue >> 4) * 10)
            iOp2 = CByte(iValue And &HF)
            mcrBCDToNum = iOp1 + iOp2

        Catch ex As Exception
            logFatal(myApp, sModuleName, "mcrBCDToNum-Byte", ex, "Value: " & iValue.ToString)
            mcrBCDToNum = 0
        End Try
    End Function

#End Region



#End Region

#End Region


End Class
