import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MenuComponent } from './Shared/menu/menu.component';
import { MatSortModule } from '@angular/material/sort';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MenuComponent, MatSortModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'SalesDatePredictionApp';
}
