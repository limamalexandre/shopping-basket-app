import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  // Calls the endpoint that generates the receipt.
  generateReceipt(basket: any): Observable<any> {
    return this.http.post(`${this.apiUrl}/Basket/receipt`, basket);
  }
}
