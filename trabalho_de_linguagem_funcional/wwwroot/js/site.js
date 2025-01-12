


//SCRIPT DO HEADER SHARED

var cordefundo = localStorage.getItem("cordefundo"); //definindo um local Storage pra manter o tema escuro/claro dependendo da escolha
if (cordefundo == null || cordefundo == 0) {
  document.querySelector(".body").style.backgroundColor = "#fff";
  cordefundo = 0;
} else {
  document.querySelector(".body").style.backgroundColor = "#000";
  cordefundo = 1;
}

function modoescuro() {
  if (cordefundo == 0) {
    document.querySelector(".body").style.backgroundColor = "#000";
    cordefundo = 1;
  } else {
    document.querySelector(".body").style.backgroundColor = "#fff";
    cordefundo = 0;
  }
  localStorage.setItem("cordefundo", cordefundo);
}




//SCRIPT DAS PAGINAS





var test = 0; //variavel para abrir e fechar a parte de ver o código

//adicionando evento de quando o usuario digita 1000

var inputElement = document.querySelector(".inputTexto");

inputElement.addEventListener("input", function () {
  var valorDigitado = inputElement.value;

  // Verifique se o valor digitado é igual a "42"
  if (valorDigitado === "1000") {
    // Faça algo quando "42" for digitado, por exemplo, exibir uma mensagem
    alert("Você digitou o número 1000!");
  }
});

/*função de exibir as informaçoes */
function exibirinfos(valor) {
  const CDI = document.querySelector(".informacoes_Tipos_De_InvestimentosCDI");
  const SELIC = document.querySelector(
    ".informacoes_Tipos_De_InvestimentosSELIC"
  );
  const POUP = document.querySelector(
    ".informacoes_Tipos_De_InvestimentosPOUP"
  );
  const CDB = document.querySelector(".informacoes_Tipos_De_InvestimentosCDB");

  if (valor == 1) {
    /*fechando as infos abertas*/
    SELIC.style.left = "225px";
    POUP.style.left = "225px";
    CDB.style.left = "225px";

    if (CDI.style.left == "410px") {
      CDI.style.left = "225px";
    } else {
      CDI.style.left = "410px";
    }
  }
  if (valor == 2) {
    /*fechando as infos abertas*/
    CDI.style.left = "225px";
    POUP.style.left = "225px";
    CDB.style.left = "225px";

    if (SELIC.style.left == "410px") {
      SELIC.style.left = "225px";
    } else {
      SELIC.style.left = "410px";
    }
  }
  if (valor == 3) {
    /*fechando as infos abertas*/
    SELIC.style.left = "225px";
    CDI.style.left = "225px";
    CDB.style.left = "225px";

    if (POUP.style.left == "410px") {
      POUP.style.left = "225px";
    } else {
      POUP.style.left = "410px";
    }
  }
  if (valor == 4) {
    /*fechando as infos abertas*/
    SELIC.style.left = "225px";
    CDI.style.left = "225px";
    POUP.style.left = "225px";

    if (CDB.style.left == "410px") {
      CDB.style.left = "225px";
    } else {
      CDB.style.left = "410px";
    }
  }
}
function InvestimentoSelecionado(valor) {
  let cdibutton = document.querySelector(".cdibutton");
  let CDBompostosbutton = document.querySelector(".CDBompostosbutton");
  let selicbutton = document.querySelector(".selicbutton");
  let poupancaButton = document.querySelector(".poupancaButton");
  if (valor == 1) {
    let tipo = (document.querySelector(".tipo").innerHTML = "CDI");
    cdibutton.style.border = "solid 5px";
    CDBompostosbutton.style.border = "0px";
    selicbutton.style.border = "0px";
    poupancaButton.style.border = "0px";
  }
  if (valor == 2) {
    let tipo = (document.querySelector(".tipo").innerHTML = "CDB");
    cdibutton.style.border = "0px";
    CDBompostosbutton.style.border = "solid 5px";
    selicbutton.style.border = "0px";
    poupancaButton.style.border = "0px";
  }
  if (valor == 3) {
    let tipo = (document.querySelector(".tipo").innerHTML = "SELIC");
    cdibutton.style.border = "0px";
    CDBompostosbutton.style.border = "0px";
    selicbutton.style.border = "solid 5px";
    poupancaButton.style.border = "0px";
  }
  if (valor == 4) {
    let tipo = (document.querySelector(".tipo").innerHTML = "POUPANÇA");
    cdibutton.style.border = "0px";
    CDBompostosbutton.style.border = "0px";
    selicbutton.style.border = "0px";
    poupancaButton.style.border = "solid 5px";
  }
}
function calcular() {
  if (document.querySelector(".tipo").innerHTML == "") {
    alert("NENHUM INVESTIMENTO FOI SELECIONADO!");
  } else {
    document.querySelector(".valorInicial").innerHTML =
      document.querySelector(".input").value;

    let escurecendotela = document.querySelector(".escurecendotela");
    escurecendotela.style.opacity = "1";
    let telaResultados = document.querySelector(".telaResultados");
    telaResultados.style.transform = "scale(1)";
  }
}
function fecharTelaResultados() {
  let escurecendotela = document.querySelector(".escurecendotela");
  escurecendotela.style.opacity = "0";
  let telaResultados = document.querySelector(".telaResultados");
  telaResultados.style.transform = "scale(0)";
}
function mostrarCodigo() {
  if (test == 0) {
    let telaCodigos = document.querySelector(".telaCodigos");
    let telaResultados = document.querySelector(".telaResultados");
    telaResultados.style.marginRight = "520px";
    telaCodigos.style.marginLeft = "520px";
    telaCodigos.style.opacity = "1";
    telaCodigos.style.pointerEvents = "all";

    test = 1;
  } else {
    test = 0;
    fecharCodigo();
  }
}
function fecharCodigo() {
  let telaCodigos = document.querySelector(".telaCodigos");
  let telaResultados = document.querySelector(".telaResultados");
  telaResultados.style.marginRight = "0px";
  telaCodigos.style.marginLeft = "0px";
  telaCodigos.style.opacity = "0";
  telaCodigos.style.pointerEvents = "none";
}
var valor2;
function setvalor2(valor) {
  valor2 = valor;
}

function Resultados() {
  //requisições HTTP
  let valor1 = document.querySelector(".input").value;
  fetch(
    "api/meu-endpointPorcentagemAnual?numero=" + valor1 + "&numero2=" + valor2,
    {
      method: "GET",
    }
  )
    .then((response) => response.json())
    .then((data) => {
      const resultadoAnual = parseFloat(data.resultadoAnual).toFixed(2);
      const resultadoMensal = parseFloat(data.resultadoMensal).toFixed(2);
      const resultadoDiario = parseFloat(data.resultadoDiario).toFixed(2);

      const porcentagemA = parseFloat(valor2).toFixed(2);
      const porcentagemM = parseFloat(data.porcentagemM).toFixed(2);
      const porcentagemD = parseFloat(data.porcentagemD).toFixed(2);

      document.querySelector(".resultadoAnual").innerHTML = resultadoAnual;
      document.querySelector(".resultadoMensal").innerHTML = resultadoMensal;
      document.querySelector(".resultadoDiario").innerHTML = resultadoDiario;

      document.querySelector(".porcentagemAnual").innerHTML =
        "%" + porcentagemA;
      document.querySelector(".porcentagemMensal").innerHTML =
        "%" + porcentagemM;
      document.querySelector(".porcentagemDiaria").innerHTML =
        "%" + porcentagemD;
    });
}
