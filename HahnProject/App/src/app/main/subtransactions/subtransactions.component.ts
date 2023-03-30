import { HttpClient } from '@angular/common/http';
import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppComponent } from 'src/app/app.component';
import { FormControl, FormsModule } from '@angular/forms';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import { map, Observable, startWith } from 'rxjs';

@Component({
  selector: 'app-subtransactions',
  templateUrl: './subtransactions.component.html',
  styleUrls: ['./subtransactions.component.scss']
})
export class SubtransactionsComponent implements OnInit {

  constructor(private http: HttpClient, private appComponent: AppComponent, private route: ActivatedRoute) { }
  @Input() searchvalue: any;
  fathertransaction: any;
  subtransactions: any;
  products: any = [];

  myControl = new FormControl('');
  filteredOptions: Observable<any[]> = new Observable<any[]>();

  visibilitydropdown = false

  routte: any = this.appComponent.apiUrl;

  
  modalTitle = "Modal title";
  modalbtnClass = "btn-primary";
  action = "";
  errorMesage = "";

  productMessage = ""

  id: any;
  transaction_id: any;
  product_id: any;
  product_price: any;
  product_description: any;
  amount: any;
  total: any;

  ngOnInit(): void
  {
    var transaction_id = sessionStorage.getItem("transaction");
    if(transaction_id === undefined || transaction_id === null)
    {
      window.location.reload();
    }
    else
    {
      this.http.get<any>(this.routte + '/Transactions/' + transaction_id)
      .subscribe(res =>{
        this.subtransactions = res.subTransactions;
        this.fathertransaction = res;
        this.transaction_id = res.id;
      })
    }


    this.http.get<any[]>(this.routte + '/Products').subscribe(res =>{
      this.products = res.find(x => x.description.includes(this.product_description))
      this.visibilitydropdown = true

      this.filteredOptions = this.myControl.valueChanges.pipe(
        startWith(''),
        map(value => this._filter(value || '', res)),
      );
    })
  }
  //////////////////// products dropdown
  private _filter(value: any, first: any): any[] {
    return first.filter((option: any) => {
      if (typeof value === 'number') { value = "" };
      return option.description.toLowerCase().includes(value.toLowerCase());
    });
  }

  getTotal(): void
  {
    if(!isNaN(this.product_price))
    {
      this.total = this.amount * this.product_price
    }
  }

  OnProductSelected(product: any)
  {
    this.product_id = product.id
    this.productMessage = product.description
    this.product_price = product.price
  }

  AutoCompleteDisplay(item: any): string {
    if (item == undefined) { return ""; }
    return item.description;
  }
  ////////////////////

  OnOpenModal(from: string, data: any): void
  {
    this.action = from;
    if(from == "add")
    {
      this.modalTitle = "Add new transaction"
      this.modalbtnClass = "btn-primary"

      this.id = 0;
      this.product_id = 0;
      this.amount = 0;

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
      this.http.delete(this.appComponent.apiUrl + '/SubTransactions?id=' + this.id,
      {
        observe: 'response',
      }).subscribe(data => {
          if(data.status === 200)
          {
            window.location.reload()
          }
      });
    }
    
    if(this.action == "add")
    {
      this.http.post(this.appComponent.apiUrl + '/SubTransactions', {
        transaction_id: this.transaction_id,
        product_id: this.product_id,
        amount: this.amount,
        total: this.total
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


  searchProduct(): void
  {

  }

}
