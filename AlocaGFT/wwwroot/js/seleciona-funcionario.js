import { postDataAsync } from "./request.js";

let funcionariosIdsSelecionados = [];
let funcionarios = [];

$("#btnAplicarFuncionarios").click(function (event) {
  let checksSelecionar = document.getElementsByClassName("btn-selecionar-func");

  Array.from(checksSelecionar).forEach((checkbox) => {
    const inputId = checkbox.getAttribute("func-id");
    const id = Number.parseInt(inputId);

    if (checkbox.checked) {
      if (!funcionariosIdsSelecionados.find((idSelect) => idSelect == id)) {
        funcionariosIdsSelecionados.push(id);
      }
    } else {
      removeFuncionarioIdSelecionado(id);
    }
  });

  setarPartialView(funcionariosIdsSelecionados);

  $("#collapseFuncs").collapse("hide");
});

function setarPartialView(funcionariosIds) {
  const uri = `/wa/Alocacao/Funcionarios`;

  const headers = new Headers();
  headers.append("Accept", "*/*");
  headers.append("Content-Type", "application/json");

  postDataAsync(uri, funcionariosIds, headers).then((dados) => {
    let funcionariosParseado = JSON.parse(dados);

    console.log(funcionariosParseado);

    funcionariosParseado.forEach((func) => {
      let { nome, id, matricula, tecnologiasDoFunc, cargo, gft } = func;
      funcionarios.push({
        nome,
        id,
        matricula,
        tecnologiasDoFunc,
        cargo,
        gft,
        alocado: false,
      });
    });

    MontarTabela_FuncionariosSelecionados();
  });
}

function removeFuncionarioIdSelecionado(idParaRemover) {
  funcionariosIdsSelecionados = funcionariosIdsSelecionados.filter(
    (idSelect) => idSelect != idParaRemover
  );

  let checksSelecionar = document.getElementsByClassName("btn-selecionar-func");

  Array.from(checksSelecionar).forEach((checkbox) => {
    const inputId = checkbox.getAttribute("func-id");
    const id = Number.parseInt(inputId);

    if (id == idParaRemover) {
      checkbox.checked = false;
    }
  });

  funcionarios = funcionarios.filter(
    (funcionario) => funcionario.id != idParaRemover
  );
}

function cancelarFuncionario(funcionarioId) {
  removeFuncionarioIdSelecionado(funcionarioId);

  MontarTabela_FuncionariosSelecionados();
}

function MontarTabela_FuncionariosSelecionados() {
  const table = $("#tbFuncionariosSelect");

  $("#tbFuncionariosSelect tbody").empty();

  funcionarios.forEach((funcionario, index) => {
    table.append(`<tr class="func-row">
            <td>
            ${funcionario.alocado ? "<b>(JÁ ALOCADO)</b>" : ""}
            <input type="hidden" class="func-id" func-id="${
              funcionario.id
            }" name="FuncionariosAlocados[${index}].Id" value="${
      funcionario.id
    }"/>
            <span class="func-nome">${funcionario.nome}</span>
            </td>
            <td class="func-matricula">${funcionario.matricula}</td>
            <td>
            ${funcionario.tecnologiasDoFunc.map(
              (tecnologia) =>
                `<img class="func-tec" src="${tecnologia.imageSource}" alt="${tecnologia.nome}" style="max-height: 40px;">`
            )}
            </td>
            <td class="func-cargo">${funcionario.cargo?.nome}</td>
            <td class="func-gft">${funcionario.gft?.nome}</td>
            <td>
              <button type="button" class="btn btn-danger btn-cancelar" func-id="${
                funcionario.id
              }">${
      funcionario.alocado
        ? `<i class="fas fa-exclamation-triangle"></i> Desalocar`
        : "Cancelar"
    }</button>
            </td>
        </tr>`);
  });

  let btnsCancelar = document.getElementsByClassName("btn-cancelar");

  Array.from(btnsCancelar).forEach((btn) => {
    const id = btn.getAttribute("func-id");

    btn.addEventListener("click", function (e) {
      cancelarFuncionario(id);
    });
  });
}

$(document).ready(function () {
  let funcRows = document.getElementsByClassName("func-row");

  Array.from(funcRows).forEach((row) => {
    const nome = row.querySelector(".func-nome").innerHTML;
    const id = row.querySelector(".func-id").value;
    const matricula = row.querySelector(".func-matricula").innerHTML;
    const cargoNome = row.querySelector(".func-cargo").innerHTML;
    const gftNome = row.querySelector(".func-gft").innerHTML;

    const tecnologiasDoFunc = [];
    row.querySelectorAll(".func-tec").forEach((funcTec) => {
      let tecnologia = {
        imageSource: funcTec.getAttribute("src"),
        nome: funcTec.getAttribute("alt"),
      };

      tecnologiasDoFunc.push(tecnologia);
    });

    funcionarios.push({
      nome,
      id,
      matricula,
      tecnologiasDoFunc,
      cargo: { nome: cargoNome },
      gft: { nome: gftNome },
      alocado: true,
    });
  });

  let btnsCancelar = document.getElementsByClassName("btn-cancelar");

  Array.from(btnsCancelar).forEach((btn) => {
    const id = btn.getAttribute("func-id");

    btn.addEventListener("click", function (e) {
      cancelarFuncionario(id);
    });
  });
});
