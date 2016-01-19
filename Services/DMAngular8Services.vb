Imports DotNetNuke.Web.Api
Imports NWSC.Modules.DMAngular8.Components

Namespace Services


    Public Class DMAngular8Services


        Implements IServiceRouteMapper

        Public Sub RegisterRoutes(mapRouteManager As IMapRoute) Implements IServiceRouteMapper.RegisterRoutes
            mapRouteManager.MapHttpRoute(Constants.DESKTOPMODULE_NAME, "default", "{controller}/{action}", {"NWSC.Modules.DMAngular8.Services.Controllers"})
        End Sub




    End Class

End Namespace


