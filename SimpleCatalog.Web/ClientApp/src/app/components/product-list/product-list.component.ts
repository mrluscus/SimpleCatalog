import { Component, Input, OnChanges, SimpleChanges, OnInit, ViewChild, Output, EventEmitter } from '@angular/core';
import { Product, ProductCategory } from '../../models';
import { ProductService } from '../../services/index';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
    selector: 'product-list',
    styleUrls: ['./product-list.component.css'],
    templateUrl: './product-list.component.html'
})
export class ProductListComponent implements OnChanges, OnInit {

    @Input() productCategoryNode: ProductCategory;
    @Output() onChangeProduct = new EventEmitter<Product>();
    displayedColumns: string[];
    isLoading = true;
    resultsLength = 0;
    // Selection of Checkboxes
    selection = new SelectionModel<Product>(true, []);
    // Selection of highlight
    selectedItemId: string;
    dataSource: MatTableDataSource<Product>;

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    constructor(private productService: ProductService) {
        this.displayedColumns = ['select', 'name', 'price', 'quantity'];
        this.isLoading = false;
        this.selection = new SelectionModel<Product>(true, []);
    }
    ngOnInit(): void {
        this.productCategoryNode = new ProductCategory();
    }

    ngOnChanges(changes: SimpleChanges) {
        let chng = changes["productCategoryNode"];
        let cur = chng.currentValue;
        if (cur) {
            this.productCategoryNode = <ProductCategory>cur;
            this.loadData();
        }
        else
            this.productCategoryNode = new ProductCategory();
    }

    loadData() {
        this.isLoading = true;
        this.productService.getByCategoryId(this.productCategoryNode.id).subscribe(data => {
            this.dataSource = new MatTableDataSource<Product>(data.json());
            this.dataSource.sort = this.sort;
            this.dataSource.paginator = this.paginator;
            this.isLoading = false;
        });
    }

    /** Whether the number of selected elements matches the total number of rows. */
    isAllSelected() {
        const numSelected = this.selection.selected.length;
        const numRows = this.dataSource.data.length;
        return numSelected === numRows;
    }

    /** Selects all rows if they are not all selected; otherwise clear selection. */
    masterToggle() {
        this.isAllSelected() ?
            this.selection.clear() :
            this.dataSource.data.forEach(row => this.selection.select(row));

    }

    deleteSelected() {
        let ids: string[] = [];
        this.selection.selected.forEach(row =>
            ids.push(row.id)
        );

        if (ids) {
            this.isLoading = true;
            this.productService.deleteByIds(ids).subscribe(() => {
                this.loadData();
            });
        }
    }

    onClick(row: Product) {
        this.selectedItemId = row.id;
        this.dataSource.data.forEach(row => row.highlighted = false);
        row.highlighted = !row.highlighted;

        this.onChangeProduct.emit(row);
    }

}
