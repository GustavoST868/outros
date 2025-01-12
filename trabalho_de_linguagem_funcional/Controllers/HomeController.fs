namespace PPTrampo.Controllers

open System
open Microsoft.AspNetCore.Mvc

type HomeController() =
    inherit Controller()

    member this.Index() =
        this.View()
    member this.Sobre() =
        this.View()
    member this.Creditos() =
        this.View()



    [<HttpGet("api/meu-endpointPorcentagemAnual")>] 
    member this.getCalculos([<FromQuery>] numero:double,numero2: double) =
        
        //funcao recursiva
        let mutable acrecimo = 1 //transformando acrecimo em uma variavel mutavel
        let rec valorAnual a b =
            
            if acrecimo = 5 then
                a * b / 100.0 
            else
                acrecimo <- acrecimo + 1
                valorAnual a b  

        //funcoes normais
        let valorMensal (a: double) =
            a / 12.0
            
        let ValorDiario (a: double) =
             a / 365.0

        let porcentagemMensal (a: double) =
             a / 12.0
             
        let porcentagemDiaria (a: double) =
             a / 365.0
        

        let resultadoAnual: double = valorAnual numero numero2
        let resultadoMensal = valorMensal (valorAnual numero numero2)
        let resultadoDiario = ValorDiario (valorAnual numero numero2)

        let porcentagemM = (porcentagemMensal numero2)
        let porcentagemD = (porcentagemDiaria numero2)

        this.Json {| 
            resultadoAnual = resultadoAnual+numero;
            resultadoMensal = resultadoMensal+numero;
            resultadoDiario = resultadoDiario+numero;
            porcentagemM = porcentagemM;
            porcentagemD = porcentagemD |} :> IActionResult
                                                                                   