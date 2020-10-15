import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DeliveryService } from '../delivery-services/delivery-services.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'confirmation-popup',
  templateUrl: './confirmation-popup.component.html'
})
export class ConfirmationPopupComponent {
  constructor(
    private dialogRef: MatDialogRef<ConfirmationPopupComponent>,
    @Inject(MAT_DIALOG_DATA) public deliveryService: DeliveryService,
    private toastr: ToastrService) { }

  onNoClick(): void {
    this.dialogRef.close();
  }

  onConfirm() {
    this.dialogRef.close();
    this.toastr.success("Thanks for your purchase!");
  }
}
