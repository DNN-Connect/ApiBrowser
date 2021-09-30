<%
 var homeUrl = DotNetNuke.Common.Globals.NavigateURL(PortalSettings.HomeTabId);
%>

<header>
  <div class="container-fluid">
    <nav class="navbar navbar-expand-lg navbar-light bg-light rounded" aria-label="Eleventh navbar example">
      <div class="container-fluid">
        <a class="navbar-brand" href="<%= homeUrl %>"><%= PortalSettings.PortalName %></a>
        <div class="collapse navbar-collapse" id="navbarsExample09">
          <dnn:MENU id="menu" MenuStyle="menus/razor" runat="server" NodeSelector="*"></dnn:MENU>
        </div>
      </div>
    </nav>
  </div>
</header>