import { Component, ViewChildren, ElementRef, Renderer2, EventEmitter, Output } from '@angular/core';
import { NestedTreeControl } from '@angular/cdk/tree';
import { MatTreeNestedDataSource, MatTreeNode } from '@angular/material/tree';
import { ProductCategoryService } from '../../services/index';
import { CategoryNode } from '../../models/category-node';
import { BehaviorSubject } from 'rxjs';

@Component({
    selector: 'product-category',
    styleUrls: ['./product-category.component.css'],
    templateUrl: './product-category.component.html'
})
export class ProductCategoryComponent {

    @Output() onChangeCategory = new EventEmitter<string>();
    dataChange = new BehaviorSubject<CategoryNode[]>([]);
    nestedTreeControl: NestedTreeControl<CategoryNode>;
    nestedDataSource: MatTreeNestedDataSource<CategoryNode>;

    hasNestedChild = (_: number, nodeData: CategoryNode) => nodeData.children;
    private _getChildren = (node: CategoryNode) => node.children;

    isLoading: boolean;

    constructor(productCategoryService: ProductCategoryService, private renderer: Renderer2) {

        this.nestedTreeControl = new NestedTreeControl<CategoryNode>(this._getChildren);
        this.nestedDataSource = new MatTreeNestedDataSource();
        this.isLoading = true;

        productCategoryService.getAll().subscribe(resp => {
            const data = resp.json() as CategoryNode[];
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

    onClick(node: CategoryNode) {
        console.log(node);
        this.onChangeCategory.emit(node.id);
    };

}