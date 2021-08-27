
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>

$(function () {

    var PlaceHolderElement = $('#PlaceHolderHere');

    $('button[data-toggle="ajax-modal" ]').click(function (event) {

        var url = $(this).data('url');

        $.get(url).done(function (data) {

            PlaceHolderElement.html(data);

            PlaceHolderElement.find('.modal').modal('show');

        })

    })

})