$(document).ready(function () {
    $.ajax({
        url: '/Notice/GetUnreadedNoticeCount',
        success: function (UnreadedNoticeCount) {
            debugger;
            $("#UnreadedNotice").html(UnreadedNoticeCount)
        }
    })
})