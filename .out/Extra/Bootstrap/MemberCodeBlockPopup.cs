
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
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("CodeBlockId")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="CodeBlockId" value="@Model.CodeBlockId">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("MemberId")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="MemberId" value="@Model.MemberId">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("Version")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="Version" value="@Model.Version">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("CodeHash")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="CodeHash" value="@Model.CodeHash">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("StartLine")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="StartLine" value="@Model.StartLine">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("StartColumn")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="StartColumn" value="@Model.StartColumn">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("EndLine")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="EndLine" value="@Model.EndLine">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("EndColumn")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="EndColumn" value="@Model.EndColumn">
  </div>
 </div>
 <div class="form-group">
  <label for="Title" class="col-sm-2 control-label">@Html.GetLocalizedString("FileName")</label>
  <div class="col-sm-10">
   <input type="text" class="form-control" id="FileName" value="@Model.FileName">
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

