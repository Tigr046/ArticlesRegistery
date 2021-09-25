$(document).ready(function () {
    $('.unreadednotice').click(function (e) {
        var target = e.target;
        var id = Number(target.getAttribute('val'))
        
        $.ajax({
            url: '/Notice/MarkNoticeAsRead',
            data: { noticeId: id},
        })
        target.classList.remove("bgColorGrey")
    })
    $('.deleteNotice').click(function (e) {
        debugger;
        var target = e.target;
        var id = Number(target.getAttribute('val'))
        $.ajax({
            url: '/Notice/Delete',
            data: { id: id },
            success: function () {
                debugger;
                target.closest('.notice').remove()
            }
        })
    })
})