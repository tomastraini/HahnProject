import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { AppComponent } from 'src/app/app.component';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.scss']
})
export class PersonComponent implements OnInit {

  constructor(private http: HttpClient, private appComponent: AppComponent) { }
  people: any;
  persontypes: any;
  @Input() searchvalue: any;

  modalTitle = "Modal title";
  modalbtnClass = "btn-primary";
  action = "";
  errorMesage = "";

  id: any;
  business_name: any;
  balance = 0;
  type: any;

  ngOnInit(): void
  {
    const route = this.appComponent.apiUrl;
    this.http.get<any[]>(route + '/Person').subscribe(res =>{
      res.forEach(x => {
        x.creation_Date_converted = new Date(x.creation_date).toLocaleDateString()
      });
      this.people = res
    });
    this.http.get<any[]>(route + '/Persontype').subscribe(res =>{
      this.persontypes = res
    });
  }

  OnOpenModal(from: string, data: any): void
  {
    this.action = from;
    if(from == "add")
    {
      this.modalTitle = "Add new person"
      this.modalbtnClass = "btn-primary"

      this.business_name = "";
      this.balance = 0;
      this.type = ""
    }
    if(from == "edit")
    {
      this.modalTitle = "Edit person"
      this.modalbtnClass = "btn-warning"
      
      this.id = data.id;
      this.business_name = data.business_name;
      this.balance = data.balance;
      this.type = data.persontype.id
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
      this.http.delete(this.appComponent.apiUrl + '/Person?id=' + this.id, {
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
      this.errorMesage = "The Business name is empty!!"
      return;
    }
    if( this.balance == null || this.balance == undefined)
    {
      this.errorMesage = "The balance is empty!!"
      return;
    }
    if(isNaN(this.type) || this.type == -1 || this.type == 0)
    {
      this.errorMesage = "The person type is empty or invalid!!"
      return;
    }
    
    if(this.action == "add")
    {
      this.http.post(this.appComponent.apiUrl + '/Person', {
        business_name: this.business_name,
        balance: this.balance,
        person_type: this.type
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
      this.http.put(this.appComponent.apiUrl + '/Person', {
        id: this.id,
        business_name: this.business_name,
        balance: this.balance,
        person_type: this.type
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
