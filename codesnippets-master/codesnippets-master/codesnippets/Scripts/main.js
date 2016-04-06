try {
    jQuery(document).ready(function () {

        $(function () {
            $("#SelectedLanguageId").change(function () {
                var selectedItem = $(this).val();
                var ddlVersions = $("#SelectedLanguageVersionId");
                var versionsProgress = $("#states-loading-progress");
                versionsProgress.show();
                $.ajax({
                    cache: false,
                    type: "GET",
                    url: "/Snippets/GetVersionByLanguageId",
                    data: { "languageId": selectedItem },
                success: function (data) {
                    ddlVersions.html('');
                    $.each(data, function (id, option) {
                        ddlVersions.append($('<option></option>').val(option.id).html(option.name));
                    });
                    versionsProgress.hide();
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert('Failed to retrieve versions.');
                    versionsProgress.hide();
                }
            });
        });
    });
});
} catch (e) {
    alert(e);
}