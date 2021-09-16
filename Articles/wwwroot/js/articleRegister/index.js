$(document).ready(function () {
    fillArticleViewPage(0, 10)
    $(window).scroll(function () {
        if ($(window).scrollTop() + $(window).height() == $(document).height()) {
            setTimeout(() => {
                fillArticleViewPage(Number($("#PageNumber").val()), Number($("#PageSize").val()) + 10)
            }, 500);

        }
    });
})
function fillArticleViewPage(pageNumber, pageSize) {
    $.ajax({
        url: '/ArticleRegister/Read',
        data: { pageNumber: pageNumber, pageSize: pageSize },
        success: function (view) {
            $("#articleViewDiv").html(view)
            $("#PageNumber").val(pageNumber)
            $("#PageSize").val(pageSize)

        }
    })
}