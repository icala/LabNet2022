import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './abm/components/about/about.component';
import { CrearComponent } from './abm/components/crear/crear.component';
import { EditarComponent } from './abm/components/editar/editar.component';
import { HomeComponent } from './abm/components/home/home.component';
import { ListaComponent } from './abm/components/lista/lista.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'crear', component: CrearComponent },
  { path: 'lista', component: ListaComponent },
  { path: 'about', component: AboutComponent },
  { path: 'editar', component: EditarComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
