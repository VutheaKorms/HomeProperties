function onAddMemberClick() {
    $('#addMember').click(function () {
        window.location = getUrl('membership/add');
    });
}

function onSearchMembersClick() {
    $('#searchMembers').click(function () {
        window.location = getUrl('membership/search')
    });
}

function onBrowseMembersClick() {
    $('#browseMembers').click(function () {
        window.location = getUrl('membership/browse');
    });
}

(function ($) {
    onAddMemberClick();
    onSearchMembersClick();
    onBrowseMembersClick();
})(jQuery);