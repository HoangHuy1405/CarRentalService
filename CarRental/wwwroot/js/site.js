$(document).ready(function () {
    function updateNotificationCount() {
        $.get('/Notification/GetNotifications', function (data) {
            // Access data.$values and check if it's an array
            if (Array.isArray(data.$values)) {
                var unreadCount = data.$values.filter(n => !n.isRead).length;
                var badge = $('#notification-count');
                if (unreadCount > 0) {
                    badge.text(unreadCount).show();
                } else {
                    badge.hide();
                }
            } else {
                console.error("data.$values is not an array:", data);
            }
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            console.error("Error updating notification count:", errorThrown);
        });
    }

    $('#notificationDropdown').click(function (e) {
        e.preventDefault();
        $.get('/Notification', function (data) {
            let notificationMenu = $('#notification-menu');
            notificationMenu.empty();
            // Access data.$values and check if it's an array
            if (Array.isArray(data.$values)) {
                if (data.$values.length > 0) {
                    data.$values.forEach(notification => {
                        notificationMenu.append(`<a class="dropdown-item ${notification.isRead ? 'read-notification' : 'unread-notification'}" href="#" data-id="${notification.notificationId}">${notification.message}</a>`);
                        console.log(notification);
                    });
                    notificationMenu.append(`<a class="dropdown-item" href="#" id="mark-all-read">Mark all as read</a>`);
                } else {
                    notificationMenu.append('<a class="dropdown-item" href="#">No notifications</a>');
                }
            } else {
                console.error("data.$values is not an array:", data);
                notificationMenu.append('<a class="dropdown-item" href="#">Error loading notifications</a>');
            }
        }).fail(err => {
            console.error('Failed to fetch notifications', err);
        });
    });

    $('#notification-menu').on('click', '#mark-all-read', function (e) {
        e.preventDefault();
        $.post('/Notification/MarkAllAsRead', function () { // URL is correct
            $('#notification-count').hide().text('0');
            $('#notification-menu').find('.unread-notification').removeClass('unread-notification').addClass('read-notification');
        })
        .fail(function (jqXHR, textStatus, errorThrown) {
            console.error("Error marking all as read:", errorThrown);
        });
    });

    $('#notification-menu').on('click', '.dropdown-item', function (e) {
        e.preventDefault();
        var notificationId = $(this).data('id');

        if ($(this).attr('id') === 'mark-all-read') {
            return;
        }

        if (notificationId) {
            $.post('/Notification/MarkNotificationAsRead', { notificationId: notificationId }, function () { // URL is correct
                $(this).removeClass('unread-notification').addClass('read-notification');

                var badge = $('#notification-count');
                var currentCount = parseInt(badge.text());
                if (currentCount > 0) {
                    badge.text(currentCount - 1);
                }
            }.bind(this))
            .fail(function (jqXHR, textStatus, errorThrown) {
                console.error("Error marking notification as read:", errorThrown);
            });
        }
    });

    updateNotificationCount();
    setInterval(updateNotificationCount, 60000);
});