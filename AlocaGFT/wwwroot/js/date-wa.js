const QTD_DIAS_WA = 15;

$(document).ready(function () {
  $("#Inicio_wa").change(function () {
    const dataInicioWa = new Date($("#Inicio_wa").val());

    if (dataInicioWa) {
      let dataTerminoWa = dataInicioWa.addDays(15);
      $("#Termino_wa").val(dataTerminoWa.toJSON().slice(0,10));
    }
  });
});


Date.prototype.addDays = function (days) {
  var date = new Date(this.valueOf());
  date.setDate(date.getDate() + days);
  return date;
};
