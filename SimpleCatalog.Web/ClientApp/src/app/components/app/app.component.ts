import { Component } from '@angular/core';
import { ProductCategory, Product } from '../../models';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  public productCategoryNode: ProductCategory;
  public productSelected: Product;

  onChangeCategory(category: ProductCategory) {
    this.productCategoryNode = category;
    this.productSelected = new Product();
  }

  onChangeProduct(product: Product) {
    this.productSelected = product;
  }

  onEditProduct() {
    this.productCategoryNode = Object.assign({}, this.productCategoryNode);
  }
}