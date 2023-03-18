import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AppComponent } from 'src/app/app.component';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.scss']
})
export class PersonComponent implements OnInit {

  constructor(private http: HttpClient, private appComponent: AppComponent) { }
  people: any;
  ngOnInit(): void
  {
    const route = this.appComponent.apiUrl + '/Person';
    this.http.get<any[]>(route).subscribe(res =>{
      res.forEach(x => {
        x.creation_Date_converted = new Date(x.creation_date).toLocaleDateString()
      });
      this.people = res
    });

  }

}
