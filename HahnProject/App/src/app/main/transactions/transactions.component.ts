import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { AppComponent } from 'src/app/app.component';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.scss']
})
export class TransactionsComponent implements OnInit {

  constructor(private http: HttpClient, private appComponent: AppComponent) { }
  transactions: any;
  person: any;
  
  id: any;
  transaction_began: any;
  business_name: any;
  total: any;
  subtransactions: any;

  @Input() searchvalue: any;

  modalTitle = "Modal title";
  modalbtnClass = "btn-primary";
  action = "";
  errorMesage = "";

  ngOnInit(): void
  {
    const route = this.appComponent.apiUrl;

    this.http.get<any[]>(route + '/Transactions').subscribe(res =>{
      res.forEach(x => {
        var date = new Date(x.transaction_began);
        var dateStr =
        ("00" + (date.getMonth() + 1)).slice(-2) + "/" +
        ("00" + date.getDate()).slice(-2) + "/" +
        date.getFullYear() + " " +
        ("00" + date.getHours()).slice(-2) + ":" +
        ("00" + date.getMinutes()).slice(-2) + ":" +
        ("00" + date.getSeconds()).slice(-2);
        x.transaction_began_t = dateStr;
      });
      this.transactions = res;
    });

    this.http.get<any[]>(route + '/Person').subscribe(res =>
      {
        this.person = res;      

      });

  }

  OnOpenModal(from: string, data: any): void
  {
    this.action = from;
    if(from == "add")
    {
      this.modalTitle = "Add new person type"
      this.modalbtnClass = "btn-primary"

      this.id = ""
    }

    if(from == "delete")
    {
      this.modalTitle = "Are you sure?"
      this.modalbtnClass = "btn-danger"
      this.id = data.id;

    }
  }

  OnAcceptModal(): void
  {
    if(this.action == "delete")
    {
      if(this.id == "" || this.id == null || this.id == undefined){
        this.errorMesage = "The ID is empty!!"
        return;
      }
      this.http.delete(this.appComponent.apiUrl + '/Transactions?id=' + this.id, {
        observe: 'response',
      }).subscribe(data => {
        if(data.status === 200)
        {
          window.location.reload()
        }
      });
      return;
    }
    

    if(this.business_name == "" || this.business_name == null || this.business_name == undefined)
    {
      this.errorMesage = "The person is invalid!!"
      return;
    }

    if(this.action == "add")
    {
      this.http.post(this.appComponent.apiUrl + '/Transactions', {
        person: this.business_name,
        total: 0,
      }, {
        observe: 'response',
      }).subscribe(data => {
          if(data.status === 200)
          {
            window.location.reload()
          }
      });
    }
  }

  OnOpenTransaction(id: any): void
  {
    sessionStorage.setItem("transaction", this.transactions.find((x: any) => x.id == id).id)
    window.open("/subtransactions");
    
  }

}
