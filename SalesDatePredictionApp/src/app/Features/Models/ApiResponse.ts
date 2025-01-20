  export interface ApiResponse<T> {
    result: T;
    errorMessages: T;
    isSuccess: boolean;
    quantityResults: number;
    displayMessage: string;
  }