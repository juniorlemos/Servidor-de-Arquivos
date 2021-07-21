$(document).ready(function () {
    var mensagem = $('#Mensagem').text();

    switch (mensagem) {
        case "sucesso":
            toastr.success("Documento cadastrado com sucesso");
            break;
        case "erro":
            toastr.error("Erro no cadastro , não foi possivel cadastrar o seu documento ,tente novamente");
            break;
        case "erroCodigo":
            toastr.error("Erro no cadastro ,este código já está sendo utilizado. Por favor tente outro código");
            break;
        default:
    }
});