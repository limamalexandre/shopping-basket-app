import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  // Calls the endpoint that gets all the products.
  getProducts(): Observable<any> {
    return this.http.get(`${this.apiUrl}/Product`);
  }
}
