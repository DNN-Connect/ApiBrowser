
<div class="modal-dialog modal-lg">
 <div class="modal-content">
  <div class="modal-header">
   <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
   <h4 class="modal-title" id="cmModalLabel">@Html.GetLocalizedString("EditUser")</h4>
  </div>
  <div class="modal-body">
   <div class="row">
    <div class="col-xs-12 form-horizontal">
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("ClassId")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="ClassId" value="@Model.ClassId">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("NamespaceId")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="NamespaceId" value="@Model.NamespaceId">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("ComponentId")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="ComponentId" value="@Model.ComponentId">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("ClassName")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="ClassName" value="@Model.ClassName">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("Declaration")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="Declaration" value="@Model.Declaration">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("Documentation")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="Documentation" value="@Model.Documentation">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("Description")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="Description" value="@Model.Description">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("AppearedInVersion")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="AppearedInVersion" value="@Model.AppearedInVersion">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("DeprecatedInVersion")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="DeprecatedInVersion" value="@Model.DeprecatedInVersion">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("DisappearedInVersion")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="DisappearedInVersion" value="@Model.DisappearedInVersion">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsDeprecated")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsDeprecated" value="@Model.IsDeprecated">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("DeprecationMessage")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="DeprecationMessage" value="@Model.DeprecationMessage">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("DocumentationId")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="DocumentationId" value="@Model.DocumentationId">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("PendingDescription")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="PendingDescription" value="@Model.PendingDescription">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("CreatedByUserID")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="CreatedByUserID" value="@Model.CreatedByUserID">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("CreatedOnDate")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="CreatedOnDate" value="@Model.CreatedOnDate">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("LastModifiedByUserID")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="LastModifiedByUserID" value="@Model.LastModifiedByUserID">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("LastModifiedOnDate")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="LastModifiedOnDate" value="@Model.LastModifiedOnDate">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("FullName")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="FullName" value="@Model.FullName">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsAbstract")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsAbstract" value="@Model.IsAbstract">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsAnsiClass")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsAnsiClass" value="@Model.IsAnsiClass">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsArray")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsArray" value="@Model.IsArray">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsAutoClass")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsAutoClass" value="@Model.IsAutoClass">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsAutoLayout")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsAutoLayout" value="@Model.IsAutoLayout">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsBeforeFieldInit")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsBeforeFieldInit" value="@Model.IsBeforeFieldInit">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsByReference")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsByReference" value="@Model.IsByReference">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsClass")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsClass" value="@Model.IsClass">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsDefinition")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsDefinition" value="@Model.IsDefinition">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsEnum")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsEnum" value="@Model.IsEnum">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsExplicitLayout")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsExplicitLayout" value="@Model.IsExplicitLayout">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsFunctionPointer")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsFunctionPointer" value="@Model.IsFunctionPointer">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsGenericInstance")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsGenericInstance" value="@Model.IsGenericInstance">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsGenericParameter")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsGenericParameter" value="@Model.IsGenericParameter">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsImport")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsImport" value="@Model.IsImport">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsInterface")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsInterface" value="@Model.IsInterface">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsNested")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsNested" value="@Model.IsNested">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsNestedAssembly")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsNestedAssembly" value="@Model.IsNestedAssembly">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsNestedPrivate")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsNestedPrivate" value="@Model.IsNestedPrivate">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsNestedPublic")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsNestedPublic" value="@Model.IsNestedPublic">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsNotPublic")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsNotPublic" value="@Model.IsNotPublic">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("ParentClassId")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="ParentClassId" value="@Model.ParentClassId">
  </div>
 </div>
    </div>
   </div>
  </div>
  <div class="modal-footer">
   <a href="#" id="cmdCancel" class="btn btn-default" data-dismiss="modal">@Html.GetLocalizedString("cmdCancel")</a>
   <a href="#" id="cmdSubmit" class="btn btn-primary">@Html.GetLocalizedString("cmdSubmit")</a>
  </div>
 </div>
</div>

