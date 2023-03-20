import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'persontypeFilter'
})
export class PersonTypeFilterPipe implements PipeTransform {
  transform(li: any[], value: string): any {
    var response = value !== undefined && li !== undefined ? li.filter(val =>
      val.id.toString().indexOf(value) !== -1 ||
      val.type.indexOf(value) !== -1 ||

      val.id.toString().toLowerCase().indexOf(value.toLowerCase()) !== -1 ||
      val.type.toLowerCase().indexOf(value.toLowerCase()) !== -1

    ) : li;
    
   return response;
  }
}
