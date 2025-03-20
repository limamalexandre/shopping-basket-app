import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ReceiptService {
  private _receipt: any;

  set receipt(data: any) {
    this._receipt = data;
  }

  get receipt(): any {
    return this._receipt;
  }

  clearReceipt(): void {
    this._receipt = null;
  }
}
