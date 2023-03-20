import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'productsFilter'
})
export class ProductsFilterPipe implements PipeTransform {
  transform(li: any[], value: string): any {
    var response = value !== undefined && li !== undefined ? li.filter(val =>
      val.id.toString().indexOf(value) !== -1 ||
      val.description.indexOf(value) !== -1 ||
      val.price.toString().indexOf(value) !== -1 ||
      val.stock.toString().indexOf(value) !== -1 ||
      val.supplier.business_name.indexOf(value) !== -1 ||

      val.id.toString().toLowerCase().indexOf(value.toLowerCase()) !== -1 ||
      val.description.toLowerCase().indexOf(value.toLowerCase()) !== -1 ||
      val.price.toString().toLowerCase().indexOf(value.toLowerCase()) !== -1 ||
      val.stock.toString().toLowerCase().indexOf(value.toLowerCase()) !== -1 ||
      val.supplier.business_name.toLowerCase().indexOf(value.toLowerCase()) !== -1

    ) : li;
    
   return response;
  }
}
