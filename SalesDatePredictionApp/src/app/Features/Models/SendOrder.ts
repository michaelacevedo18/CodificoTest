export interface OrderDetail {
  productId: number;
  unitPrice: number;
  quantity: number;
  discount: number;
}

export interface Order {
  orderId: number;
  employeeId: number;
  shipperId: number;
  customerId: number;
  orderDate: Date; 
  requiredDate: Date;
  shippedDate: Date;
  freight: number;
  orderDetails: OrderDetail[];
  shipperName: string;
  shipperAddress: string;
  shipperCity: string;
}
