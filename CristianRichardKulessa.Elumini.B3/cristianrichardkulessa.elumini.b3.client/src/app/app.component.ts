import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
interface CdbResponse {
  valorBruto: number;
  valorLiquido: number;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public valor: number = 0.01;
  public prazo: number = 1;
  public cdbResponse: CdbResponse = { valorBruto: 0, valorLiquido: 0 };
  public resultadoVisivel: boolean = false;
  public errosVisivel: boolean = false;
  public valorBruto: number = 0;
  public valorLiquido: number = 0;
  public mensagemErro: string = '';
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.valor = 0.01;
    this.prazo = 1;

    this.resultadoVisivel = false;
    this.errosVisivel = false;
  }

  onClickOK() {
    let params = new HttpParams()
      .set('valor', this.valor)
      .set('prazo', this.prazo);

    this.http.get<CdbResponse>('/cdb', { params }).subscribe(
      (result) => {
        this.cdbResponse = result;
        this.valorBruto = this.cdbResponse.valorBruto;
        this.valorLiquido = this.cdbResponse.valorLiquido;
        this.resultadoVisivel = true;
        this.errosVisivel = false;
      },
      (error) => {
        let msg = error.status + " - " + error.statusText + " - " + error.error.title;

        if (error.error.errors.Valor) {
          error.error.errors.Valor.forEach((errValor: any) => {
            msg += " - " + errValor;
          });
        }

        if (error.error.errors.Prazo) {
          error.error.errors.Prazo.forEach((errPrazo: any) => {
            msg += " - " + errPrazo;
          });
        }
        this.mensagemErro = msg;
        this.resultadoVisivel = false;
        this.errosVisivel = true;
      }
    );
  }

  onClickCancel() {
    this.valor = 0.01;
    this.prazo = 1;

    this.resultadoVisivel = false;
    this.errosVisivel = false;
  }

  validarValor(event: any) {
    const input = event.target.value;
    const regex = /^\d+(\.\d{0,2})?$/;

    if (!regex.test(input)) {
      event.target.value = input.slice(0, -1);
    }
  }

  validarPrazo(event: any) {
    const input = event.target.value;
    if (input < 1) {
      event.target.value = 1;
    } else if (input > 60) {
      event.target.value = 60;
    }
    this.prazo = event.target.value;
  }

  title = 'cristianrichardkulessa.elumini.b3.client';
}
/*
HttpErrorResponse {headers: _HttpHeaders, status: 400, statusText: 'Bad Request', url: 'https://localhost:4200/cdb?valor=null&prazo=10', ok: false, …}
*/
