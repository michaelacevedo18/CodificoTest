import { Component } from '@angular/core';
import { CustomertableComponent } from './customertable/customertable.component';
import {MatIconModule} from '@angular/material/icon';
@Component({
  selector: 'app-salesdatepredictionview',
  standalone: true,
  imports: [CustomertableComponent, MatIconModule],
  templateUrl: './salesdatepredictionview.component.html',
  styleUrl: './salesdatepredictionview.component.css'
})
export class SalesdatepredictionviewComponent {

}
