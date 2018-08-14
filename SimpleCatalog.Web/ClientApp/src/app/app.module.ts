import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { ProductCategoryComponent } from './components/product-category/product-category.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { ProductDetailComponent } from './components/product-detail/product-detail.component';
import { ProductCategoryService, ProductService } from './services/index';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  MatButtonModule,
  MatCheckboxModule,
  MatCardModule,
  MatTreeModule,
  MatIconModule,
  MatProgressBarModule,
  MatPaginatorModule,
  MatTableModule,
  MatProgressSpinnerModule,
  MatSortModule,
  MatTooltipModule,
  MatInputModule
} from '@angular/material';
import { CdkTreeModule } from '@angular/cdk/tree';
import { MatFormFieldModule } from '@angular/material/form-field';

@NgModule({
  declarations: [
    AppComponent,
    ProductCategoryComponent,
    ProductListComponent,
    ProductDetailComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot([]),
    BrowserAnimationsModule,
    CdkTreeModule,
    MatButtonModule,
    MatCheckboxModule,
    MatCardModule,
    MatTreeModule,
    MatIconModule,
    MatProgressBarModule,
    MatPaginatorModule,
    MatTableModule,
    MatProgressSpinnerModule,
    MatSortModule,
    MatTooltipModule,
    MatFormFieldModule,  
    MatInputModule  
  ],
  providers: [
    { provide: 'BASE_URL', useFactory: getBaseUrl },
    ProductCategoryService,
    ProductService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}
