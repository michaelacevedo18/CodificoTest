import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { OrdersService } from '../../Features/Services/orders.service';

import { CommonModule } from '@angular/common';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { EmployeeService } from '../../Features/Services/employee.service';
import { ShipperService } from '../../Features/Services/shipper.service';
import { ProductService } from '../../Features/Services/product.service';
import { ApiResponse } from '../../Features/Models/ApiResponse';

@Component({
  selector: 'app-orderform',
  standalone: true,  
  imports: [ReactiveFormsModule, CommonModule, MatFormFieldModule, MatSelectModule],
  templateUrl: './orderform.component.html',
  styleUrl: './orderform.component.css'
})

export class OrderformComponent implements OnInit{
  form: FormGroup;
  employees:any[]=[];
  shippers:any[]=[];
  products:any[]=[];
  
  selectedShipperId: number=0;
  selectedShipperAdress: string = '';

  // Variable para almacenar la dirección del shipper seleccionado
  
constructor(@Inject(MAT_DIALOG_DATA) public data: any,private fb: FormBuilder,
 private dataService:OrdersService, private employeeService: EmployeeService,
  private shipperService: ShipperService, private productService: ProductService,
  private orderService: OrdersService
 ,private dialogRef: MatDialogRef<OrderformComponent>){
  this.form = this.fb.group({    
    employeeId: [null, Validators.required], 
    shipperId: [null, Validators.required], 
    customerId:[this.data] ,
    orderDate:  [null, Validators.required], 
    
    requiredDate:  [null, Validators.required],  
    shippedDate:  [null, Validators.required],  
    freigth:  [null, Validators.required], 
       
    productId: [null, Validators.required], 
    unitPrice: [null, Validators.required], 
    quantity: [null, Validators.required], 
    discount: [null, Validators.required],
    
    shipAdress: [null, Validators.required],
    shipCity: [null, Validators.required],
    shipCountry: [null, Validators.required], 
  });
}
  ngOnInit(): void {
    this.getEmployees();
    this.getProducts();
    this.getShippers();
  }
 

  onSubmit(): void {
    if (this.form.valid) {
      const updatedData = this.form.value;
      this.orderService.saveOrder(updatedData).subscribe(
        (response: ApiResponse<any>) => {
          if (response && response.displayMessage) {
            alert(response.displayMessage);  // Mostrar el mensaje del servidor
            
            this.dialogRef.close();
            console.log('Datos guardados correctamente', response);
          } else {
            alert('Datos Insertados con éxito');
          }
        },
        (error) => {
          alert('Ha ocurrido un error al insertar los datos');
          console.error('Error al guardar datos', error);
        }
      );
    } else {
      alert('Datos incompletos');
      console.error('Datos incompletos, por favor verifique los datos ingresados');
    }
  }
  

getShippers() {   
  this.shipperService.getShippers().subscribe(
    (response: ApiResponse<any>) => {
      if (response && response.result) {
        this.shippers = response.result;  
        console.log(this.shippers)      
      } else {
        console.error('La respuesta no contiene la propiedad result');
      }
    },
    (error) => {
      console.error('Error al traer result', error);
    }
  );
}
getProducts() {   
  this.productService.getProducts().subscribe(
    (response: ApiResponse<any>) => {
      if (response && response.result) {
        this.products = response.result;        
      } else {
        console.error('La respuesta no contiene la propiedad result');
      }
    },
    (error) => {
      console.error('Error al traer result', error);
    }
  );
}
getEmployees() {   
  this.employeeService.getEmployees().subscribe(
    (response: ApiResponse<any>) => {
      if (response && response.result) {
        this.employees = response.result;        
      } else {
        console.error('La respuesta no contiene la propiedad result');
      }
    },
    (error) => {
      console.error('Error al traer result', error);
    }
  );
}
onClose(): void {
  this.dialogRef.close();
}
onShipperChange() {
  // Encontrar el shipper seleccionado usando su ID
  const selectedShipper = this.shippers.find(est => est.shipperId === this.selectedShipperId);

  // Si se encuentra el shipper, actualizar la dirección
  if (selectedShipper) {
    this.selectedShipperAdress = selectedShipper.shipAddress;
  }
}
}