$(document).ready(function () {


    $('#btnSimularPlano').click(function (e) {
        e.preventDefault();
    });

    $("#btnSimularPlano").click(function (e) {
        var codigo_origem_ = $("#codigo_origem").val();
        var codigo_destino_ = $("#codigo_destino").val();
        var id_plano_ = $("#id_plano").val();
        var tempo_ = $("#tempo").val();

        if (codigo_origem_ == "") {
            alert("O campo DDD de origem é obrigatório")
            return false;
        }

        if (codigo_destino_ == "") {
            alert("O campo DDD de destino é obrigatório")
            return false;
        }

        if (tempo_ == "") {
            alert("O campo Tenpo de ligação é obrigatório")
            return false;
        }

        if (id_plano_ == "") {
            alert("O campo Plano é obrigatório")
            return false;
        }

        $.ajax({
            url: location.origin + $('#URLSimulacao').val(),
            dataType: "JSON",
            data: {
                codigo_origem: codigo_origem_,
                codigo_destino: codigo_destino_,
                tempo: tempo_,
                id_plano: id_plano_
            },
            type: "POST",
            cache: false,
            success: function (data) {
                if (data != null) {
                    alert("Sucesso")
                } else {
                    alert("Erro")
                }
            }
        }).done(function (data) {

            $("#formSimularPlano")[0].reset();

            var index = $('#tableSimulacao').find('tr[id]').length;

            data.Chamada.DDDOrigem.Codigo = "0" + data.Chamada.DDDOrigem.Codigo
            var origem = '<td>' + data.Chamada.DDDOrigem.Codigo + '</td>';

            data.Chamada.DDDDestino.Codigo = "0" + data.Chamada.DDDDestino.Codigo
            var destino = '<td>' + data.Chamada.DDDDestino.Codigo + '</td>';

            var plano = '<td>' + data.Plano.Descricao + '</td>';

            var valorComFaleMais = ""
            if (data.ValorComFaleMais != null) {
                valorComFaleMais = parseFloat(data.ValorComFaleMais).toFixed(2);
            }
            valorComFaleMais = '<td>' + valorComFaleMais + '</td>';

            var valorSemFaleMais = ""
            if (data.ValorSemFaleMais != null) {
                valorSemFaleMais = parseFloat(data.ValorSemFaleMais).toFixed(2);
            }
            valorSemFaleMais = '<td>' + valorSemFaleMais + '</td>';

            var tempo = '<td>' + data.Tempo + '</td>';

            var countId = $('#tableSimulacao tr').length;

            var simulacao = '<tr id=' + countId + '>' + origem + destino + tempo + plano + valorComFaleMais + valorSemFaleMais + '</tr>';

            $('#tableSimulacao').append(simulacao);

        });
    });
});