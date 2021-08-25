$(document).ready(function () {
    $("#updateButton").click(function () {
        debugger;
        $.ajax({
            url: '/Article/UpdateArticleFromView',
            data: { id: $("#Id").val() },
            success: function (view) {
                $('#articleViewForm').hide();
                $("#formForUpdateArticle").toggleClass("d-none");
                $("#formForUpdateArticle").html(view);

                $('#refreshPage').click(function () {
                    location.reload();
                })
            }
        })
    })
})