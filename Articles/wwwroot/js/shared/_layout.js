$(document).ready(function () {
    $.ajax({
        url: '/Notice/GetUnreadedNoticeCount',
        success: function (UnreadedNoticeCount) {
            $("#UnreadedNotice").html(UnreadedNoticeCount)
        }
    })
})