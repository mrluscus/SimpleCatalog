import { Http, ResponseContentType } from '@angular/http';
import { Inject, Injectable } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable()
export class ImageService {

    private apiUrl = this.baseUrl + 'api/image';
    constructor(private http: Http,
        @Inject('BASE_URL') private baseUrl: string,
        private sanitizer: DomSanitizer
    ) { }

    check(id: string){
        return this.http.get(`${this.apiUrl}/check/${id}`);
    }

    get(id: string): Observable<File> {
        return this.http
            .get(`${this.apiUrl}/${id}`, { responseType: ResponseContentType.Blob })
            .pipe(map((res: Response) => res.blob()));
    }

    upload(imageData: any, fileName: string) {
        var imageToSend = imageData.replace('data:image/png;base64,', '').replace('data:image/jpeg;base64,','');
        var dataToSend = {
            "imageData": imageToSend,
            "fileName": fileName
        };

        return this.http.post(`${this.apiUrl}/upload`, dataToSend);
    }
}