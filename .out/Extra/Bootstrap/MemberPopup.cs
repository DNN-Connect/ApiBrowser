
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
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("MemberId")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="MemberId" value="@Model.MemberId">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("ClassId")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="ClassId" value="@Model.ClassId">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("MemberType")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="MemberType" value="@Model.MemberType">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("MemberName")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="MemberName" value="@Model.MemberName">
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
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsPrivate")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsPrivate" value="@Model.IsPrivate">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsStatic")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsStatic" value="@Model.IsStatic">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsGetter")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsGetter" value="@Model.IsGetter">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("IsSetter")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="IsSetter" value="@Model.IsSetter">
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

