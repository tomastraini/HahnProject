import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'transactionsFilter'
})
export class TransactionsFilterPipe implements PipeTransform {
  transform(li: any[], value: string): any {
    var response = value !== undefined && li !== undefined ? li.filter(val =>
      val.id.toString().indexOf(value) !== -1 ||
      val.transaction_began.indexOf(value) !== -1 ||
      val.total.toString().indexOf(value) !== -1 ||
      val.persondata.business_name.toString().indexOf(value) !== -1 ||

      val.id.toString().toLowerCase().indexOf(value.toLowerCase()) !== -1 ||
      val.transaction_began.toLowerCase().indexOf(value.toLowerCase()) !== -1 ||
      val.total.toString().toLowerCase().indexOf(value.toLowerCase()) !== -1 ||
      val.persondata.business_name.toString().toLowerCase().indexOf(value.toLowerCase()) !== -1

    ) : li;
    
   return response;
  }
}
