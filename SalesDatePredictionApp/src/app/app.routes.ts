import { Routes } from '@angular/router';
import { NotfoundComponent } from './Shared/notfound/notfound.component';
import { SalesdatepredictionviewComponent } from './UI/salesdatepredictionview/salesdatepredictionview.component';
import { OrdersviewComponent } from './UI/ordersview/ordersview.component';



export const routes: Routes = [   
    { 
        path: 'salesdatepredictionview',
        component: SalesdatepredictionviewComponent 
    },
    { 
        path: 'ordersview',
        component: OrdersviewComponent 
    },
   
    { path: '', 
        redirectTo: '/salesdatepredictionview', 
        pathMatch: 'full'
    },
    { path: '**', component: NotfoundComponent },

];
