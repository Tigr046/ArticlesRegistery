$(document).ready(function () {
    $.ajax({
        url: '/Layout/GetHeaderByUser',
        success: function (headerLinksContent) {
            debugger;
            $('#linksContainer').html(headerLinksContent)
        },
        async :false  
        }
    )
    debugger;
    $.ajax({
        url: '/Notice/GetUnreadedNoticeCount',
        success: function (UnreadedNoticeCount) {
            debugger;
            if (UnreadedNoticeCount > 0)
                $("#NoticeLink").html($("#NoticeLink").html() + ' (Новых уведомлений: ' + UnreadedNoticeCount +')')
        }
    })
})