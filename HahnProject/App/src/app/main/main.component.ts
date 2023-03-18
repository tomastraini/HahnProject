import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.scss']
})
export class MainComponent implements OnInit {

  constructor(public router: Router) { }
  view = '';

  ngOnInit(): void
  {
    this.view = this.router.url.replace("/", "");
    if (this.view === '/'){ this.view = ''; }

  }

}
