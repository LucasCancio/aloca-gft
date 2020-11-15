let tecnologias = [];

function ExcluirTecnologia(id) {
  tecnologias = tecnologias.filter((tec) => tec.id != id);
  MontarTabela();
}

function MontarTabela() {
  const table = $("#tbTecnologias");

  $("#tbTecnologias tbody").empty();

  tecnologias.forEach((tecnologia, index) => {
    table.append(`<tr>
                <td>
                    <input class="tecnologia-id"  type="hidden" name="TecnologiaIds[${index}]" value="${tecnologia.id}">
                    <p id="tecnologia_nome_${tecnologia.id}">${tecnologia.nome}</p>
                </td>
                <td>
                    <button type="button" class="btn btn-danger excluir-tecnologia" onclick="ExcluirTecnologia(${tecnologia.id})">Excluir</button>
                </td>
            </tr>
            `);
  });
}

$(document).ready(function () {
  let elements = document.getElementsByClassName("tecnologia-id");

  Array.from(elements).forEach((element) => {
    const id = element.value;
    const nome = document.getElementById(`tecnologia_nome_${id}`).innerHTML;
    let tecnologia = { id, nome };

    tecnologias.push(tecnologia);
  });

  $("#btnAdicionarTec").click(function () {
    const tecnologiasSelect = document.getElementById("Tecnologias");
    const nomeSelecionado =
      tecnologiasSelect.options[tecnologiasSelect.selectedIndex].text;
    const idSelecionado =
      tecnologiasSelect.options[tecnologiasSelect.selectedIndex].value;

    const jaSelecionada = tecnologias.find((tec) => tec.id == idSelecionado);
    if (!jaSelecionada) {
      tecnologias.push({
        id: idSelecionado,
        nome: nomeSelecionado,
      });

      MontarTabela();
    }
  });
});
