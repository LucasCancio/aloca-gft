import { getDataAsync } from "./request.js";

$(document).ready(function () {
  const logradouro = $("#Endereco_logradouro");
  const bairro = $("#Endereco_bairro");
  const cidade = $("#Endereco_cidade");
  const uf = $("#Endereco_uf");

  function limpa_formulário_cep() {
    logradouro.val("");
    bairro.val("");
    cidade.val("");
    uf.val("");
  }

  $("#btnCep").click(function () {
    var cep = $("#Endereco_cep").val().replace(/\D/g, "");

    if (cep != "") {
      var validacep = /^[0-9]{8}$/;

      if (validacep.test(cep)) {
        logradouro.val("...");
        bairro.val("...");
        cidade.val("...");
        uf.val("...");

        const uri = "/wa/Cep/GetEndereco?cep=" + cep;

        getDataAsync(uri)
          .then((dados) => {
            console.log("dados: ", dados);

            if (dados.cep != null) {
              logradouro.val(dados.logradouro);
              bairro.val(dados.bairro);
              cidade.val(dados.cidade.nome);
              uf.val(dados.estado.sigla);
              const { latitude, longitude } = dados;
              setarCoordenada(latitude, longitude);
            } else {
              limpa_formulário_cep();
              alert("CEP não encontrado.");
            }
          })
          .catch((error) => {
            limpa_formulário_cep();
            alert(error);
          });
      } else {
        limpa_formulário_cep();
        alert("Formato de CEP inválido.");
      }
    } else {
      limpa_formulário_cep();
    }
  });
});
