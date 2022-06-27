import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListaComponent } from './components/lista/lista.component';
import { AboutComponent } from './components/about/about.component';
import { HomeComponent } from './components/home/home.component';
import { CrearComponent } from './components/crear/crear.component';
import { MaterialModule } from '../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EditarComponent } from './components/editar/editar.component';
import { AppRoutingModule } from '../app-routing.module';

@NgModule({
  declarations: [
    ListaComponent,
    AboutComponent,
    HomeComponent,
    CrearComponent,
    EditarComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
  ],
})
export class AbmModule {}
