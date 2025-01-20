export interface Order {
    orderId: number;
    employeeId: number;
    shipperId: number;
    customerId: number;
    
    shipperName: string;
    shipperAddress: string;
    shipperCity: string;

    orderDate: Date;
    requiredDate: Date;
    shippedDate: Date;
  }