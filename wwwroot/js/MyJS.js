"use strict";

function DeleteListItem(html_id, delete_url) {
    $.get(delete_url, function (data, status) {
        $('#' + html_id).replaceWith(data);
    });
}

function ConfirmDeleteListItem(html_id, delete_url, item_id) {
    $.post(delete_url,
        {
            itemId: item_id
        },
        function (data, status) {

            if (status === 'success') {
                $('#' + html_id).replaceWith(data);
            }
            else if (status === 'notfound') {
                $('#' + html_id).replaceWith('');
                alert("Your list is old, pleace refrece.");
            }
            else if (status === 'badrequest') {
                $('#' + html_id).replaceWith('');
                alert("Your list is corrupt, pleace refrece.");
            }
            else {
                console.log('error: ' + status);
            }
        }
    );
}