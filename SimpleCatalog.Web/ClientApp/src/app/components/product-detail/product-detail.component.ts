import { Component, Input, SimpleChanges } from '@angular/core';
import { Product } from '../../models';
import { ProductService } from '../../services/index';

@Component({
    selector: 'product-detail',
    templateUrl: './product-detail.component.html'
})
export class ProductDetailComponent {

    @Input() productSelected: Product;

    ngOnChanges(changes: SimpleChanges) {
        let chng = changes["productSelected"];
        let cur = chng.currentValue;
        if (cur) {
            this.productSelected = <Product>cur;
            console.log(this.productSelected);
                        
        }
        else
            this.productSelected = new Product();
    }
}
