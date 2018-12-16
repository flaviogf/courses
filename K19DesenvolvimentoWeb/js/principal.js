var scrollTimeout = 0;
var isLoadingArticles = false;

$(document).ready(function(e) {
    $('#articles-container').on('click', '.show-comments', function(e) {
        $(this).parent().find('form, article').slideDown();
        $(this).hide();
    });

    $('#main-menu-btn').click(function(e) {
        e.stopPropagation();
        $(this).parent().find('ul').addClass('expanded').slideDown();
    });

    $('html').click(function(e) {
        $('#main-header ul.expanded').removeClass('expanded').slideUp(400, () => {
            $('this').removeAttr('style');
        });
    });

    $(window).scroll(function(e) {
        clearTimeout(scrollTimeout);
        scrollTimeout = setTimeout(afterScroll, 500);
    })

    loadArticles();
});

function afterScroll() {
    if(isLoadingArticles && $('lazy-load-point').isOnScreen()) {
        loadArticles();
    }
}

function loadArticles() {
    $.ajax({
        url: 'servico.php',
        dataType: 'html',
        beforeSend: function(jqXHR, settings) {
            isLoadingArticles = true;

            $('#lazy-load-point').addClass('loading');
        },
        complete: function {
            setTimeout(function() {
                isLoadingArticles = false;

                $('#lazy-load-point').removeClass('loading');
            }, 1000);
        },
        success: function(data, textStatus, jqXHR) {
            setTimeout(() => {
                $('#articles-container').prepend(data);
            }, 1000);
        },
        error: function(jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

$.fn.isOnScreen = function() {
    var win = $(window);

    var viewport = {
        top: win.scrollTop(),
        left: win.scrollLeft()
    };

    viewport.right = viewport.left + win.width();
    viewport.bottom = viewport.top + win.heigth();

    var bounds = this.offset();
    bounds.right = bounds.left + this.outerWidth();
    bounds.bottom = bound.top + this.outerHeight();

    return (!(viewport.right < bounds.left ||
        viewport.left > bounds.right ||
        viewport.bottom < bounds.top ||
        viewport.top > bounds.bottom));
};
