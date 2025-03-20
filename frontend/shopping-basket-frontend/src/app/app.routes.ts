import { Routes } from '@angular/router';
import { BasketFormComponent } from './components/basket-form/basket-form.component';
import { ReceiptComponent } from './components/receipt/receipt.component';

export const routes: Routes = [
    { path: '', component: BasketFormComponent },
    { path: 'receipt', component: ReceiptComponent }
];
