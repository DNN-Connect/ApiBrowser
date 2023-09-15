
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
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("DependencyId")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="DependencyId" value="@Model.DependencyId">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("ComponentHistoryId")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="ComponentHistoryId" value="@Model.ComponentHistoryId">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("FullName")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="FullName" value="@Model.FullName">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("Version")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="Version" value="@Model.Version">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("VersionNormalized")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="VersionNormalized" value="@Model.VersionNormalized">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("Name")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="Name" value="@Model.Name">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("DepComponentHistoryId")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="DepComponentHistoryId" value="@Model.DepComponentHistoryId">
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

