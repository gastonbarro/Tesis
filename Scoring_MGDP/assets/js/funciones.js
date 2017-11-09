function Mensaje(mensaje, prioridad, titulo) {

    $.toaster({
        priority: prioridad,
        title: titulo,
        message: mensaje,
        'class': 'toaster'
    });
}

function ModalSimple(titulo, cuerpo) {

    var modal =
    '<div class="modal fade" id="ModalSimpleContainer" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">' +
    '  <div class="modal-dialog" role="document">' +
    '    <div class="modal-content">' +
    '      <div class="modal-header">' +
    //'        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>' +
    //'        <button type="button" class="close" onclick="MatarModal();"><span aria-hidden="true">&times;</span></button>' +
    '          <button type="button" class="close" onclick="MatarModal();"><span aria-hidden="true"><i class="fa fa-fw fa-close"></i></span></button>' +
    '        <h4 class="modal-title" id="myModalLabel">' + titulo + '</h4>' +
    '      </div>' +
    '      <div class="modal-body" id="modal-body">' + cuerpo + '</div>' +
    '    </div>' +
    '  </div>' +
    '</div>';

    $(modal).modal({
        backdrop: 'static',
        keyboard: false
    });

}

function ModalSimpleGrande(titulo, cuerpo) {

    var modal =
    '<div class="modal fade" id="ModalSimpleContainer" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">' +
    '  <div class="modal-dialog modal80" role="document">' +
    '    <div class="modal-content">' +
    '      <div class="modal-header">' +
    //'        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>' +
    //'        <button type="button" class="close" onclick="MatarModal();"><span aria-hidden="true">&times;</span></button>' +
    '          <button type="button" class="close" onclick="MatarModal();"><span aria-hidden="true"><i class="fa fa-fw fa-close"></i></span></button>' +
    '        <h4 class="modal-title" id="myModalLabel">' + titulo + '</h4>' +
    '      </div>' +
    '      <div class="modal-body" id="modal-body">' + cuerpo + '</div>' +
    '    </div>' +
    '  </div>' +
    '</div>';

    $(modal).modal({
        backdrop: 'static',
        keyboard: false
    });
}

function MatarModal() {
    //$('.modal-backdrop').remove();
    //$('#ModalSimpleContainer').data('modal', null);
    //$("#ModalSimpleContainer").remove();

    $('.modal.in').modal('hide');

    setTimeout(function () {
        $('.modal-backdrop').remove();
        $("div[id ^= 'ModalSimpleContainer']").data('modal', null);
        $("div[id ^= 'ModalSimpleContainer']").remove();
    }, 300);
}

jQuery.fn.center = function () {
    this.css("position", "fixed");
    this.css("top", Math.max(0, (($(window).height() - $(this).outerHeight()) / 2) +
                                                $(window).scrollTop()) + "px");
    this.css("left", Math.max(0, (($(window).width() - $(this).outerWidth()) / 2) +
                                                $(window).scrollLeft()) + "px");
    return this;
}

function rgbToHex(color) {
    if (color.charAt(0) === "#") {
        return color;
    }

    var nums = /(.*?)rgb\((\d+),\s*(\d+),\s*(\d+)\)/i.exec(color),
        r = parseInt(nums[2], 10).toString(16),
        g = parseInt(nums[3], 10).toString(16),
        b = parseInt(nums[4], 10).toString(16);

    return "#" + (
        (r.length == 1 ? "0" + r : r) +
        (g.length == 1 ? "0" + g : g) +
        (b.length == 1 ? "0" + b : b)
    );
}
