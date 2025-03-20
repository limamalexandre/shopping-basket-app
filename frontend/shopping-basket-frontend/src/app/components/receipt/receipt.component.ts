import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { ReceiptService } from '../../services/receipt.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-receipt',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './receipt.component.html',
  styleUrl: './receipt.component.scss'
})
export class ReceiptComponent {
  receipt: any;

  constructor(
    private receiptService: ReceiptService,
    private router: Router
  ) {}

  ngOnInit(): void {
    // Retrieve the receipt from the shared service.
    this.receipt = this.receiptService.receipt;
    if (!this.receipt) {
      // If no receipt exists, redirect back to the basket.
      this.router.navigate(['/']);
    }
  }

  backToBasket(): void {
    this.router.navigate(['/']);
  }
}
