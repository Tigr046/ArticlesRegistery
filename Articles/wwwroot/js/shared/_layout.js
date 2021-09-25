$(document).ready(function () {
    $.ajax({
        url: '/Layout/GetHeaderByUser',
        success: function (headerLinksContent) {
            $('#linksContainer').html(headerLinksContent)
        },
        async :false  
        }
    )

    $.ajax({
        url: '/Notice/GetUnreadedNoticeCount',
        success: function (UnreadedNoticeCount) {
            if (UnreadedNoticeCount > 0)
                $("#NoticeLink").html($("#NoticeLink").html() + ' (Новых уведомлений: ' + UnreadedNoticeCount +')')
        }
    })
})