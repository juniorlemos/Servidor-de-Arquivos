// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

    $(document).ready(function () {
        $('#tabela').dataTable({
            "language": {
                "emptyTable": "Nenhum registro encontrado",
                "info": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
                "lengthMenu": "Registros por página _MENU_ ",
                "infoEmpty": "Mostrando 0 até 0 de 0 registros",
                "infoFiltered": "(Filtrados de _MAX_ registros)",
                "infoThousands": ".",
                "search": ' <i class="fas fa-search"> </i> ',
                "searchPlaceholder": 'Pesquisar',
                "loadingRecords": "Carregando...",
                "processing": "Processando...",
                "zeroRecords": "Nenhum registro encontrado",

                "paginate": {
                    "next": "Próximo",
                    "previous": "Anterior",
                    "first": "Primeiro",
                    "last": "Último"
                },

            },
            "order": [[1, "asc"]],
           

        });
        });
   