import { Component, Input, SimpleChanges, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators, NgForm } from '@angular/forms';
import { Product } from '../../models';
import { ProductService } from '../../services';

@Component({
    selector: 'product-detail',
    styleUrls: ['./product-detail.component.css'],
    templateUrl: './product-detail.component.html'
})
export class ProductDetailComponent implements OnInit {

    @Input() productSelected: Product;
    @Output() onEditProduct = new EventEmitter();
    @ViewChild('productForm')
    productForm: NgForm;

    // Copy of original Product for editing
    private product: Product;
    imgSrc: FileReader;
    isLoading: boolean;
    isEditing: boolean;

    constructor(private productService: ProductService) {
        this.isLoading = false;
    }

    ngOnInit(): void {
        if (!this.product)
            this.product = new Product();
    }

    ngOnChanges(changes: SimpleChanges) {
        let chng = changes["productSelected"];
        let cur = chng.currentValue;
        if (cur) {
            this.isLoading = true;
            this.productSelected = <Product>cur;

            this.isLoading = false;
        }
        else
            this.product = new Product();
        this.setInitialState();
    }

    setInitialState() {
        this.product = Object.assign({}, this.productSelected);
        this.productForm.form.markAsPristine();
        this.productForm.form.markAsUntouched();
    }

    onFileChange(event: any) {
        if (event && event.target.files && event.target.files[0]) {
            var reader = new FileReader();

            reader.onload = (event: ProgressEvent) => {
                this.imgSrc = (<FileReader>event.target).result;
            }
            reader.readAsDataURL(event.target.files[0]);
        }
    }

    saveProduct() {
        this.isLoading = true;
        this.productService.save(this.product).subscribe(() => {
            this.productSelected = Object.assign({}, this.product);
            this.setInitialState();
            this.isLoading = false;
            this.onEditProduct.emit();
        });
    }

    cancelSelected() {
        this.setInitialState();
    }
}