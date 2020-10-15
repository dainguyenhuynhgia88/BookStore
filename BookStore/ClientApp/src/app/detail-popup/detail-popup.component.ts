import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { Book } from '../books/book/book.model';
import { DeliveryPriceService } from '../delivery-services/delivery-services.service';
import { DeliveryService } from '../delivery-services/delivery-services.model';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationPopupComponent } from '../confirmation-popup/confirmation-popup.component';

@Component({
  selector: 'detail-popup',
  templateUrl: './detail-popup.component.html'
})
export class DetailPopupComponent {
  deliveryServices: Array<DeliveryService>;
  colors: Array<string> = ["success", "primary", "warning"];
  selectedDeliveryService: DeliveryService;

  constructor(
    private dialogRef: MatDialogRef<DetailPopupComponent>,
    @Inject(MAT_DIALOG_DATA) public book: Book,
    private deliveryPriceService: DeliveryPriceService,
    private toastr: ToastrService,
    private dialog: MatDialog) { }

  ngOnInit() {
    this.loadData();
  }

  loadData() {
    this.deliveryPriceService.list().subscribe(result => {
      this.deliveryServices = result;
      let colorIndex = 0;
      for (let i = 0; i < this.deliveryServices.length; i++) {
        this.deliveryServices[i].buttonColor = this.colors[colorIndex];
        colorIndex++;
        if (colorIndex > this.colors.length - 1) colorIndex = 0;
      }
    }, err => console.error(err));
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onSelectDeliveryService(deliveryService: DeliveryService) {
    this.selectedDeliveryService = deliveryService;
  }

  onBuy() {
    if (this.selectedDeliveryService == null) {
      this.toastr.error("Please choose delivery service!");
      return;
    }

    this.dialogRef.close();

    this.dialog.open(ConfirmationPopupComponent, {
      width: '550px',
      data: this.selectedDeliveryService
    });
  }
}
