
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
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("ReferenceId")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="ReferenceId" value="@Model.ReferenceId">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("CodeBlockId")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="CodeBlockId" value="@Model.CodeBlockId">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("FullName")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="FullName" value="@Model.FullName">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("Offset")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="Offset" value="@Model.Offset">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("ReferencedMemberId")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="ReferencedMemberId" value="@Model.ReferencedMemberId">
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

