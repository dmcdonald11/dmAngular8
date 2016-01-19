Imports System.Collections.Generic
Imports DotNetNuke.Collections
Imports DotNetNuke.Data
Imports System
Imports System.CodeDom
Imports System.Linq
Imports DotNetNuke.Common
Imports DotNetNuke.Framework



Namespace Components
    Public Class CTCallRepository


        Public Function CreateCTCall(t As CTCall) As Integer
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep = ctx.GetRepository(Of CTCall)()
                rep.Insert(DirectCast(t, CTCall))
                Return t.CallId
            End Using
        End Function


        'Public Sub CreateCTCall(ByVal t As CTCall)
        '    Using ctx As IDataContext = DataContext.Instance()
        '        Dim rep As IRepository(Of CTCall) = ctx.GetRepository(Of CTCall)()
        '        rep.Insert(t)
        '    End Using
        'End Sub

        Public Sub DeleteCTCall(ByVal t As Integer, ByVal moduleId As Integer)
            Dim _item As CTCall = GetCTCall(t, moduleId)
            DeleteCTCall(_item)
        End Sub

        Public Sub DeleteCTCall(ByVal t As CTCall)
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep As IRepository(Of CTCall) = ctx.GetRepository(Of CTCall)()
                rep.Delete(t)
            End Using
        End Sub

        Public Function GetCTCalls(ByVal _moduleId As Integer) As IEnumerable(Of CTCall)
            Dim t As IEnumerable(Of CTCall)

            Using ctx As IDataContext = DataContext.Instance()
                Dim rep As IRepository(Of CTCall) = ctx.GetRepository(Of CTCall)()
                t = rep.Get(_moduleId)
            End Using
            Return t
        End Function

        Public Function GetCTCall(ByVal Callid As Integer, ByVal moduleId As Integer) As CTCall
            Dim t As CTCall

            Using ctx As IDataContext = DataContext.Instance()
                Dim rep As IRepository(Of CTCall) = ctx.GetRepository(Of CTCall)()
                t = rep.GetById(Of Int32, Int32)(Callid, moduleId)
            End Using
            Return t
        End Function

        Public Sub UpdateCTCall(ByVal t As CTCall)
            Using ctx As IDataContext = DataContext.Instance()
                Dim rep As IRepository(Of CTCall) = ctx.GetRepository(Of CTCall)()
                rep.Update(t)
            End Using
        End Sub


    End Class

End Namespace


