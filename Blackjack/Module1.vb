Module Module1
    Sub Main()
        Dim playing As Boolean = True
        Dim move As String
        Dim cardsNum As Integer = 2
        Dim card(11) As Integer
        For i As Integer = 0 To 1
            Dim random As Integer = GenRandom()
            card(i) = random
            For j As Integer = 0 To card.Length - 1
                While card(j) = random And j <> i
                    random = GenRandom()
                    card(i) = random
                End While
            Next
        Next
        While playing And GetLength(card) < 11 And Check21(card) < 21
            Do
                Console.Clear()
                PrintCards(card)
                Console.WriteLine(Check21(card))
                Console.WriteLine("(H)it or (S)tand?")
                move = Console.ReadLine()
                Select Case move.ToUpper
                    Case "H"
                        Dim random = GenRandom()
                        card(cardsNum) = random
                        For i As Integer = 0 To card.Length - 1
                            While card(i) = random And i <> cardsNum
                                random = GenRandom()
                                card(i) = random
                            End While
                        Next
                        cardsNum += 1
                    Case "S"
                        playing = False
                    Case Else
                        Console.WriteLine("Invalid Input")
                End Select
            Loop Until move.ToUpper = "S" Or move.ToUpper = "H"
        End While
        Console.Clear()
        PrintCards(card)
        Console.WriteLine(Check21(card))
        If Check21(card) = 21 Then
            Console.WriteLine("You Won")
        ElseIf Check21(card) < 21 Then
            Console.WriteLine("You are under 21")
        Else
            Console.WriteLine("Bust")
        End If
        If Check21(card) <> 21 Then Console.WriteLine("You were " & 21 - Check21(card) & " off of 21")
        Console.ReadLine()
    End Sub
    Public Function GenRandom()
        Dim random As Integer
        Randomize()
        random = (51 * Rnd()) + 1
        While random Mod 13 = 0
            random = (51 * Rnd()) + 1
        End While
        Return random
    End Function
    Public Function PrintCards(cards)
        For i As Integer = 0 To cards.Length - 1
            Console.WriteLine(GetCard(cards(i)))
        Next
        Return 0
    End Function
    Public Function GetLength(card)
        Dim length As Integer
        For i = 0 To card.Length - 1
            If card(i) <> 0 Then
                length += 1
            End If
        Next
        Return length
    End Function
    Public Function GetCard(cardnum)
        If cardnum = 0 Then
            Return " "
        End If
        Select Case cardnum \ 13
            Case 0
                Select Case cardnum Mod 13
                    Case 10
                        Return "♠J"
                    Case 11
                        Return "♠Q"
                    Case 12
                        Return "♠K"
                    Case Else
                        Return "♠" & (cardnum Mod 13)
                End Select
            Case 1
                Select Case cardnum Mod 13
                    Case 10
                        Return "♥J"
                    Case 11
                        Return "♥Q"
                    Case 12
                        Return "♥K"
                    Case Else
                        Return "♥" & (cardnum Mod 13)
                End Select
            Case 2
                Select Case cardnum Mod 13
                    Case 10
                        Return "♦J"
                    Case 11
                        Return "♦Q"
                    Case 12
                        Return "♦K"
                    Case Else
                        Return "♦" & (cardnum Mod 13)
                End Select
            Case 3
                Select Case cardnum Mod 13
                    Case 10
                        Return "♣J"
                    Case 11
                        Return "♣Q"
                    Case 12
                        Return "♣K"
                    Case Else
                        Return "♣" & (cardnum Mod 13)
                End Select
            Case Else
                Return " "
        End Select
    End Function
    Public Function Check21(cards)
        Dim count As Integer
        Dim aces As Integer
        For i = 0 To cards.length - 1
            If cards(i) Mod 13 > 10 Then
                count += 10
            ElseIf cards(i) Mod 13 = 1 Then
                aces += 1
            Else
                count += cards(i) Mod 13
            End If
        Next
        Select Case aces
            Case 1
                If 21 - count >= 11 Then
                    count += 11
                Else
                    count += 1
                End If
            Case 2
                If 21 - count >= 12 Then
                    count += 12
                Else
                    count += 2
                End If
            Case 3
                If 21 - count >= 13 Then
                    count += 13
                Else
                    count += 3
                End If
            Case 4
                If 21 - count >= 14 Then
                    count += 14
                Else
                    count += 4
                End If
        End Select
        Return count
    End Function
End Module
' problem with ace switching from 11 to 1 mid game