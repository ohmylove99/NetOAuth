1. New WEB => Asp.Net => Empty App
2. Install Nuget:
install-package Microsoft.Owin.Host.SystemWeb –Pre
install-package Microsoft.Owin.Diagnostics –Pre
3. Enable Anymous auth and use Window Auth, then check with Fiddler see 401 but works in Browser
4. Fix IIS:
4.1 Fix Locking is either by default (overrideModeDefault=”Deny”) issue for Windows Auth:
   a.) Feature Delegation: Change Auth -Anonmous set Read/Write
4.2 Fix target Framework 4.5.2 issue
   a.) run cmd as Admin: %windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -ir
   b.) Open Application Pools Assign Target Framework to 4.0
5. Enable Windows Auth In IIS and Integration Windows Auth in IE.
	Turn Windows Features on or off => World Wide Web Services, then Security => Windows Authentication ; reopen IIS click Authentication you will see windows Auth
    IE Options => Advanced => integration Windows Auth
6. Enable Oauth
6.1 Add Oauth Support:
Install-Package Microsoft.AspNet.WebApi
Install-Package Microsoft.AspNet.WebApi.Owin
Install-Package Microsoft.Owin.Cors
Install-Package Microsoft.Owin.Security.OAuth