import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'peopleFilter'
})
export class PeopleFilterPipe implements PipeTransform {
  transform(li: any[], value: string): any {
    var response = value !== undefined && li !== undefined ? li.filter(val =>
      val.business_name.indexOf(value) !== -1 ||

      val.balance.toString().indexOf(value) !== -1 ||

      val.persontype.type.toString().indexOf(value) !== -1 ||

      val.creation_Date_converted.toString().indexOf(value) !== -1 ||

      val.business_name.toLowerCase().indexOf(value.toLowerCase()) !== -1 ||

      val.balance.toString().toLowerCase().indexOf(value.toLowerCase()) !== -1 ||

      val.persontype.type.toString().toLowerCase().indexOf(value.toLowerCase()) !== -1 ||

      val.creation_Date_converted.toString().indexOf(value) !== -1
      
    ) : li;
    
   return response;
  }
}
