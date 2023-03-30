import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'subtransactionsFilter'
})
export class SubTransactionsFilterPipe implements PipeTransform {
  transform(li: any[], value: string): any {
    var response = value !== undefined && li !== undefined ? li.filter(val =>
      val.id.toString().indexOf(value) !== -1 ||
      val.products.description.toString().indexOf(value) !== -1 ||
      val.amount.toString().indexOf(value) !== -1 ||
      val.total.toString().indexOf(value) !== -1 ||

      val.id.toString().toLowerCase().indexOf(value.toLowerCase()) !== -1 ||
      val.products.description.toLowerCase().indexOf(value.toLowerCase()) !== -1 ||
      val.amount.toString().toLowerCase().indexOf(value.toLowerCase()) !== -1 ||
      val.total.toString().toLowerCase().indexOf(value.toLowerCase()) !== -1

    ) : li;
    
   return response;
  }
}
