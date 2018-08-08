import { Http } from '@angular/http';
import { Inject, Injectable } from '@angular/core';

@Injectable()
export class ProductCategoryService {

    private apiUrl = 'api/productcategory/';
    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }    

    get(id: string) {
        this.http.get(this.baseUrl + this.apiUrl + id);            
    }

    getAll() {
        return this.http.get(this.baseUrl + this.apiUrl);
    };   
}