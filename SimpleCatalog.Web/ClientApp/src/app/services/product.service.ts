import { Http } from '@angular/http';
import { Inject, Injectable } from '@angular/core';
import { Product } from '../models';

@Injectable()
export class ProductService {

    private apiUrl = this.baseUrl + 'api/product';
    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) { }

    get(id: string) {
        this.http.get(`${this.apiUrl}/${id}`);
    }

    getAll() {
        return this.http.get(this.apiUrl);
    };

    getByCategoryId(id: string) {
        return this.http.get(`${this.apiUrl}/GetByCategoryId/${id}`);
    }

    deleteByIds(ids: string[]){
        return this.http.post(`${this.apiUrl}/DeleteByIds`, ids);
    }

    save(item: Product){
        return this.http.post(`${this.apiUrl}`, item);
    }
}