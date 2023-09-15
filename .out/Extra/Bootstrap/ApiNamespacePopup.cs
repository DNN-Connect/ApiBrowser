
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
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("NamespaceId")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="NamespaceId" value="@Model.NamespaceId">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("ParentId")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="ParentId" value="@Model.ParentId">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("ModuleId")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="ModuleId" value="@Model.ModuleId">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("NamespaceName")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="NamespaceName" value="@Model.NamespaceName">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("LastQualifier")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="LastQualifier" value="@Model.LastQualifier">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("Description")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="Description" value="@Model.Description">
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

