import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { BookListComponent } from './books/book-list/book-list.component';
import { MatDialogModule } from '@angular/material/dialog';
import { DetailPopupComponent } from './detail-popup/detail-popup.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginatorModule } from '@angular/material/paginator';
import { HttpClientModule } from '@angular/common/http';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { ToastrModule } from 'ngx-toastr';
import { ConfirmationPopupComponent } from './confirmation-popup/confirmation-popup.component';
import { DeliveryInfoAirCraftComponent } from './delivery-services/delivery-info-aircraft.component';
import { DeliveryInfoMotorComponent } from './delivery-services/delivery-info-motor.component';
import { DeliveryInfoTrainComponent } from './delivery-services/delivery-info-train.component';

@NgModule({
  declarations: [
    AppComponent,
    BookListComponent,
    DetailPopupComponent,
    ConfirmationPopupComponent,
    DeliveryInfoAirCraftComponent,
    DeliveryInfoMotorComponent,
    DeliveryInfoTrainComponent
  ],
  imports: [
    BrowserModule,
    MatDialogModule,
    BrowserAnimationsModule,
    MatIconModule,
    MatPaginatorModule,
    HttpClientModule,
    MatFormFieldModule,
    MatInputModule,
    ToastrModule.forRoot() 
  ],
  providers: [],
  entryComponents: [
    DetailPopupComponent,
    ConfirmationPopupComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
