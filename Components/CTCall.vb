Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.ComponentModel.DataAnnotations
Imports System.Web.Caching
Imports System

Namespace Components

    'setup the primary key for table
    'configure caching using PetaPoco
    'scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    <Serializable>
    <TableName("dmAngular8_CTCalls")>
    <PrimaryKey("CallId", AutoIncrement:=True)>
    <Cacheable("CTCalls", CacheItemPriority.Default, 20)>
    <Scope("ModuleId")>
    Public Class CTCall

        Private _CallId As Integer
        Private _CallDate As DateTime
        Private _CallerName As String
        Private _CallerAddress As String
        Private _CallerCity As String
        Private _Region As String
        Private _UtilityType As String
        Private _CallBackNumber As Integer
        Private _CrossStreet As String
        Private _Comments As String
        Private _CallType As String
        Private _createdByUserId As Integer
        Private _lastModifiedByUserId As Integer
        Private _createdOnDate As DateTime
        Private _lastModifiedOnDate As DateTime
        Private _moduleId As Integer

        Public Sub New()
            CallId = -1
        End Sub
        Public Property CallId() As Integer
            Get
                Return _CallId
            End Get
            Set(ByVal value As Integer)
                _CallId = value
            End Set
        End Property
        Public Property CallDate() As DateTime
            Get
                Return _CallDate
            End Get
            Set(ByVal value As DateTime)
                _CallDate = value
            End Set
        End Property
        Public Property CallerName() As String
            Get
                Return _CallerName
            End Get
            Set(ByVal value As String)
                _CallerName = value
            End Set
        End Property
        Public Property CallerAddress() As String
            Get
                Return _CallerAddress
            End Get
            Set(ByVal value As String)
                _CallerAddress = value
            End Set
        End Property
        Public Property CallerCity() As String
            Get
                Return _CallerCity
            End Get
            Set(ByVal value As String)
                _CallerCity = value
            End Set
        End Property
        Public Property Region() As String
            Get
                Return _Region
            End Get
            Set(ByVal value As String)
                _Region = value
            End Set
        End Property
        Public Property UtilityType() As String
            Get
                Return _UtilityType
            End Get
            Set(ByVal value As String)
                _UtilityType = value
            End Set
        End Property
        Public Property CallBackNumber() As Integer
            Get
                Return _CallBackNumber
            End Get
            Set(ByVal value As Integer)
                _CallBackNumber = value
            End Set
        End Property
        Public Property CrossStreet() As String
            Get
                Return _CrossStreet
            End Get
            Set(ByVal value As String)
                _CrossStreet = value
            End Set
        End Property
        Public Property Comments() As String
            Get
                Return _Comments
            End Get
            Set(ByVal value As String)
                _Comments = value
            End Set
        End Property
        Public Property CallType() As String
            Get
                Return _CallType
            End Get
            Set(ByVal value As String)
                _CallType = value
            End Set
        End Property

        Public Overloads Property CreatedByUserId() As Integer
            Get
                Return _createdByUserId
            End Get
            Set(ByVal value As Integer)
                _createdByUserId = value
            End Set
        End Property

        Public Overloads Property LastModifiedByUserId() As Integer
            Get
                Return _lastModifiedByUserId
            End Get
            Set(ByVal value As Integer)
                _lastModifiedByUserId = value
            End Set
        End Property

        Public Overloads Property CreatedOnDate() As DateTime
            Get
                Return _createdOnDate
            End Get
            Set(ByVal value As DateTime)
                _createdOnDate = value
            End Set
        End Property
        Public Overloads Property LastModifiedOnDate() As DateTime
            Get
                Return _lastModifiedOnDate
            End Get
            Set(ByVal value As DateTime)
                _lastModifiedOnDate = value
            End Set
        End Property

        Public Overloads Property ModuleId() As Integer
            Get
                Return _moduleId
            End Get
            Set(ByVal value As Integer)
                _moduleId = value
            End Set
        End Property


    End Class

End Namespace

