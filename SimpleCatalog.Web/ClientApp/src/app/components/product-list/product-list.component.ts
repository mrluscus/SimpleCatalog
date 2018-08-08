import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';

@Component({
    selector: 'product-list',
    templateUrl: './product-list.component.html'
})
export class ProductListComponent implements OnChanges {
    @Input() categoryId: string;

    ngOnChanges(changes: SimpleChanges) {
        let chng = changes["categoryId"];
        let cur = chng.currentValue;
        if (cur) {
            this.categoryId = <string>cur;
            console.log(this.categoryId);
        }
        else
            this.categoryId = "";
    }
}