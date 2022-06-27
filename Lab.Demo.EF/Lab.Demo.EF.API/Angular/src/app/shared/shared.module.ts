import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { MatToolbarModule } from '@angular/material/toolbar';
import { AppRoutingModule } from '../app-routing.module';
import { DialogoInfoComponent } from './dialogo-info/dialogo-info.component';
import { MaterialModule } from '../material/material.module';

@NgModule({
  declarations: [NavbarComponent, DialogoInfoComponent],
  imports: [CommonModule, MatToolbarModule, AppRoutingModule, MaterialModule],
  exports: [NavbarComponent],
})
export class SharedModule {}
