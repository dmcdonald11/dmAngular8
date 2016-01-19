'Imports System
'Imports System.Linq
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http
Imports DotNetNuke.Web.Api
Imports DotNetNuke.Security
Imports NWSC.Modules.DMAngular8.Components
'Imports System.Collections.Generic
Imports System.Data.SqlClient
'Imports DotNetNuke.Web.Mvc.Framework.Controllers
'Imports DotNetNuke.Services.Search.Entities




Namespace Services.Controllers

    <SupportedModules(Constants.DESKTOPMODULE_NAME)>
    <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.View)>
    Public Class homeController
        Inherits DnnApiController

        'Protected Const ACCESS_LEVEL As SecurityAccessLevel = SecurityAccessLevel.Anonymous

        Private _ctcallRepository As CTCallRepository

        Private Sub New()
            _ctcallRepository = New CTCallRepository()
        End Sub

        ''' <summary>
        ''' API that returns Hello world
        '''[baseURL]/CTCall/test
        ''' </summary>
        ''' <returns></returns>
        <HttpPost, HttpGet>
        <ActionName("test")>
        <AllowAnonymous>
        Public Function HelloWorld() As HttpResponseMessage
            Return Request.CreateResponse(HttpStatusCode.OK, "Hello DNN World!")
        End Function

        ''' <summary>
        ''' API that creates a new CTCall in the CTCall list
        '''[baseURL]/CTCall/new
        ''' </summary>
        ''' <returns></returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        <ActionName("new")>
        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.Edit)>
        Public Function AddCTCall(t As CTCall) As HttpResponseMessage

            Try
                Dim newCTCall As New CTCall()
                newCTCall.ModuleId = ActiveModule.ModuleID
                newCTCall.CreatedByUserId = UserInfo.UserID
                newCTCall.CreatedOnDate = DateTime.Now
                newCTCall.LastModifiedByUserId = UserInfo.UserID
                newCTCall.LastModifiedOnDate = DateTime.Now
                newCTCall.CallDate = DateTime.Now
                newCTCall.CallerName = t.CallerName
                newCTCall.CallerAddress = t.CallerAddress
                newCTCall.CallerCity = t.CallerCity
                newCTCall.Region = t.Region
                newCTCall.UtilityType = t.UtilityType
                newCTCall.CallBackNumber = t.CallBackNumber
                newCTCall.CrossStreet = t.CrossStreet
                newCTCall.Comments = t.Comments
                newCTCall.CallType = t.CallType
                Dim callId As Integer = _ctcallRepository.CreateCTCall(newCTCall)
                Return Request.CreateResponse(HttpStatusCode.OK, callId)
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' API that deletes an CTCall from the CTCall list
        '''[baseURL]/CTCall/delete
        ''' </summary>
        ''' <returns></returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        <ActionName("delete")>
        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.Edit)>
        Public Function DeleteCTCall(delCTCall As CTCall) As HttpResponseMessage
            Try
                _ctcallRepository.DeleteCTCall(delCTCall.CallId, ActiveModule.ModuleID)
                Return Request.CreateResponse(HttpStatusCode.OK, True.ToString())
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' API that creates a new CTCall in the CTCall list
        '''[baseURL]/CTCall/edit
        ''' </summary>
        ''' <returns></returns>
        <HttpPost>
        <ValidateAntiForgeryToken>
        <ActionName("edit")>
        <DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.Edit)>
        Public Function UpdateCTCall(ctcall As CTCall) As HttpResponseMessage
            Try
                ctcall.LastModifiedByUserId = UserInfo.UserID
                ctcall.LastModifiedOnDate = DateTime.Now
                _ctcallRepository.UpdateCTCall(ctcall)
                Return Request.CreateResponse(HttpStatusCode.OK, True.ToString())
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' API that returns an CTCall list
        '''[baseURL]/home/List
        ''' </summary>
        ''' <returns></returns>
        <HttpPost, HttpGet>
        <ValidateAntiForgeryToken>
        <ActionName("List")>
        Public Function GetCTCalls() As HttpResponseMessage
            Try
                Dim ctcallList = _ctcallRepository.GetCTCalls(ActiveModule.ModuleID)
                Return Request.CreateResponse(HttpStatusCode.OK, ctcallList.ToList())
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try
        End Function


        <HttpPost, HttpGet>
        <ValidateAntiForgeryToken>
        <ActionName("RegionList")>
        Public Function GetRegions() As HttpResponseMessage

            Try
                Dim ctcallList = _ctcallRepository.GetCTCalls(ActiveModule.ModuleID)
                Return Request.CreateResponse(HttpStatusCode.OK, ctcallList.ToList())
            Catch ex As Exception
                Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
            End Try




        End Function





        '''' <summary>
        '''' API that returns a single CTCall
        '''' </summary>
        '''' <returns></returns>
        ''''[baseURL]/CTCall/byid
        '<HttpPost, HttpGet>
        '<ValidateAntiForgeryToken>
        '<ActionName("byid")>
        '<DnnModuleAuthorize(AccessLevel:=SecurityAccessLevel.View)>
        'Public Function GetCTCall(ctcallReq As RequestById) As HttpResponseMessage
        '    Try
        '        Dim ctcall = _ctcallRepository.GetCTCall(ctcallReq.CallId, ActiveModule.ModuleID)
        '        Return Request.CreateResponse(HttpStatusCode.OK, ctcall)
        '    Catch ex As Exception
        '        Return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message)
        '    End Try
        'End Function


        'Public Function GetCalls() As JsonResult
        '    ' using entity framework
        '    'Dim db As New CallTrackerDBEntities
        '    'Dim Calls = db.CallTrackerCalls.ToList()
        '    'Return Json(Calls, JsonRequestBehavior.AllowGet)

        '    Dim dt As New DataTable()
        '    Dim mySQL As String
        '    'Use Connection string in DNN
        '    'Dim dbConn As  String = ConfigurationManager.ConnectionStrings("SiteSqlServer").ConnectionString

        '    mySQL = "Select CallId, CallDate, CallerName, CallerAddress, CallerCity," _
        '            & "Region, UtilityType, CallBackNumber, CrossStreet, Comments," _
        '            & "DispatchId, CallType, PortalId, ModuleId, LastModifiedOnDate," _
        '            & "LastModifiedByUserId from dbo.CallTrackerCalls "

        '    'Using con As New SqlConnection(dbConn)
        '    Using con As New SqlConnection("Data Source=.;Initial Catalog=dnndev.me;Integrated Security=true")
        '        Using cmd As New SqlCommand(mySQL, con)
        '            con.Open()
        '            Dim da As New SqlDataAdapter(cmd)
        '            da.Fill(dt)
        '        End Using
        '    End Using
        '    Return Json(ConvertDataTabletoString(dt), JsonRequestBehavior.AllowGet)

        'End Function

        'Public Function GetRegions() As JsonResult
        '    ' using entity framework
        '    'Dim db As New CallTrackerDBEntities
        '    'Dim Calls = db.CallTrackerCalls.ToList()
        '    'Return Json(Calls, JsonRequestBehavior.AllowGet)

        '    Dim dt As New DataTable()
        '    Dim mySQL As String
        '    'Use Connection string in DNN
        '    'Dim dbConn As  String = ConfigurationManager.ConnectionStrings("SiteSqlServer").ConnectionString

        '    mySQL = "Select RegionId, RegionDesc " _
        '            & " from dbo.CallTrackerRegionDim "

        '    'Using con As New SqlConnection(dbConn)
        '    Using con As New SqlConnection("Data Source=.;Initial Catalog=dnndev.me;Integrated Security=true")
        '        Using cmd As New SqlCommand(mySQL, con)
        '            con.Open()
        '            Dim da As New SqlDataAdapter(cmd)
        '            da.Fill(dt)
        '            Return Json(ConvertDataTabletoString(dt), JsonRequestBehavior.AllowGet)
        '        End Using
        '    End Using

        'End Function

        ''  This function converts a Data Table to a string object that can be converted to JSON for the client side data binding.
        Private Function ConvertDataTabletoString(myDataTable As DataTable) As List(Of Dictionary(Of String, Object))

            Dim rows As New List(Of Dictionary(Of String, Object))()
            Dim row As Dictionary(Of String, Object)
            For Each dr As DataRow In myDataTable.Rows
                row = New Dictionary(Of String, Object)()
                For Each col As DataColumn In myDataTable.Columns
                    row.Add(col.ColumnName, dr(col))
                Next
                rows.Add(row)
            Next
            Return rows
        End Function


    End Class



    'Public Class RequestCTCall
    '    Public Property CallId() As Integer
    '        Get
    '            Return m_CallId
    '        End Get
    '        Set
    '            m_CallId = Value
    '        End Set
    '    End Property
    '    Private m_CallId As Integer
    '    Public Property CallerName() As String
    '        Get
    '            Return m_CallerName
    '        End Get
    '        Set
    '            m_CallerName = Value
    '        End Set
    '    End Property
    '    Private m_CallerName As String
    '    Public Property CallerDescription() As String
    '        Get
    '            Return m_CallerDescription
    '        End Get
    '        Set
    '            m_CallerDescription = Value
    '        End Set
    '    End Property
    '    Private m_CallerDescription As String
    '    Public Property AssignedUserId() As Integer
    '        Get
    '            Return m_AssignedUserId
    '        End Get
    '        Set
    '            m_AssignedUserId = Value
    '        End Set
    '    End Property
    '    Private m_AssignedUserId As Integer
    '    Public Property CreatedByUserId() As Integer
    '        Get
    '            Return m_CreatedByUserId
    '        End Get
    '        Set
    '            m_CreatedByUserId = Value
    '        End Set
    '    End Property
    '    Private m_CreatedByUserId As Integer
    '    Public Property CreatedCreatedOnDate() As DateTime
    '        Get
    '            Return m_CreatedCreatedOnDate
    '        End Get
    '        Set
    '            m_CreatedCreatedOnDate = Value
    '        End Set
    '    End Property
    '    Private m_CreatedCreatedOnDate As DateTime
    'End Class

    'Public Class RequestById
    '    Public Property CallId() As Integer
    '        Get
    '            Return m_CallId
    '        End Get
    '        Set
    '            m_CallId = Value
    '        End Set
    '    End Property
    '    Private m_CallId As Integer
    'End Class

    'Public Class SearchRequest
    '    Public Property Term() As String
    '        Get
    '            Return m_Term
    '        End Get
    '        Set
    '            m_Term = Value
    '        End Set
    '    End Property
    '    Private m_Term As String
    '    Public Property PageSize() As Integer
    '        Get
    '            Return m_PageSize
    '        End Get
    '        Set
    '            m_PageSize = Value
    '        End Set
    '    End Property
    '    Private m_PageSize As Integer
    '    Public Property PageNum() As Integer
    '        Get
    '            Return m_PageNum
    '        End Get
    '        Set
    '            m_PageNum = Value
    '        End Set
    '    End Property
    '    Private m_PageNum As Integer
    '    Public Property ModuleId() As Integer
    '        Get
    '            Return m_ModuleId
    '        End Get
    '        Set
    '            m_ModuleId = Value
    '        End Set
    '    End Property
    '    Private m_ModuleId As Integer
    'End Class

End Namespace
