describe('Receipt Generation', () => {
    it('Generates and displays receipt when basket has items', () => {
      // Visit the basket form page.
      cy.visit('http://localhost:4200/');

      // Fill out the form. Adjust selectors based on your HTML.
      cy.get('input[name="quantity0"]').type('2');  // For first product
      cy.get('input[name="quantity1"]').type('1');  // For second product

      // Click the button to generate receipt.
      cy.get('button').contains('Generate Receipt').click();

      // The app should navigate to the receipt page.
      cy.url().should('include', '/receipt');

      // Verify that the receipt table is visible.
      cy.get('table').should('be.visible');
      // Optionally, verify that receipt data is shown.
      cy.get('table tbody tr').should('have.length.greaterThan', 0);
    });
});
