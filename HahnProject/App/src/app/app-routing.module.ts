import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from './main/main.component';
import { PersonComponent } from './main/person/person.component';
import { PersontypeComponent } from './main/persontype/persontype.component';
import { ProductsComponent } from './main/products/products.component';
import { TransactionsComponent } from './main/transactions/transactions.component';
import { MainmenuComponent } from './main/mainmenu/mainmenu.component';
import { SubtransactionsComponent } from './main/subtransactions/subtransactions.component';

const routes: Routes = [
  {
    path: '',
    component: MainComponent,
    children:
    [
      {
        path: 'people',
        component: PersonComponent,
      },
      {
        path: 'persontype',
        component: PersontypeComponent,
      },
      {
        path: 'products',
        component: ProductsComponent,
      },
      {
        path: 'transactions',
        component: TransactionsComponent,
      },
      {
        path: '',
        component: MainmenuComponent,
      },
      {
        path: 'subtransactions',
        component: SubtransactionsComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

export const routingcomponents = [MainComponent];
