import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { AppComponent } from 'src/app/app.component';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  constructor(private http: HttpClient, private appComponent: AppComponent) { }
  products: any;
  suppliers: any[] = [];

  @Input() searchvalue: any;

  modalTitle = "Modal title";
  modalbtnClass = "btn-primary";
  action = "";
  errorMesage = "";
  supplier: any;

  id: any;
  description: any;
  price: any;
  stock: any;
  business_name: any;
  supplier_id: any;

  ngOnInit(): void
  {
    const route = this.appComponent.apiUrl;

    this.http.get<any[]>(route + '/Products').subscribe(res =>{
      this.products = res
    });

    this.http.get<any[]>(route + '/Person/ByType?id=2').subscribe(res =>{
      res.forEach(x => {
        x.creation_date_t = new Date(x.creation_date).toLocaleDateString()
      });

      this.suppliers = res;

    });
  }

  OnOpenModal(from: string, data: any): void
  {
    this.action = from;
    if(from == "suppliers")
    {
      data.creation_date = new Date(data.creation_date).toLocaleDateString()
      this.supplier = data
      return;
    }

    if(from == "add")
    {
      this.modalTitle = "Add new person type"
      this.modalbtnClass = "btn-primary"

      this.description = "";
      this.price = "";
      this.stock = "";
      this.supplier_id = "";
    }
    if(from == "edit")
    {
      this.modalTitle = "Edit person type"
      this.modalbtnClass = "btn-warning"
      
      this.id = data.id;
      this.description = data.description;
      this.price = data.price;
      this.stock = data.stock;
      this.supplier_id = data.supplier.id;
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
      this.http.delete(this.appComponent.apiUrl + '/Products?id=' + this.id, {
        observe: 'response',
      }).subscribe(data => {
        if(data.status === 200)
        {
          window.location.reload()
        }
      });
      return;
    }
    

    if(this.description == "" || this.description == null || this.description == undefined)
    {
      this.errorMesage = "The description is invalid!!"
      return;
    }

    if(this.price == "" || this.price == null || this.price == undefined || isNaN(this.price))
    {
      this.errorMesage = "The price is invalid!!"
      return;
    }
    if(this.stock == "" || this.stock == null || this.stock == undefined || isNaN(this.stock))
    {
      this.errorMesage = "The stock is invalid!!"
      return;
    }
    if(this.supplier_id == "" || this.supplier_id == null || this.supplier_id == undefined || isNaN(this.supplier_id))
    {
      this.errorMesage = "The supplier is invalid!!"
      return;
    }
    
    
    if(this.action == "add")
    {
      this.http.post(this.appComponent.apiUrl + '/Products', {
        description: this.description,
        price: this.price,
        stock: this.stock,
        supplier_id: this.supplier_id
      }, {
        observe: 'response',
      }).subscribe(data => {
          if(data.status === 200)
          {
            window.location.reload()
          }
      });
    }

    if(this.action == "edit")
    {
      if(this.id == "" || this.id == null || this.id == undefined) return;
      this.http.put(this.appComponent.apiUrl + '/Products', {
        id: this.id,
        description: this.description,
        price: this.price,
        stock: this.stock,
        supplier_id: this.supplier_id
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

}
