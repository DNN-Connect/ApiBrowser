<header>
  <div>
    <ul>
      <li>
        <dnn:Login runat="server" id="dnnLogin" />
      </li>
      <li>
        <dnn:User runat="server" id="dnnUser" />
      </li>
      <li>
        <dnn:Search runat="server" id="dnnSearch" ShowSite="false" ShowWeb="false" Submit="<i class='fas fa-search'></i>" />
      </li>
      <li style="display:none;">
        <dnn:Language runat="server" id="dnnLanguage" ShowMenu="false" ShowLinks="false" />
      </li>
    </ul>
  </div>
  <div>
    <dnn:LOGO id="dnnLOGO" runat="server" />
    <nav id="nav-items">
      <dnn:MENU id="menu" MenuStyle="menus/razor" runat="server" NodeSelector="*"></dnn:MENU>
    </nav>
  </div>
</header>