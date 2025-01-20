export class UrlConfig {
    static readonly BASE_URL: string = 'https://localhost:7200/api';
    static readonly URL_CUSTOMER_PREDICTIONS: string = `${UrlConfig.BASE_URL}/Customer/GetTotalLastNextOrder`;      
    static readonly URL_CUSTOMER_ORDERS: string = `${UrlConfig.BASE_URL}/Orders/GetOrdersByCustomerId`;   
    static readonly URL_Employees: string = `${UrlConfig.BASE_URL}/Employees`;
    static readonly URL_Products: string = `${UrlConfig.BASE_URL}/Products`;
    static readonly URL_Shippers: string = `${UrlConfig.BASE_URL}/Shippers`;
    static readonly URL_saveOrder: string = `${UrlConfig.BASE_URL}/Orders`;
  }