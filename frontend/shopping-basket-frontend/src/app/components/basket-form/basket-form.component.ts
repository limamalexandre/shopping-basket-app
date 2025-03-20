import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BasketService } from '../../services/basket.service';
import { CommonModule } from '@angular/common';
import { ProductService } from '../../services/product.service';
import { ReceiptService } from '../../services/receipt.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-basket-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './basket-form.component.html',
  styleUrls: ['./basket-form.component.scss']
})
export class BasketFormComponent implements OnInit {
  products: any[] = [];

  // Basket model with items initialized once products are loaded
  basket = {
    items: [] as any[]
  };

  @Output() receiptGenerated = new EventEmitter<any>();

  constructor(
    private basketService: BasketService,
    private productService: ProductService,
    private receiptService: ReceiptService,
    private router: Router
  ) {}

  ngOnInit(): void {
    // Load the products from the backend when the component initializes
    this.productService.getProducts().subscribe({
      next: (data) => {
        this.products = data;

        // Create basket items using the loaded products with default quantity 0
        this.basket.items = this.products.map(product => ({
          product: product,
          quantity: 0
        }));
      },
      error: (err) => console.error('Error loading products', err)
    });
  }

  onSubmit(): void {
    // Call the backend API to generate the receipt
    this.basketService.generateReceipt(this.basket).subscribe(receipt => {
      // Store the receipt in the shared service.
      this.receiptService.receipt = receipt;
      // Navigate to the receipt display route.
      this.router.navigate(['/receipt']);
    });
  }
}
