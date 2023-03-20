import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { AppComponent } from 'src/app/app.component';

@Component({
  selector: 'app-persontype',
  templateUrl: './persontype.component.html',
  styleUrls: ['./persontype.component.scss']
})
export class PersontypeComponent implements OnInit {

  constructor(private http: HttpClient, private appComponent: AppComponent) { }
  persontypes: any;
  @Input() searchvalue: any;

  modalTitle = "Modal title";
  modalbtnClass = "btn-primary";
  action = "";
  errorMesage = "";

  id: any;
  type: any;

  ngOnInit(): void
  {
    const route = this.appComponent.apiUrl;

    this.http.get<any[]>(route + '/Persontype').subscribe(res =>{
      this.persontypes = res
    });
  }

  OnOpenModal(from: string, data: any): void
  {
    this.action = from;
    if(from == "add")
    {
      this.modalTitle = "Add new person type"
      this.modalbtnClass = "btn-primary"

      this.type = ""
    }
    if(from == "edit")
    {
      this.modalTitle = "Edit person type"
      this.modalbtnClass = "btn-warning"
      
      this.id = data.id;
      this.type = data.type
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
      this.http.delete(this.appComponent.apiUrl + '/PersonType?id=' + this.id, {
        observe: 'response',
      }).subscribe(data => {
        if(data.status === 200)
        {
          window.location.reload()
        }
      });
      return;
    }
    

    if(this.type == "" || this.type == null || this.type == undefined)
    {
      this.errorMesage = "The type is empty!!"
      return;
    }
    
    if(this.action == "add")
    {
      this.http.post(this.appComponent.apiUrl + '/PersonType', {
        type: this.type,
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
      this.http.put(this.appComponent.apiUrl + '/PersonType', {
        id: this.id,
        type: this.type
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
