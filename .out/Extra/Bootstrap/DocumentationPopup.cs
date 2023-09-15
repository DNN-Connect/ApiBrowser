
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
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("DocumentationId")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="DocumentationId" value="@Model.DocumentationId">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("ModuleId")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="ModuleId" value="@Model.ModuleId">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("FullName")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="FullName" value="@Model.FullName">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("Contents")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="Contents" value="@Model.Contents">
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
    </div>
   </div>
  </div>
  <div class="modal-footer">
   <a href="#" id="cmdCancel" class="btn btn-default" data-dismiss="modal">@Html.GetLocalizedString("cmdCancel")</a>
   <a href="#" id="cmdSubmit" class="btn btn-primary">@Html.GetLocalizedString("cmdSubmit")</a>
  </div>
 </div>
</div>

