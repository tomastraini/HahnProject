import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatListModule } from '@angular/material/list';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import {MatMenuModule} from '@angular/material/menu';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';


import { MainComponent } from './main/main.component';
import { ProductsComponent } from './main/products/products.component';
import { PersontypeComponent } from './main/persontype/persontype.component';
import { TransactionsComponent } from './main/transactions/transactions.component';
import { PersonComponent } from './main/person/person.component';
import { MainmenuComponent } from './main/mainmenu/mainmenu.component';
import { PeopleFilterPipe } from './Pipes/PeopleFilterPipe';
import { PersonTypeFilterPipe } from './Pipes/PersonTypeFilterPipe';
import { ProductsFilterPipe } from './Pipes/ProductsFilterPipe';
import { TransactionsFilterPipe } from './Pipes/TransactionsFilterPipe';
import { SubtransactionsComponent } from './main/subtransactions/subtransactions.component';
import { SubTransactionsFilterPipe } from './Pipes/SubTransactionsFilterPipe';

@NgModule({
  declarations: [
    AppComponent,
    PersonComponent,
    MainComponent,
    ProductsComponent,
    PersontypeComponent,
    TransactionsComponent,
    MainmenuComponent,
    PeopleFilterPipe,
    PersonTypeFilterPipe,
    ProductsFilterPipe,
    TransactionsFilterPipe,
    SubtransactionsComponent,
    SubTransactionsFilterPipe
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
    FormsModule,
    MatAutocompleteModule,
    MatInputModule,
    MatFormFieldModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
