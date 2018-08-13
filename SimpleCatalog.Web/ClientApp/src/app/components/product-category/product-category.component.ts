import { Component, ViewChildren, ElementRef, Renderer2, EventEmitter, Output } from '@angular/core';
import { NestedTreeControl } from '@angular/cdk/tree';
import { MatTreeNestedDataSource, MatTreeNode } from '@angular/material/tree';
import { ProductCategoryService } from '../../services/index';
import { ProductCategory } from '../../models/product-category';
import { BehaviorSubject } from 'rxjs';

@Component({
    selector: 'product-category',
    styleUrls: ['./product-category.component.css'],
    templateUrl: './product-category.component.html'
})
export class ProductCategoryComponent {

    @Output() onChangeCategory = new EventEmitter<ProductCategory>();
    dataChange = new BehaviorSubject<ProductCategory[]>([]);
    nestedTreeControl: NestedTreeControl<ProductCategory>;
    nestedDataSource: MatTreeNestedDataSource<ProductCategory>;

    hasNestedChild = (_: number, nodeData: ProductCategory) => nodeData.children;
    private _getChildren = (node: ProductCategory) => node.children;

    isLoading: boolean;

    constructor(productCategoryService: ProductCategoryService, private renderer: Renderer2) {

        this.nestedTreeControl = new NestedTreeControl<ProductCategory>(this._getChildren);
        this.nestedDataSource = new MatTreeNestedDataSource();
        this.isLoading = true;

        productCategoryService.getAll().subscribe(resp => {
            const data = resp.json() as ProductCategory[];
            this.dataChange.next(data);
            this.dataChange.subscribe(data => {
                this.nestedDataSource.data = data;
                this.isLoading = false;
            });
        });
    }

    // Add listener for clicking
    @ViewChildren(MatTreeNode, { read: ElementRef }) treeNodes: ElementRef[];

    hasListener: any[] = [];
    oldHighlight: ElementRef;

    updateHighlight(newHighlight: ElementRef) {
        this.oldHighlight && this.renderer.removeClass(this.oldHighlight.nativeElement, 'background-highlight');

        this.renderer.addClass(newHighlight.nativeElement, 'background-highlight');
        this.oldHighlight = newHighlight;
    }

    ngAfterViewChecked() {
        this.treeNodes.forEach((reference) => {
            if (!this.hasListener.includes(reference.nativeElement)) {

                this.renderer.listen(reference.nativeElement, 'click', () => {
                    this.updateHighlight(reference);
                });
                this.renderer.listen(reference.nativeElement.children.item(0), 'click', () => {
                    this.updateHighlight(reference);
                });

                this.hasListener = this.hasListener.concat([reference.nativeElement]);
            }
        });

        this.hasListener = this.hasListener.filter((element) => document.contains(element));
    }

    onClick(node: ProductCategory) {        
        this.onChangeCategory.emit(node);
    };

}