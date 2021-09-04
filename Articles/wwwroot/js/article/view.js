$(document).ready(function () {
    $('#commentToShow').click(function () {
        if ($("#commentsView").attr("commentsHidden") === 'true') {
            $.ajax({
                url: '/Article/ShowComments',
                data: { articleId: $("#Id").val() },
                success: function (view) {
                    $("#commentsView").html(view);
                    $("#commentsView").attr("commentsHidden", "false")
                }
            })
        }
        else if ($("#commentsView").attr("commentsHidden") === 'false') {
            $("#commentsView").html(" ");
            $("#commentsView").attr("commentsHidden", "true")
        }
        
    })
    $("#updateButton").click(function () {
        $.ajax({
            url: '/Article/UpdateArticleFromView',
            data: { id: $("#Id").val() },
            success: function (view) {
                $('#articleViewForm').hide();
                $("#formForUpdateArticle").toggleClass("d-none");
                $("#formForUpdateArticle").html(view);

                $('#backButton').click(function () {
                    location.reload();
                })
            }
        })
    })
})