import { getDataAsync } from "./request.js";

$(document).ready(function () {
  let btnsSelecionar = document.getElementsByClassName("btn-selecionar-vaga");

  Array.from(btnsSelecionar).forEach((btn) => {
    const id = btn.getAttribute("vaga-id");

    btn.addEventListener("click", function (event) {
      selecionarVaga(id);
    });
  });
});

function selecionarVaga(id) {
  const uri = `/wa/Vagas/${id}/Detalhes`;

  getDataAsync(uri).then((dados) => {
    setarPartialView(dados);
    $("#collapseVagas").collapse('hide');
    $("#vaga-selecionada").css("display","block");
  });

}

function setarPartialView(vaga) {
  $("#CodigoVaga").val(vaga.codigoVaga);
  $("#ProjetoVaga").val(vaga.projeto);
  $("#VagaId").val(vaga.id);

  console.log(vaga);

  $("#tecnologias-vaga").empty();
  vaga.tecnologiasDaVaga.forEach((tecnologia) => inserirTecnologiaVaga(tecnologia));
}

function inserirTecnologiaVaga(tecnologia) {
  $("#tecnologias-vaga").append(`
    <p class="mr-3"> <img src="${tecnologia.imageSource}" alt="${tecnologia.nome}" style="max-height: 40px;"> </p>
  `);
}
