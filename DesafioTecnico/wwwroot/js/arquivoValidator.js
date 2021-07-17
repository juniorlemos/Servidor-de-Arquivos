$(document).ready(function () {
    jQuery.validator.addMethod("filetype", function (value, element) {
        var types = ['xls', 'doc', 'pdf', 'docx', 'xlsx'],
            ext = value.replace(/.*[.]/, '').toLowerCase();

        if (types.indexOf(ext) !== -1) {

            return true;
        }
        return false;
    },
        "Escolha um arquivo no formato suportado"
    );
    $('#myForm').validate({
        rules:
        {
            file:
            {
                filetype: true
            }
        }
    });
});