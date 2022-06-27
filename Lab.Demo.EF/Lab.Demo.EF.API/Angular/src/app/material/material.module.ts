import { NgModule } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { MatRadioModule } from '@angular/material/radio';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatDialogModule } from '@angular/material/dialog';

const MaterialComponents = [
  MatFormFieldModule,
  MatSelectModule,
  MatRadioModule,
  MatIconModule,
  MatButtonModule,
  MatInputModule,
  MatTableModule,
  MatDialogModule,
];

@NgModule({
  declarations: [],
  imports: [MaterialComponents],
  exports: [MaterialComponents],
})
export class MaterialModule {}
