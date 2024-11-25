import { Component, inject, OnInit, signal, WritableSignal } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogActions, MatDialogContent, MatDialogRef } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { ConfirmationDialogData } from '../../models/confirmation-dialog-data.interface';

@Component({
  selector: 'app-confirmation-dialog',
  standalone: true,
  imports: [
    MatDialogContent,
    MatDialogActions,
    MatButtonModule
  ],
  templateUrl: './confirmation-dialog.component.html',
  styleUrl: './confirmation-dialog.component.scss'
})
export class ConfirmationDialogComponent implements OnInit {

  dialogTitle: WritableSignal<string> = signal('');
  dialogMessage: WritableSignal<string> = signal('');
  cancelText: WritableSignal<string> = signal('Cancel');
  confirmText: WritableSignal<string> = signal('OK');

  private dialogRef = inject(MatDialogRef<ConfirmationDialogComponent>);
  public data: ConfirmationDialogData = inject(MAT_DIALOG_DATA);

  ngOnInit(): void {
    if(this.data) {
      this.dialogTitle.set(this.data.dialogTitle ? this.data.dialogTitle : '');
      this.dialogMessage.set(this.data.dialogMessage ? this.data.dialogMessage : '');
      this.cancelText.set(this.data.cancelText ? this.data.cancelText : 'Cancel');
      this.confirmText.set(this.data.confirmText ? this.data.confirmText : 'OK');
    }
  }
  
  cancel(): void {
    this.dialogRef.close({dialogResult: false});
  }

  confirm(): void {
    this.dialogRef.close({dialogResult: true});
  }

}
