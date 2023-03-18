import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatSelectModule} from '@angular/material/select';
import {MatProgressBarModule} from '@angular/material/progress-bar';
import {MatToolbarModule} from '@angular/material/toolbar'; 
import {MatIconModule} from '@angular/material/icon'; 
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import {MatMenuModule} from '@angular/material/menu';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';


import { MainComponent } from './main/main.component';
import { ProductsComponent } from './main/products/products.component';
import { PersontypeComponent } from './main/persontype/persontype.component';
import { TransactionsComponent } from './main/transactions/transactions.component';
import { PersonComponent } from './main/person/person.component';
import { MainmenuComponent } from './mainmenu/mainmenu.component';

@NgModule({
  declarations: [
    AppComponent,
    PersonComponent,
    MainComponent,
    ProductsComponent,
    PersontypeComponent,
    TransactionsComponent,
    MainmenuComponent,
  ],
  imports: [
    BrowserModule,
    MatMenuModule,
    AppRoutingModule,
    MatPaginatorModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatSlideToggleModule,
    MatListModule,
    MatToolbarModule,
    MatSidenavModule,
    FormsModule,
    MatGridListModule,
    MatSelectModule,
    MatProgressBarModule,
    MatIconModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
